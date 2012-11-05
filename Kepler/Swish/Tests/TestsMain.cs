using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swish.Tests
{
	public class TestsMain
	{
		public static bool _TestsRun { get; set; }
		public bool TestsRun { get { return _TestsRun; } set { _TestsRun = value; } }
		public static Exception _LastError { get; set; }
		public Exception LastError { get { return _LastError; } set { _LastError = value; } }

		public Exception Run()
		{
			if (TestsRun)
			{
				return LastError;
			}
			try
			{
				//new ThreadedFileProcessorTests().RunResetRun();

				LastError = null;
				return null;
			} catch (Exception error)
			{
				LastError = error;
				return error;
			} finally
			{
				TestsRun = true;
			}
		}
	}
}
