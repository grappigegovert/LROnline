using System.Collections.Generic;

namespace Shared
{
	public class MessageSetPlayerIndex : Message
	{
		public byte playerIndex;

		public MessageSetPlayerIndex(byte playerIndex)
		{
			this.type = MessageType.SetPlayerIndex;
			this.messageLength = (byte)(base.messageLength + 1);
			this.playerIndex = playerIndex;
		}

		public new static MessageSetPlayerIndex fromBytes(byte[] bytes, int index)
		{
			return new MessageSetPlayerIndex(bytes[index]);
		}

		public override List<byte> toBytes()
		{
			List<byte> bytes = base.toBytes();
			bytes.Add(playerIndex);
			return bytes;
		}
	}
}
