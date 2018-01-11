using System;
using System.Windows.Forms;
using Client.Properties;

namespace Client
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            txtDefaultNickname.Text = Settings.Default.Nickname;
            txtDefaultServerAddress.Text = Settings.Default.Server;
            nrDefaultPort.Value = Settings.Default.Port;
            chkWindowedMode.Checked = Settings.Default.WindowMode;
            chkSkipIntroVideo.Checked = Settings.Default.SkipIntroVideo;
            chkOverwriteDefaults.Checked = Settings.Default.OverwriteDefaults;
            txtArguments.Text = Settings.Default.Arguments;
            switch (Settings.Default.ForceVersion)
            {
                case "2001":
                    cmbGameVer.SelectedIndex = 2;
                    break;
                case "1999-nodrm":
                    cmbGameVer.SelectedIndex = 1;
                    break;
                default:
                    cmbGameVer.SelectedIndex = 0;
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.Nickname = txtDefaultNickname.Text;
            Settings.Default.Server = txtDefaultServerAddress.Text;
            Settings.Default.Port = (int)nrDefaultPort.Value;
            Settings.Default.WindowMode = chkWindowedMode.Checked;
            Settings.Default.SkipIntroVideo = chkSkipIntroVideo.Checked;
            Settings.Default.OverwriteDefaults = chkOverwriteDefaults.Checked;
            Settings.Default.Arguments = txtArguments.Text;
            switch (cmbGameVer.SelectedIndex)
            {
                case 2:
                    Settings.Default.ForceVersion = "2001";
                    break;
                case 1:
                    Settings.Default.ForceVersion = "1999-nodrm";
                    break;
                default:
                    Settings.Default.ForceVersion = "Auto";
                    break;
            }


            Settings.Default.Save();

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lnkResetSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("If you would like to restore to the original settings, you can reset them here. Please note that you will have you identify your installation again after restarting. The application will restart after resetting the settings.", "Reset settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Settings.Default.Reset();

                Application.Restart();
            }
        }
    }
}