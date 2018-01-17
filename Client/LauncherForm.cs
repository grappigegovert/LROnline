using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Client
{
	public partial class LauncherForm : Form
	{
		public LauncherForm()
		{
			InitializeComponent();
			this.AcceptButton = launchButton;
		}

		private void launchButton_Click(object sender, EventArgs e)
		{
			IPAddress ip;
			if (IPAddress.TryParse(ipTextBox.Text, out ip))
			{
				ClientForm clientform = new ClientForm(ip, (int)numericUpDown1.Value);
				clientform.FormClosed += clientform_FormClosed;
				this.Hide();
				clientform.Show();
				clientform.Connect();
			}
			else
			{
				MessageBox.Show("Please specify a valid IP address.", "Error");
			}
		}

		void clientform_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Show();
		}
	}
}
