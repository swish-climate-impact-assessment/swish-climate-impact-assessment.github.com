using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace Swish.AppendAdapter
{
	static class Program
	{
		static int Main(string[] arguments)
		{
			try
			{
				List<Tuple<string, string>> splitArguments = ArgumentFunctions.SplitArguments(arguments);
				string input1FileName = ArgumentFunctions.GetArgument(ArgumentFunctions.InputArgument + "1", splitArguments, true);
				string input2FileName = ArgumentFunctions.GetArgument(ArgumentFunctions.InputArgument + "2", splitArguments, true);
				string outputFileName = ArgumentFunctions.GetArgument(ArgumentFunctions.OutputArgument + "", splitArguments, true);

				if (!File.Exists(input1FileName))
				{
					throw new Exception("cannot find file \"" + input1FileName + "\"");
				}

				if (!File.Exists(input2FileName))
				{
					throw new Exception("cannot find file \"" + input2FileName + "\"");
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

				string intermediateFileName = Path.GetTempFileName();
				if (File.Exists(intermediateFileName))
				{
					File.Delete(intermediateFileName);
				}

				List<string> lines = new List<string>();
				lines.Add("clear");
				lines.Add("insheet using \"" + input2FileName + "\"");
				lines.Add("save \"" + intermediateFileName + "\"");
				lines.Add("clear");
				lines.Add("insheet using \"" + input1FileName + "\"");
				lines.Add("append using \"" + intermediateFileName + "\"");
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

				/// delete all the files not needed
				File.Delete(intermediateFileName);

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
