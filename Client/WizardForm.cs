using LEGORacersAPI;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
	public partial class WizardForm : Form
	{
		private string gameClientDirectory;
		private bool switching = false;
		private string md5;
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardForm));

		public WizardForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Tries to identify the game client version.
		/// </summary>
		/// <param name="process"></param>
		private void Identify(Process process)
		{
			GameClient gameClient = GameClientFactory.GetGameClient(process, false);

			if (gameClient != null)
			{
				lblStatus.Text = "You were successfully identified as:" + Environment.NewLine + gameClient.FormattedName;
				label1.Text = resources.GetString("lblIntroContent.Text");
				radioButton1.Visible = radioButton2.Visible = false;
			}
			else
			{
				md5 = LEGORacersAPI.Toolbox.GetMD5Hash(process.MainModule.FileName);
				lblStatus.Text = "Your game could not be identified.";
				label1.Text = Resources.Resource1.checkfail;
				radioButton1.Visible = radioButton2.Visible = true;
			}
			gameClientDirectory = Path.GetDirectoryName(process.MainModule.FileName);
			btnNext.Enabled = true;
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			switching = true;
			tabControl1.SelectedIndex = 1;
			timer.Enabled = true;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			Process[] processess = Process.GetProcessesByName("LEGORacers");

			if (processess.Any())
			{
				timer.Enabled = false;

				Process gameClient = processess[0];

				Identify(gameClient);

				gameClient.Kill();
			}
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			switching = true;
			tabControl1.SelectedIndex = 2;
		}

		private void btnFinish_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.ForceVersion = "Auto";
			if (radioButton1.Visible)
			{
				Properties.Settings.Default.ForceVersion = "Invalid";
				if (radioButton1.Checked)
					Properties.Settings.Default.ForceVersion = "2001";
				else if (radioButton2.Checked)
					Properties.Settings.Default.ForceVersion = "1999-nodrm";
				else
					Close();
			}
			Properties.Settings.Default.GameClientDirectory = gameClientDirectory;
			Properties.Settings.Default.Save();

			LauncherForm launcher = new LauncherForm();
			launcher.FormClosed += (s, args) => Close();
			launcher.Show();

			Hide();
		}

		private void WizardForm_Load(object sender, EventArgs e)
		{
			if (!Toolbox.IsAdministrator())
			{
				MessageBox.Show("Please restart the application with Administrator rights.", "Error");

				Close();
			}
		}

		private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
		{
#if DEBUG
			switching = true;
#endif
			if (!switching)
				e.Cancel = true;
			else
				switching = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(md5);
		}
	}
}