using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Shared
{
	public class TcpReceiver
	{
		private TcpClient tcpclient;
		private Action<Message, object> handlePacket;
		public object Tag;
		public byte[] buffer = new byte[1024];

		public TcpReceiver(TcpClient tcpclient, Action<Message, object> packethandler, object tag = null)
		{
			this.tcpclient = tcpclient;
			this.handlePacket = packethandler;
			this.Tag = tag;
		}

		public static void ReadCallback(IAsyncResult ar)
		{
			TcpReceiver state = (TcpReceiver)ar.AsyncState;
			int bytesread = -1;
			try
			{
				bytesread = state.tcpclient.Client.EndReceive(ar);
			}
			catch (Exception e)
			{
				if (e is NullReferenceException || e is ObjectDisposedException)
					return; // OwO?
			}
			int index = 0;
			while (index < bytesread)
			{
				byte packetlength = state.buffer[index];
				if (packetlength > bytesread - index - 1)
				{
					int alreadyreceived = bytesread - index;
					Array.Copy(state.buffer, index, state.buffer, 0, alreadyreceived);
					state.tcpclient.Client.BeginReceive(state.buffer, alreadyreceived, state.buffer.Length - alreadyreceived, SocketFlags.None, ReadCallback, state);
				}
				Message p = Message.fromBytes(state.buffer, index + 1);
				state.handlePacket(p, state.Tag);
				if (p is MessageDisconnect)
					return;
				index += packetlength + 1;
			}
			state.tcpclient.Client.BeginReceive(state.buffer, 0, state.buffer.Length, SocketFlags.None, ReadCallback, state);
		}
	}
}
