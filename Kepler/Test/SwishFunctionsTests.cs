using System;
using System.Collections.Generic;
using System.IO;

namespace Swish.Tests
{
	class SwishFunctionsTests
	{
		internal void TestRunBatchMode()
		{
			/// this tests that the executable run is Stata, 
			/// and that the arguments are correct
			/// 

			/// test works by creating a fake Stata and testing the arguments
			/// make a fake Stata

			// "C:\Program Files\Stata12\StataMP" /e do c:\data\bigjob.do
			string argumentsFileName = "ArgumentsOut.txt";
			string executableFileName = LibraryTypes.BootStrap.CSharpCompiler.MakeExecutable("class Program{static void Main(string[] arguments){System.IO.File.WriteAllText(\"" + argumentsFileName + "\", string.Join(\" \", arguments));}}");

			string directory = Path.GetTempPath();
			List<string> lines = new List<string>();

			argumentsFileName = Path.Combine(directory, argumentsFileName);
			string expectedArguments = StataFunctions.BatchArgument;
			try
			{
				StataFunctions.StataExecutablePath = executableFileName;
				StataFunctions.RunScript(lines, false);

				string arguments = File.ReadAllText(argumentsFileName);
				if (!arguments.StartsWith(expectedArguments))
				{
					throw new Exception();
				}
			} finally
			{
				StataFunctions.StataExecutablePath = null;
			}
		}


	}
}
