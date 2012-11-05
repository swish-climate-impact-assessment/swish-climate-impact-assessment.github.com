using System;
using System.Windows.Forms;

namespace Swish.SimpleInstaller.Controls
{
	public partial class InstallerMain: Form
	{
		public InstallerMain()
		{
			InitializeComponent();

		}

		private void welcomePage1_Cancel(object sender, EventArgs e)
		{
			Close();
		}

		private void welcomePage1_Install(object sender, EventArgs e)
		{
			Controls.Clear();
			progressPage1.Dock = DockStyle.Fill;
			Controls.Add(progressPage1);
			progressPage1.Install();
		}

		private void progressPage1_Next(object sender, EventArgs e)
		{
			Controls.Clear();
			finishedPage1.Dock = DockStyle.Fill;
			Controls.Add(finishedPage1);
		}

		private void finishedPage1_Exit(object sender, EventArgs e)
		{
			Close();
		}

		private void InstallerMain_Load(object sender, EventArgs e)
		{
			Controls.Clear();
			welcomePage1.Dock = DockStyle.Fill;
			Controls.Add(welcomePage1);
		}
	}
}
