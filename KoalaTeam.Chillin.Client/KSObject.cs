using System;

namespace KoalaTeam.Chillin.Client
{
	public abstract partial class KSObject
	{
		public const string NameStatic = "";
		public abstract string Name();
		public abstract byte[] Serialize();
		public abstract uint Deserialize(byte[] s, uint offset = 0);
	}
} // namespace KS
