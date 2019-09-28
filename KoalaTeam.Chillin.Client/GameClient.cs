using System;

namespace KoalaTeam.Chillin.Client
{
	public class GameClient
	{
		private readonly Core core;

		public GameClient(string configPath)
		{
			Config.GetInstance().Initialize(configPath);
			core = new Core();
		}

		public void RegisterAI(AbstractAI ai)
		{
			core.RegisterAI(ai);
		}

		public void Run()
		{
			if (!core.Connect())
				return;
			if (!core.Join())
				return;
			core.Loop();
		}
	}
}
