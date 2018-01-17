using System;
using System.Windows.Forms;

namespace Server
{
	public partial class ServerForm : Form
	{
		private readonly Server server;
		private static ServerForm instance;

		public ServerForm()
		{
			instance = this;
			InitializeComponent();
			this.server = new Server(this);
			numericUpDown1.Value = Server.DefaultPort;
		}

		public static void Log(string text, bool newline = true)
		{
			instance.log(text, newline);
		}

		private void log(string text, bool newline = true)
		{
			text = "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + text;
			InvokeIfRequired(textBox1, () => textBox1.AppendText(text + (newline ? Environment.NewLine : "")));
		}

		private void startbutton_Click(object sender, EventArgs e)
		{
			if (!server.Running)
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

		private static void InvokeIfRequired(Control control, MethodInvoker action)
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
			if (server.Running)
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
