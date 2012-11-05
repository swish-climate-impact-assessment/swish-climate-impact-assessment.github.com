using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Swish.Tests
{
	class TestsMain
	{
		[DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);

		private static bool Is64Bit(Process process)
		{
			if ((Environment.OSVersion.Version.Major > 5) || ((Environment.OSVersion.Version.Major == 5) && (Environment.OSVersion.Version.Minor >= 1)))
			{
				IntPtr processHandle;
				bool retVal;

				try
				{
					processHandle = Process.GetProcessById(process.Id).Handle;
				} catch
				{
					return false; // access is denied to the process
				}

				return IsWow64Process(processHandle, out retVal) && retVal;
			}

			return false; // not on 64-bit Windows
		}

		static void Main(string[] arguments)
		{
			try
			{
				new MergeAdapterTests().MergeSorted();
				new StataFunctionsTests().StataBatchMode();
				new ArgumentFunctionsTests().GetSwitch();
				new SwishFunctionsTests().TestRunBatchMode();
				new StringIOTests().TryReadStringEscapedCharacters();
				new ArgumentFunctionsTests().ArgumentInQuotes();
				new CommandAdapterTests().CommandScript();



			} catch (Exception error)
			{
				Console.WriteLine(ExceptionFunctions.WriteException(error, false));
			}


			/// 
			/// to drop variables 
			/// drop varlist
			/// 
			/// to set the current working directory
			/// cd "C:\Users\kurt\Documents"
			/// 
			/// "generate creates a new variable 
			/// generate gnppc2 = gnppc^ 2
			/// 
			/// 
			/// To run Stata in batch mode us 
			///    "C:\Program Files\Stata12\StataMP" /e do c:\data\bigjob.do
			/// a log will be saved in the working directory
			/// the log will have the same name as the do file eg bigjob.log
			/// 
			/// 
			/// 
			/// 
			/// 
			/// 
			/// 
			/// 


		}
	}
}




