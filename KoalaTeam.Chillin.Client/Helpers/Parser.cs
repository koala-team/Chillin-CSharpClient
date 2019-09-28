using System;
using System.Collections.Generic;
using System.Text;

using KoalaTeam.Chillin.Client.Helpers.Messages;

namespace KoalaTeam.Chillin.Client.Helpers
{
	public class Parser
	{
		public Parser() { }

		public byte[] Encode(KSObject payloadObj)
		{
			var msg = new Message();
			msg.Type = payloadObj.Name();
			msg.Payload = GetString(payloadObj.Serialize());
			return msg.Serialize();
		}

		public KSObject Decode(byte[] data)
		{
			KSObject resultMsg;
			var msg = new Message();
			msg.Deserialize(data);

			resultMsg = MessageFactory.GetInstance().GetMessage(msg.Type);
			resultMsg.Deserialize(GetBytes(msg.Payload));
			return resultMsg;
		}

		public static byte[] GetBytes(string @string)
		{
			return Encoding.GetEncoding("ISO-8859-1").GetBytes(@string);
		}

		public static string GetString(byte[] bytes)
		{
			return Encoding.GetEncoding("ISO-8859-1").GetString(bytes);
		}
	}

	internal sealed class MessageFactory
	{
		private static MessageFactory instance = null;

		private readonly IDictionary<string, KSObject> installedMessages;

		private MessageFactory()
		{
			installedMessages = new Dictionary<string, KSObject>();
			LoadMessages();
		}

		internal static MessageFactory GetInstance()
		{
			if (instance == null)
				instance = new MessageFactory();
			return instance;
		}

		private void LoadMessages()
		{
			RegisterMessage(new AgentJoined());
			RegisterMessage(new AgentLeft());
			RegisterMessage(new BaseCommand());
			RegisterMessage(new BaseSnapshot());
			RegisterMessage(new ClientJoined());
			RegisterMessage(new EndGame());
			RegisterMessage(new JoinOfflineGame());
			RegisterMessage(new JoinOnlineGame());
			RegisterMessage(new Message());
			RegisterMessage(new RealtimeCommand());
			RegisterMessage(new RealtimeSnapshot());
			RegisterMessage(new StartGame());
			RegisterMessage(new TurnbasedCommand());
			RegisterMessage(new TurnbasedSnapshot());
		}

		private void RegisterMessage(KSObject obj)
		{
			installedMessages.Add(obj.Name(), obj);
		}

		internal KSObject GetMessage(string messageName)
		{
			try
			{
				return (KSObject)Activator.CreateInstance(installedMessages[messageName].GetType());
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
			return null;
		}
	}
}
