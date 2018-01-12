using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
	class Server
	{
		public const int DefaultPort = 31425;
		private TcpListener tcplistener;
		private Thread tcpservthread;
		public bool running = false;
		private List<Client> clients = new List<Client>();
		private ServerForm form;

		public Server(ServerForm form)
		{
			this.form = form;
		}

		public void StartServer(int port)
		{
			form.Log("Starting server on port " + port + "...");
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
			(tcpservthread = new Thread(tcpserver)).Start();
		}

		public void StopServer()
		{
			form.Log("Stopping server...");
			running = false;
			tcplistener.Stop();
			SpinWait.SpinUntil(() => !tcpservthread.IsAlive, 500);
			if (tcpservthread.IsAlive)
			{
				form.Log("Forcing stop...");
				tcpservthread.Abort();
			}
			form.Log("Server stopped.");
			tcpservthread = null;
			tcplistener = null;
		}

		private void tcpserver()
		{
			form.Log("Server started!");
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
	}
}
