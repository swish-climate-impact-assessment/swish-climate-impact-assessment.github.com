using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.CSharp;

namespace LibraryTypes.BootStrap
{
	static class CSharpCompiler
	{
		private static string directoryBase = Path.GetTempFileName() + "_dir";
		private static int directoryBaseCount = 0;

		internal static string MakeExecutable(string code)
		{
			string codeDirectory = directoryBase + directoryBaseCount.ToString();
			directoryBaseCount++;
			Directory.CreateDirectory(codeDirectory);
			File.WriteAllText(Path.Combine(codeDirectory, "Program.cs"), code);

			string exeName = Path.Combine(codeDirectory, "Program.exe");

			_Compile(codeDirectory, exeName, false);
			return exeName;
		}

		private static void AddCodeDirectory(string codeDirectory, List<string> sourceFiles)
		{
			string[] files = Directory.GetFiles(codeDirectory);

			foreach (string codeFile in files)
			{
				if (Path.GetExtension(codeFile) == ".cs")
				{
					sourceFiles.Add(codeFile);
				}
			}

			string[] directories = Directory.GetDirectories(codeDirectory);
			foreach (string codeDirectoryItem in directories)
			{
				//			if(codeDirectoryItem.Contains(".svn"))
				//			{
				//				continue;
				//			}
				AddCodeDirectory(codeDirectoryItem, sourceFiles);
			}
		}

		private static Assembly _Compile(string codeDirectory, string outputFileName, bool generateInMemory)
		{
			List<string> dllFileNames = new List<string>(new string[]{
				Assembly.GetAssembly(typeof(_AppDomain)).Location,
				Assembly.GetAssembly(typeof(FileStyleUriParser)).Location,
	//			Assembly.GetAssembly(typeof(ConformanceLevel)).Location,
				Assembly.GetAssembly(typeof(EventSchemaTraceListener)).Location,
				Assembly.GetAssembly(typeof(Bitmap)).Location,
				Assembly.GetAssembly(typeof(AccessibleEvents)).Location,
				Assembly.GetAssembly(typeof(TimeZoneInfo)).Location,
				Assembly.GetAssembly(typeof(System.Data.ConstraintCollection)).Location,
			});

			List<string> output = new List<string>();

			List<string> sourceFiles = new List<string>();
			AddCodeDirectory(codeDirectory, sourceFiles);
			if (sourceFiles.Count == 0)
			{
				throw new Exception("No code files found");
			}

			CompilerParameters options = new CompilerParameters();
			CSharpCodeProvider provider = new CSharpCodeProvider();

			options.IncludeDebugInformation = false;
			options.CompilerOptions = "/optimize /unsafe+ /target:winexe";
			options.WarningLevel = 0;
			options.TreatWarningsAsErrors = false;

			//		if (!outputFileName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
			//		{
			//			throw new Exception("library file name must end with \".dll\"");
			//		}
			if (!generateInMemory)
			{
				options.OutputAssembly = outputFileName;
			}

			options.GenerateExecutable = true;
			options.GenerateInMemory = generateInMemory;

			options.ReferencedAssemblies.AddRange(dllFileNames.ToArray());

			CompilerResults results = provider.CompileAssemblyFromFile(options, sourceFiles.ToArray());
			bool flag = true;
			string message = string.Empty;

			foreach (CompilerError error in results.Errors)
			{
				if (error.IsWarning)
				{
					message += string.Concat(new object[] { "Warning: ", error.ErrorText, " (", error.Line, ":", error.Column, ")" }) + Environment.NewLine;
				} else
				{
					message += string.Concat(new object[] { "Error: ", error.ErrorText, " (", error.Line, ":", error.Column, ")" }) + Environment.NewLine;
					flag = false;
				}
			}

			if (results.Errors.HasErrors || !flag)
			{
				throw new Exception("Build failed." + Environment.NewLine + message);
			}

			return results.CompiledAssembly;
		}
	}
}

