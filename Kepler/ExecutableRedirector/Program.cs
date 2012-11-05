using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace Swish.ExecutableRedirector
{
	public static class Program
	{
		static int Main(string[] arguments)
		{
			try
			{
				List<string> locations = SwishFunctions.Locations();
				string executableName = Path.GetFileName(Application.ExecutablePath);

				string toolFileName = SwishFunctions.ResloveFileName(executableName, locations, true, false);

				if (toolFileName  == Application.ExecutablePath)
				{
					throw new Exception("Current executable path mistaken for path to " + executableName);
				}

				string runArguments = string.Join(" ", arguments);
				int exitCode;
				string output;
				SwishFunctions.RunProcess(toolFileName, runArguments, Environment.CurrentDirectory, false, out exitCode, out output);

				Console.Write(output);
				return exitCode;
			} catch (Exception error)
			{
				string message = ArgumentFunctions.ErrorArgument + " " + ExceptionFunctions.WriteException(error, false);
				MessageBox.Show(message);
				Console.Write(message);
				return -1;
			}
		}


	}
}
