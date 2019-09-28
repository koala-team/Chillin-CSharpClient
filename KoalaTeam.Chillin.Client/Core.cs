using System;
using System.Collections.Concurrent;
using System.Threading;

using KoalaTeam.Chillin.Client.Helpers;
using KoalaTeam.Chillin.Client.Helpers.Messages;

namespace KoalaTeam.Chillin.Client
{
	public class Core
	{
		private bool gameRunning;
		private readonly BlockingCollection<KSObject> commandSendQueue;
		private readonly Network network;
		private readonly Protocol protocol;
		private AbstractAI ai;

		public Core()
		{
			gameRunning = false;
			commandSendQueue = new BlockingCollection<KSObject>(new ConcurrentQueue<KSObject>());
			network = new Network();
			protocol = new Protocol(network);
		}

		public void RegisterAI(AbstractAI ai)
		{
			ai.SetCommandSendQueue(commandSendQueue);
			this.ai = ai;
		}

		public void Quit()
		{
			gameRunning = false;
			commandSendQueue.Add(null);
			network.Close();
		}

		private void SendMessage(KSObject msg)
		{
			protocol.SendMessage(msg);
		}

		private KSObject RecvMessage()
		{
			KSObject tmp = protocol.RecvMessage();
			if (tmp != null)
				return tmp;

			Logger.Log("Connection closed");
			Quit();
			Environment.Exit(0);
			return null;
		}

		public void SendCommandThread()
		{
			while (true)
			{
				KSObject msg = commandSendQueue.Take();

				if (msg == null)
					break;

				if (gameRunning)
					SendMessage(msg);
			}
		}

		public bool Connect()
		{
			var max_tries = Config.GetInstance().Configuration.Value("net").Value<int>("max_tries");
			var retry_waiting_time = Config.GetInstance().Configuration.Value("net").Value<float>("retry_waiting_time");

			while (true)
			{
				Logger.Log(string.Format("Connecting to host '{0}' port {1}", network.Host, network.Port));
				try
				{
					bool connected = network.Connect();
					if (connected)
						Logger.Log("Connected successfully");
					return connected;
				}
				catch (Exception e)
				{
					Logger.Log("Failed to connect: " + e.Message);
				}

				max_tries--;
				if (max_tries <= 0)
					break;
				Logger.Log(string.Format("Reconnecting in {0} seconds ...", retry_waiting_time));

				Thread.Sleep((int)(retry_waiting_time * 1000.0));
			}

			return false;
		}

		public bool Join()
		{
			KSObject joinMessage;
			if (Config.GetInstance().Configuration.Value("general").Value<bool>("offline_mode"))
			{
				joinMessage = new JoinOfflineGame
				{
					TeamNickname = Config.GetInstance().Configuration.Value("ai").Value<string>("team_nickname"),
					AgentName = Config.GetInstance().Configuration.Value("ai").Value<string>("agent_name")
				};
			}
			else
			{
				joinMessage = new JoinOnlineGame
				{
					Token = Config.GetInstance().Configuration.Value("ai").Value<string>("token"),
					AgentName = Config.GetInstance().Configuration.Value("ai").Value<string>("agent_name")
				};
			}

			SendMessage(joinMessage);
			ClientJoined clientJoinedMessage;
			while (true)
			{
				KSObject tmp = RecvMessage();
				if (tmp.Name() == ClientJoined.NameStatic)
				{
					clientJoinedMessage = (ClientJoined)tmp;
					break;
				}
			}

			if ((bool)clientJoinedMessage.Joined)
			{
				ai.SetSides(clientJoinedMessage.Sides, clientJoinedMessage.SideName);
				Logger.Log("Joined the game successfully");
				Logger.Log("Side: " + clientJoinedMessage.SideName);
				return true;
			}

			Logger.Log("Failed to join the game");
			return false;
		}

		public void Loop()
		{
			while (true)
			{
				KSObject msg = RecvMessage();

				if (msg is BaseSnapshot)
				{
					HandleSnapshot((BaseSnapshot)msg);
				}
				else if (msg.Name() == StartGame.NameStatic)
				{
					HandleStartGame(msg);
				}
				else if (msg.Name() == EndGame.NameStatic)
				{
					HandleEndGame((EndGame)msg);
					break;
				}
			}
		}


		private void HandleSnapshot(BaseSnapshot snapshot)
		{
			ai.Update(snapshot);

			if (!gameRunning)
			{
				gameRunning = true;
				ai.Initialize();
				if (!Config.GetInstance().Configuration.Value("ai").Value<bool>("create_new_thread") ||
					ai.AllowedToDecide())
				{
					new Thread(() => ai.Decide()).Start();
				}
			}
			else if (Config.GetInstance().Configuration.Value("ai").Value<bool>("create_new_thread") &&
					 ai.AllowedToDecide())
			{
				new Thread(() => ai.Decide()).Start();
			}
		}

		private void HandleStartGame(KSObject gamestart)
		{
			new Thread(() => SendCommandThread()).Start();
		}

		private void HandleEndGame(EndGame endgame)
		{
			string winner = endgame.WinnerSidename ?? "draw";
			Logger.Log("Winner side: " + winner);

			if (endgame.Details != null && endgame.Details.Count > 0)
			{
				Logger.Log("Details:");
				foreach (var name in endgame.Details.Keys)
				{
					Logger.Log("  " + name + ":");
					foreach (string side in endgame.Details[name].Keys)
						Logger.Log(string.Format("    {0} -> {1}", side, endgame.Details[name][side]));
				}
			}
			Quit();
		}
	}
}
