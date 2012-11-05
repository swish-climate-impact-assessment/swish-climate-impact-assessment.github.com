using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace Swish.CollapseAdapter
{
	static class Program
	{
		static int Main(string[] arguments)
		{
			try
			{
				List<Tuple<string, string>> splitArguments = ArgumentFunctions.SplitArguments(arguments);
				string inputFileName = ArgumentFunctions.GetArgument(ArgumentFunctions.InputArgument + "", splitArguments, true);
				string variable = ArgumentFunctions.GetArgument(ArgumentFunctions.ArgumentCharacter + "variable", splitArguments, true);
				string operation = ArgumentFunctions.GetArgument(ArgumentFunctions.ArgumentCharacter + "operation", splitArguments, false);

				if (!File.Exists(inputFileName))
				{
					throw new Exception("cannot find file \"" + inputFileName + "\"");
				}

				if (string.IsNullOrWhiteSpace(operation))
				{
					operation = "mean";
				}

				string doOutputFileName = Path.GetTempFileName();
				if (File.Exists(doOutputFileName))
				{
					// Stata does not overwrite files
					File.Delete(doOutputFileName);
				}

				List<string> lines = new List<string>();
				lines.Add("clear");
				lines.Add("insheet using \"" + inputFileName + "\"");

				// collapse (mean) mean=head4 (median) medium=head4, by(head6)

				lines.Add("collapse " + "(" + operation + ") " + variable + "_" + operation + "=" + variable);

				lines.Add("outsheet using \"" + doOutputFileName + "\", comma");

				StataFunctions.RunScript(lines, false);

				if (!File.Exists(doOutputFileName))
				{
					throw new Exception("Output file was not created");
				}

				string[] resultLines = File.ReadAllLines(doOutputFileName);

				double result = double.Parse(resultLines[1]);

				/// delete all the files not needed
				File.Delete(doOutputFileName);

				Console.Write(result.ToString());
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
