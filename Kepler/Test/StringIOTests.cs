using System;

namespace Swish.Tests
{
	class StringIOTests
	{
		internal void TryReadStringEscapedCharacters()
		{
			string expectedString = " \" \\ \r \n \' \t ";

			string stringLine = "\" \\\" \\\\ \\r \\n \\\' \\t \"";

			string readString;
			if (!StringIO.TryReadString(out readString, ref stringLine))
			{
				throw new Exception();
			}

			if (readString != expectedString)
			{
				throw new Exception();
			}
		}
	}
}
