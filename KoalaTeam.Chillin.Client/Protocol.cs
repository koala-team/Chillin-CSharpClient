using System;

using KoalaTeam.Chillin.Client.Helpers;

namespace KoalaTeam.Chillin.Client
{
	public class Protocol
	{
		private readonly Network network;
		private readonly Parser parser;

		public Protocol(Network network)
		{
			this.network = network;
			this.parser = new Parser();
		}

		public KSObject RecvMessage()
		{
			var data = network.RecvData();
			if (data == null || data.Length == 0)
				return null;
			KSObject msg = parser.Decode(data);
			return msg;
		}

		public void SendMessage(KSObject msg)
		{
			var data = parser.Encode(msg);
			network.SendData(data);
		}
	}
}
