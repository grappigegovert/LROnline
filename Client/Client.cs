using System;
using Shared;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Message = Shared.Message;

namespace Client
{
	class Client
	{
		private TcpClient tcpclient;
		private Thread clientthread;
		private IPAddress ip;
		private int port;
		private int playerIndex;
		private ClientForm form;
		public ClientStatus status;

		public Client(IPAddress ip, int port, ClientForm form)
		{
			this.ip = ip;
			this.port = port;
			this.form = form;
			this.status = ClientStatus.NotConnected;
		}

		public void Connect()
		{
			clientthread = new Thread(connectfunc);
			clientthread.Start();
		}

		public void Disconnect()
		{
			new MessageDisconnect().Send(tcpclient);
			tcpclient.Close();
		}

		private void connectfunc()
		{
			this.status = ClientStatus.Connecting;
			DialogResult dialogresult;
			do
			{
				dialogresult = DialogResult.Yes;
				try
				{
					tcpclient = new TcpClient();
					tcpclient.Connect(ip, port);
				}
				catch (SocketException e)
				{
					if (e.NativeErrorCode == 10051)
					{
						dialogresult = MessageBox.Show("No route to server.", "Error", MessageBoxButtons.RetryCancel);
					}
					else if (e.NativeErrorCode == 10061)
					{
						dialogresult = MessageBox.Show("No server is running on that IP/port combination.", "Error", MessageBoxButtons.RetryCancel);
					}
					else if (e.NativeErrorCode == 10060)
					{
						dialogresult = MessageBox.Show("Connection timed out; The server didn't respond in time.", "Error", MessageBoxButtons.RetryCancel);
					}
					else
					{
						throw;
					}
					tcpclient.Close();
				}
			} while (dialogresult == DialogResult.Retry);
			if (dialogresult == DialogResult.Cancel)
				form.End();
			form.SetStatus("TCP Connected");
			this.status = ClientStatus.TCPConnected;
			TcpReceiver receiver = new TcpReceiver(tcpclient, HandleMessage);
			tcpclient.Client.BeginReceive(receiver.buffer, 0, receiver.buffer.Length, SocketFlags.None, TcpReceiver.ReadCallback, receiver);
		}

		public void HandleMessage(Message m, object tag)
		{
			switch (m.type)
			{
				case MessageType.Disconnect:
					this.status = ClientStatus.NotConnected;
					form.SetStatus("Disconnected.");
					tcpclient.Close();
					break;
				case MessageType.SetPlayerIndex:
					playerIndex = ((MessageSetPlayerIndex)m).playerIndex;
					form.SetPlayerIndex(playerIndex);
					break;
			}
		}
	}
}
