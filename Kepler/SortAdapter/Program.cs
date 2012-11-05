using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace Swish.SortAdapter
{
	static class Program
	{
		static int Main(string[] arguments)
		{
			try
			{
				/// get the arguments

				List<Tuple<string, string>> splitArguments = ArgumentFunctions.SplitArguments(arguments);
				string inputFileName = ArgumentFunctions.GetArgument(ArgumentFunctions.InputArgument + "", splitArguments, true);
				string outputFileName = ArgumentFunctions.GetArgument(ArgumentFunctions.OutputArgument + "", splitArguments, true);
				List<string> variableNames = ArgumentFunctions.GetArgumentItems(ArgumentFunctions.ArgumentCharacter + "variables", splitArguments, true, true);

				if (!File.Exists(inputFileName))
				{
					throw new Exception("cannot find file \"" + inputFileName + "\"");
				}

				if (File.Exists(outputFileName))
				{
					File.Delete(outputFileName);
				}

				string doOutputFileName = Path.GetTempFileName();
				if (File.Exists(doOutputFileName))
				{
					// Stata does not overwrite files
					File.Delete(doOutputFileName);
				}

				/// create the do file
				List<string> lines = new List<string>();
				lines.Add("clear");
				lines.Add("insheet using \"" + inputFileName + "\"");

				/// sort varlist, stable
				/// add variables names
				string line = StataFunctions.SortCommand(variableNames);
				lines.Add(line);

				lines.Add("outsheet using \"" + doOutputFileName + "\", comma");

				StataFunctions.RunScript(lines, false);

				if (!File.Exists(doOutputFileName))
				{
					throw new Exception("Output file was not created");
				}

				/// move the output file
				if (File.Exists(outputFileName))
				{
					File.Delete(outputFileName);
				}
				File.Move(doOutputFileName, outputFileName);

				Console.Write(outputFileName);
				return 0;
			} catch (Exception error)
			{
				string message = ArgumentFunctions.ErrorArgument + " " + ExceptionFunctions.WriteException(error, true);
				Console.Write(message);
				return -1;
			}
		}


	}
}
