using System;

using KoalaTeam.Chillin.Client.Helpers;
using KoalaTeam.Chillin.Client.Helpers.Messages;

namespace KoalaTeam.Chillin.Client
{
	public class BaseAI<TWorld, TCommand> : AbstractAI
	{
		protected TWorld World { get; private set; }

		public BaseAI(TWorld world)
		{
			World = world;
		}

		public override void Update(BaseSnapshot snapshot)
		{
			((dynamic)World).Deserialize(Parser.GetBytes(snapshot.WorldPayload));
		}

		public override bool AllowedToDecide()
		{
			return true;
		}


		protected virtual void SendCommandInternal(TCommand command, BaseCommand msg = null)
		{
			BaseCommand message;
			if (msg == null)
				message = new BaseCommand();
			else
				message = (BaseCommand)msg;

			message.Type = ((dynamic)command).Name();
			message.Payload = Parser.GetString(((dynamic)command).Serialize());
			commandSendQueue.Add(message);
		}

		public void SendCommand(TCommand command)
		{
			if (AllowedToDecide())
				SendCommandInternal(command);
		}
	}
}
