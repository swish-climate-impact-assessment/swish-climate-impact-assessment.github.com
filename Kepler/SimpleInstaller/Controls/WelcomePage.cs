using System;
using System.Windows.Forms;

namespace Swish.SimpleInstaller.Controls
{
	public partial class WelcomePage: UserControl
	{
		public WelcomePage()
		{
			InitializeComponent();
		}

		public event EventHandler Install;
		public event EventHandler Cancel;

		private void InstallButton_Click(object sender, EventArgs e)
		{
			if (Install != null)
			{
				Install(this, EventArgs.Empty);
			}
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			if (Cancel != null)
			{
				Cancel(this, EventArgs.Empty);
			}
		}

	}
}
