using System;
using System.Windows.Forms;

namespace Server
{
	public partial class ServerForm : Form
	{
		private Server server;

		public ServerForm()
		{
			InitializeComponent();
			this.server = new Server(this);
			numericUpDown1.Value = Server.DefaultPort;
		}

		public void Log(string text, bool newline = true)
		{
			text = "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + text;
			InvokeIfRequired(textBox1, () => textBox1.AppendText(text + (newline ? Environment.NewLine : "")));
		}

		private void startbutton_Click(object sender, EventArgs e)
		{
			if (!server.running)
			{
				startbutton.Enabled = false;
				server.StartServer((int)numericUpDown1.Value);
				startbutton.Text = "Stop server";
				statuslabel.Text = "running";
				startbutton.Enabled = true;
			}
			else
			{
				startbutton.Enabled = false;
				server.StopServer();
				startbutton.Text = "Start server";
				statuslabel.Text = "not running";
				startbutton.Enabled = true;
			}
		}

		public static void InvokeIfRequired(Control control, MethodInvoker action)
		{
			if (control.InvokeRequired)
			{
				control.Invoke(action);
			}
			else
			{
				action();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			numericUpDown1.Value = Server.DefaultPort;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (server.running)
			{
				startbutton.Enabled = false;
				server.StopServer();
				startbutton.Text = "Start server";
				statuslabel.Text = "not running";
				startbutton.Enabled = true;
			}
		}
	}
}
