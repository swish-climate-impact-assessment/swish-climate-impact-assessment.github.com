using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Swish.SimpleInstaller.Controls;
using System.IO;

namespace Swish.SimpleInstaller
{
	static class Program
	{
		[STAThread]
		static int Main(string[] arguments)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			List<Tuple<string, string>> splitArguments = ArgumentFunctions.SplitArguments(arguments);
			bool silent = ArgumentFunctions.GetSwitch(ArgumentFunctions.ArgumentCharacter + "silent", splitArguments);

			if (silent)
			{
				try
				{
					InstallFunctions.Install(null);
				} catch (Exception error)
				{
					string message = ArgumentFunctions.ErrorArgument + " " + ExceptionFunctions.WriteException(error, true);
					Console.Write(message);
					File.WriteAllText("Error.log.txt", message);
					return -1;
				}
				return 0;
			}

			Application.Run(new InstallerMain());
			return 0;
		}
	}
}
