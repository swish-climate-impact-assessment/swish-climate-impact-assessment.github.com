using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Swish.Tests
{
	class MergeAdapterTests
	{
		internal void MergeSorted()
		{

			/// this verifies that both tables used in a merge operation are sorted first
			/// evently this is important
			/// 
			/// 
			 string inputFileName1;string inputFileName2;
			StataFunctionsTests.GenerateMergeInputFiles(out  inputFileName1, out  inputFileName2);

			string outputFileName= Path.GetTempFileName();
			if (File.Exists(outputFileName))
			{
				File.Delete(outputFileName);
			}
List<string>variables = new  x
			StataFunctions.Merge(inputFileName1, inputFileName2, new () , outputFileName);

			throw new NotImplementedException();
		}
	}
}
