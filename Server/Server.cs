using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Shared;
using Message = Shared.Message;

namespace Server
{
	class Server
	{
		public static Server instance;
		public const int DefaultPort = 31425;
		private TcpListener tcplistener;
		private Thread tcpservthread;
		public bool Running = false;
		private List<Client> clients = new List<Client>();
		private readonly ServerForm form;
		private bool inRace = false;

		public Server(ServerForm form)
		{
			this.form = form;
			instance = this;
		}

		public void StartServer(int port)
		{
			ServerForm.Log("Starting server on port " + port + "...");
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
			this.Running = true;
			(tcpservthread = new Thread(tcpserver)).Start();
		}

		public void StopServer()
		{
			ServerForm.Log("Disconnecting all clients...");
			clients.ForEach(c => c.Disconnect());
			clients.Clear();
			ServerForm.Log("Stopping server...");
			Running = false;
			tcplistener.Stop();
			SpinWait.SpinUntil(() => !tcpservthread.IsAlive, 500);
			if (tcpservthread.IsAlive)
			{
				ServerForm.Log("Forcing stop...");
				tcpservthread.Abort();
			}
			ServerForm.Log("Server stopped.");
			tcpservthread = null;
			tcplistener = null;
		}

		private void tcpserver()
		{
			ServerForm.Log("Server started!");
			while (Running)
			{
				if (clients.Count < 6)
					try
					{
						Client c = new Client(tcplistener.AcceptTcpClient());
						clients.Add(c);
						ServerForm.Log("Incoming connection from " + c.IP);
						c.StartListening();
						c.SetIndex(clients.Count - 1);
					}
					catch (SocketException) { } //server stopped probably
				else
					Thread.Sleep(1000);
			}
		}

		public void RemoveClient(Client c)
		{
			ServerForm.Log("Reassigning IDs...");
			this.clients.Remove(c);
			for (int i = 0; i < clients.Count; i++)
			{
				if (clients[i].Index != i)
					clients[i].SetIndex(i);
			}
		}

		public void HandleMessage(Message m, object tag)
		{
			Client c = (Client)tag;
			switch (m.type)
			{
				case MessageType.Disconnect:
					ServerForm.Log(c.IP + " has disconnected.");
					c.Connected = false;
					if (!inRace)
						RemoveClient(c);
					break;
			}
		}
	}
}
