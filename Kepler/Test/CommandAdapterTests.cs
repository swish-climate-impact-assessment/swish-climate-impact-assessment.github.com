using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Swish.CommandAdapter;

namespace Swish.Tests
{
	class CommandAdapterTests
	{
		internal void CommandScript()
		{
			// this is a test that the outputted script contains the command

			string inputFile = "in.csv";
			string outputFile = "out.csv";
			string command = "this is the command";

			List<string> lines = Program.CreateDoFile(inputFile, outputFile, command);

			if (!LinesContain(command, lines))
			{
				throw new Exception();
			}
		}

		private bool LinesContain(string command, List<string> lines)
		{
			for (int lineIndex = 0; lineIndex < lines.Count; lineIndex++)
			{
				string line = lines[lineIndex];
				if (line.Contains(command))
				{
					return true;
				}
			}
			return false;
		}



	}
}
