using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace Swish.SimpleInstaller.Controls
{
	public partial class ProgressPage: UserControl
	{
		public ProgressPage()
		{
			InitializeComponent();

		}
		public event EventHandler Next;

		private void NextButton_Click(object sender, EventArgs e)
		{
			if (Next != null)
			{
				Next(this, EventArgs.Empty);
			}
		}

		List<string> completedLines = new List<string>();
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				completedLines.Clear();
				backgroundWorker1.ReportProgress(0);

				InstallFunctions.Install(ReportProgress);

				backgroundWorker1.ReportProgress(100);
			} catch (Exception error)
			{
				string message = ArgumentFunctions.ErrorArgument + " " + ExceptionFunctions.WriteException(error, true);
				MessageBox.Show(message);
				Console.Write(message);
				return;
			}
		}

		private void ReportProgress(int progress, string line)
		{
			backgroundWorker1.ReportProgress(progress);
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			CompleteBox.Lines = completedLines.ToArray();
			ProgressBar.Value = e.ProgressPercentage;
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			NextButton.Enabled = true;
		}


		internal void Install()
		{
			backgroundWorker1.RunWorkerAsync();
		}
	}
}



