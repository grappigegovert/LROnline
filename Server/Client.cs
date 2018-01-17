using System.Net;
using System.Net.Sockets;
using Shared;

namespace Server
{
	class Client
	{
		private TcpClient tcpclient;
		private UdpClient udpclient;
		public int Index = -1;
		public bool Connected = true;
		private string ip;

		public Client(TcpClient tcpclient)
		{
			this.tcpclient = tcpclient;
		}

		public string IP
		{
			get
			{
				if (ip == null)
					ip = ((IPEndPoint)tcpclient.Client.RemoteEndPoint).Address.ToString();
				return ip;
			}
		}

		public void SetIndex(int playerIndex)
		{
			ServerForm.Log("Assigning id " + playerIndex + " to " + IP);
			new MessageSetPlayerIndex((byte)playerIndex).Send(tcpclient);
			this.Index = playerIndex;
		}

		public void Disconnect()
		{
			ServerForm.Log("Disconnecting " + IP);
			new MessageDisconnect().Send(tcpclient);
			tcpclient.Close();
		}

		public void StartListening()
		{
			TcpReceiver receiver = new TcpReceiver(tcpclient, Server.instance.HandleMessage, this);
			tcpclient.Client.BeginReceive(receiver.buffer, 0, receiver.buffer.Length, SocketFlags.None, TcpReceiver.ReadCallback, receiver);
		}
	}
}
