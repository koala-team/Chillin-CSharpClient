using System;

using KoalaTeam.Chillin.Client.Helpers.Messages;

namespace KoalaTeam.Chillin.Client
{
	public class RealtimeAI<TWorld, TCommand> : BaseAI<TWorld, TCommand>
	{
		protected int CurrentCycle { get; set; }
		protected float CycleDuration { get; set; }

		public RealtimeAI(TWorld world) : base(world) { }

		public override void Update(BaseSnapshot snapshot)
		{
			base.Update(snapshot);
			var x = (RealtimeSnapshot)snapshot;
			CurrentCycle = (int)x.CurrentCycle;
			CycleDuration = (float)x.CycleDuration;
		}

		public override bool AllowedToDecide()
		{
			return true;
		}

		protected override void SendCommandInternal(TCommand command, BaseCommand msg = null)
		{
			RealtimeCommand message;
			if (msg == null)
				message = new RealtimeCommand();
			else
				message = (RealtimeCommand)msg;

			message.Cycle = (uint?)CurrentCycle;
			base.SendCommandInternal(command, message);
		}
	}
}
