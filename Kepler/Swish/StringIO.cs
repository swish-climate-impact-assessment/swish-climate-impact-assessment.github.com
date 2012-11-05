
namespace Swish
{
	public static class StringIO
	{
		public static bool TryRead(string search, ref string line)
		{
			if (!line.StartsWith(search))
			{
				return false;
			}

			line = line.Substring(search.Length);
			return true;
		}

		public static void SkipWhiteSpace(out string buffer, ref string line)
		{
			string line2 = line.TrimStart();
			buffer = line.Substring(0, line.Length - line2.Length);
			line = line2;
		}

		public static bool TryReadString(out string buffer, ref string line)
		{
			string useLine = line;
			if (!TryRead("\"", ref useLine))
			{
				buffer = null;
				return false;
			}

			string useBuffer = string.Empty;
			string subBuffer;
			while (true)
			{
				if (useLine.Length == 0)
				{
					buffer = null;
					return false;
				}

				if (TryRead("\"", ref useLine))
				{
					break;
				}

				if (TryRead("\\", ref useLine))
				{
					if (useLine.Length == 0)
					{
						buffer = null;
						return false;
					}

					char character = useLine[0];
					useLine = useLine.Substring(1);

					switch (character)
					{
					case '{':
					case '/':
					case '}':
					case '\"':
					case '\'':
					case '\\':
					case '=':
						useBuffer += character;
						break;

					case 'r':
						useBuffer += '\r';
						break;

					case 'n':
						useBuffer += '\n';
						break;

					case 't':
						useBuffer += '\t';
						break;

					default:
						useBuffer += '\\';
						useBuffer += character;
						break;
					}
					continue;
				}

				string stopString;
				if (!TryReadUntill(out subBuffer, out stopString, new string[] { "\"", "\\" }, ref useLine))
				{
					buffer = null;
					return false;
				}

				useBuffer += subBuffer;
			}

			buffer = useBuffer;
			line = useLine;
			return true;
		}

		public static bool TryReadUntill(out string buffer, out string stopString, string[] stopStrings, ref string line)
		{
			int minimumCharIndex = int.MaxValue;
			string minimumStopString = null;
			for (int stopIndex = 0; stopIndex < stopStrings.Length; stopIndex++)
			{
				string testStopString = stopStrings[stopIndex];

				int charIndex = line.IndexOf(testStopString);
				if (charIndex >=0 && (
					(charIndex < minimumCharIndex) ||
					(charIndex == minimumCharIndex && testStopString.Length > minimumStopString.Length)
					))
				{
					minimumCharIndex = charIndex;
					minimumStopString = testStopString;
				}
			}

			if (minimumStopString == null)
			{
				buffer = null;
				stopString = null;
				return false;
			}

			buffer = line.Substring(0, minimumCharIndex);
			stopString = minimumStopString;
			line = line.Substring(minimumCharIndex);
			return true;
		}

	}
}
