using System;
using System.Linq;

using KoalaTeam.Chillin.Client.Helpers;

namespace KoalaTeam.Chillin.Client
{
	public class Network
	{
		private readonly SslSocket socket;

		public string Host { get; protected set; }
		public int Port { get; protected set; }

		public Network()
		{
			Host = Config.GetInstance().Configuration.Value("net").Value<string>("host");
			Port = Config.GetInstance().Configuration.Value("net").Value<int>("port");
			socket = new SslSocket();
		}

		public bool Connect()
		{
			var timeout = Config.GetInstance().Configuration.Value("net").Value<int>("timeout");
			return socket.Connect(Host, Port, timeout);
		}

		public byte[] RecvData()
		{
			try
			{
				int recvSize;
				var sizeByte = new byte[4];
				recvSize = socket.Receive(sizeByte, 0, sizeByte.Length);
				if (recvSize == 0)
					return null;
				int size = BitConverter.ToInt32(sizeByte, 0);

				int bytesReceived = 0;
				var buffer = new byte[size];
				while (bytesReceived < size)
				{
					recvSize = socket.Receive(buffer, bytesReceived, Math.Min(1024, size - bytesReceived));
					if (recvSize == 0)
						return null;
					bytesReceived += recvSize;
				}

				return buffer;
			}
			catch (Exception e)
			{
				// Logger.Log(e.ToString());
			}
			return null;
		}

		public void SendData(byte[] data)
		{
			try
			{
				byte[] size = BitConverter.GetBytes(data.Length);
				socket.Send(size.Concat(data).ToArray());
			}
			catch(Exception e)
			{
				// Logger.Log(e.ToString());
			}
		}

		public void Close()
		{
			socket.Close();
		}
	}
}
