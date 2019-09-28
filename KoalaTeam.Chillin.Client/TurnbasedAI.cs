using System;
using System.Collections.Generic;

using KoalaTeam.Chillin.Client.Helpers.Messages;

namespace KoalaTeam.Chillin.Client
{
	public class TurnbasedAI<TWorld, TCommand> : RealtimeAI<TWorld, TCommand>
	{
		protected IList<string> TurnAllowedSides { get; set; }

		public TurnbasedAI(TWorld world) : base(world)
		{
			TurnAllowedSides = new List<string>();
		}

		public override void Update(BaseSnapshot snapshot)
		{
			base.Update(snapshot);
			var x = (TurnbasedSnapshot)snapshot;
			TurnAllowedSides = x.TurnAllowedSides;
		}

		public override bool AllowedToDecide()
		{
			return TurnAllowedSides.Contains(MySide);
		}

		protected override void SendCommandInternal(TCommand command, BaseCommand msg = null)
		{
			TurnbasedCommand message;
			if (msg == null)
				message = new TurnbasedCommand();
			else
				message = (TurnbasedCommand)msg;

			base.SendCommandInternal(command, message);
		}
	}
}
