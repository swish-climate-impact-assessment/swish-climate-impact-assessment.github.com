using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Swish.SimpleInstaller
{
	internal static class InstallFunctions
	{

		internal delegate void ReportProgressFunction(int progress, string line);

		internal static void Install(ReportProgressFunction ReportProgress)
		{
			List<string> _pending = new List<string>(File.ReadLines("Install.txt"));
			List<string> _completed = new List<string>();

			if (ReportProgress != null)
			{
				ReportProgress(0, "");
			}

			while (_pending.Count > 0)
			{
				string line = _pending[0];

				_completed.Add(line);
				_pending.RemoveAt(0);

				RunLine(line);

				if (ReportProgress != null)
				{
					ReportProgress(100 * (_completed.Count) / (_completed.Count + _pending.Count), line);
				}
			}
		}


		internal static void RunLine(string _line)
		{
			string useLine = _line;

			useLine = useLine.Replace("%UserProfile%", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
			useLine = useLine.Replace("%StartupPath%", Application.StartupPath);

			string whiteSpace;
			StringIO.SkipWhiteSpace(out whiteSpace, ref useLine);
			if (StringIO.TryRead("CopyFiles", ref useLine))
			{
				string sourceDirectory;
				StringIO.SkipWhiteSpace(out whiteSpace, ref useLine);
				if (!StringIO.TryReadString(out sourceDirectory, ref useLine))
				{
					throw new Exception("could not read line \"" + _line + "\"");
				}

				string destinationDirectory;
				StringIO.SkipWhiteSpace(out whiteSpace, ref useLine);
				if (!StringIO.TryReadString(out destinationDirectory, ref useLine))
				{
					throw new Exception("could not read line \"" + _line + "\"");
				}

				string[] files = Directory.GetFiles(sourceDirectory, "*");
				for (int fileIndex = 0; fileIndex < files.Length; fileIndex++)
				{
					string sourceFileName = files[fileIndex];
					string fileName = Path.GetFileName(sourceFileName);
					string destinationFileName = Path.Combine(destinationDirectory, fileName);

					CopyFile(sourceFileName, destinationFileName);
				}
			} else
				if (StringIO.TryRead("Copy", ref useLine))
				{
					StringIO.SkipWhiteSpace(out whiteSpace, ref useLine);

					string sourceFileName;
					if (!StringIO.TryReadString(out sourceFileName, ref useLine))
					{
						throw new Exception("could not read line \"" + _line + "\"");
					}

					string destinationFileName;
					StringIO.SkipWhiteSpace(out whiteSpace, ref useLine);
					if (!StringIO.TryReadString(out destinationFileName, ref useLine))
					{
						throw new Exception("could not read line \"" + _line + "\"");
					}

					CopyFile(sourceFileName, destinationFileName);
				} else if (string.IsNullOrWhiteSpace(useLine) || StringIO.TryRead("//", ref useLine))
				{
					// do nothing
				} else
				{
					throw new Exception("could not read line \"" + _line + "\"");
				}
		}

		private static void CopyFile(string sourceFileName, string destinationFileName)
		{
			string destinationDirectory = Path.GetDirectoryName(destinationFileName);
			CreateDirectory(destinationDirectory);
			if (File.Exists(destinationFileName))
			{
				File.Delete(destinationFileName);
			}
			File.Copy(sourceFileName, destinationFileName);
		}

		private static void CreateDirectory(string directory)
		{
			if (Directory.Exists(directory))
			{
				return;
			}

			string baseDirectory = Path.GetDirectoryName(directory);
			CreateDirectory(baseDirectory);

			Directory.CreateDirectory(directory);
		}

	}
}
