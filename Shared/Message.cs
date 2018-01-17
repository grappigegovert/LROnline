using System.Collections.Generic;
using System.Net.Sockets;

namespace Shared
{
	public abstract class Message
	{
		public MessageType type;
		public byte messageLength = 1;

		public static Message fromBytes(byte[] bytes, int offset)
		{
			MessageType type = (MessageType)bytes[offset];
			switch (type)
			{
				case MessageType.Disconnect:
					return new MessageDisconnect();
				case MessageType.SetPlayerIndex:
					return MessageSetPlayerIndex.fromBytes(bytes, offset + 1);
			}
			return null;
		}

		public virtual List<byte> toBytes()
		{
			return new List<byte> {messageLength, (byte)type};
		}

		public void Send(TcpClient tcpclient)
		{
			tcpclient.Client.Send(this.toBytes().ToArray());
		}
	}
}
