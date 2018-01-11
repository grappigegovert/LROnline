using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
	public partial class Form1 : Form
	{
		public const int DefaultPort = 31425;
		private TcpListener tcplistener;
		private Thread tcpservthread;
		private bool running = false;
		private List<Client> clients = new List<Client>();

		public Form1()
		{
			InitializeComponent();
			numericUpDown1.Value = DefaultPort;
		}

		private void Log(string text, bool newline = true)
		{
			text = "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + text;
			InvokeIfRequired(textBox1, () => textBox1.AppendText(text + (newline ? Environment.NewLine : "")));
		}

		public void StartServer(int port)
		{
			startbutton.Enabled = false;
			Log("Starting server on port " + port + " ...");
			tcplistener = new TcpListener(IPAddress.Any, port);
			try
			{
				tcplistener.Start();
			}
			catch (SocketException e)
			{
				MessageBox.Show("The server cant start on port " + port + " due to this error:\n"
					+ e.ToString() + "\n\n Is the server already running? If it isn't, try using a different port.", "Error");
				return;
			}
			this.running = true;
			startbutton.Text = "Stop server";
			(tcpservthread = new Thread(tcpserver)).Start();
			statuslabel.Text = "running";
			startbutton.Enabled = true;
		}

		public void StopServer()
		{
			startbutton.Enabled = false;
			Log("Stopping server...");
			running = false;
			tcplistener.Stop();
			startbutton.Text = "Start server";
			SpinWait.SpinUntil(() => !tcpservthread.IsAlive, 500);
			if (tcpservthread.IsAlive)
			{
				Log("Forcing stop...");
				tcpservthread.Abort();
			}
			statuslabel.Text = "not running";
			Log("Server stopped.");
			tcpservthread = null;
			tcplistener = null;
			startbutton.Enabled = true;
		}

		private void tcpserver()
		{
			Log("Server started!");
			while (running)
			{
				if (clients.Count < 6)
					try
					{
						tcplistener.AcceptSocket();
					}
					catch (SocketException) { } //server stopped probably
				else
					Thread.Sleep(1000);
			}
			foreach (Client c in clients)
			{
				//disconnect or some shit
			}
		}

		private void startbutton_Click(object sender, EventArgs e)
		{
			if (!running)
			{
				StartServer((int)numericUpDown1.Value);
			}
			else
			{
				StopServer();
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
			numericUpDown1.Value = DefaultPort;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (running)
				StopServer();
		}
	}
}
