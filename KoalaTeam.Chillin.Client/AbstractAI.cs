using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;

using KoalaTeam.Chillin.Client.Helpers.Messages;

namespace KoalaTeam.Chillin.Client
{
	public abstract class AbstractAI
	{
		protected BlockingCollection<KSObject> commandSendQueue;
		protected Dictionary<string, List<string>> Sides { get; set; }
		protected string MySide { get; set; }
		protected string OtherSide { get; set; }
		protected ISet<string> OtherSides { get; set; }

		public void SetCommandSendQueue(BlockingCollection<KSObject> q)
		{
			commandSendQueue = q;
		}

		public void SetSides(Dictionary<string, List<string>> sides, string mySide)
		{
			Sides = sides;
			MySide = mySide;
			OtherSides = new HashSet<string>();
			foreach (string side in Sides.Keys)
				if (side != MySide)
					OtherSides.Add(side);
			OtherSide = (OtherSides.Count == 1) ? OtherSides.First() : null;
		}

		public abstract void Update(BaseSnapshot snapshot);
		public abstract bool AllowedToDecide();
		public virtual void Initialize() { }
		public virtual void Decide() { }
	}
}
