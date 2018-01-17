namespace Shared
{
	public class MessageDisconnect : Message
	{
		public MessageDisconnect()
		{
			this.type = MessageType.Disconnect;
			this.messageLength = base.messageLength;
		}
	}
}
