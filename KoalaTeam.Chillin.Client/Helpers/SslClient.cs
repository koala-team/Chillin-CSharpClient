using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace KoalaTeam.Chillin.Client.Helpers
{
	public class SslSocket
	{
		private TcpClient client;
		private SslStream stream;

		public SslSocket() { }

		public bool ValidateServerCertificate(
			  object sender,
			  X509Certificate certificate,
			  X509Chain chain,
			  SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		public bool Connect(string host, int port, int timeout = 5)
		{
			timeout *= 1000;

			client = new TcpClient() { NoDelay = true };
			var clientResult = client.BeginConnect(host, port, null, null);
			if (clientResult.AsyncWaitHandle.WaitOne(timeout))
				client.EndConnect(clientResult);
			if (!client.Connected)
				return false;

			stream = new SslStream(
				client.GetStream(),
				false, 
				new RemoteCertificateValidationCallback(ValidateServerCertificate),
				null
			);
			var streamResult = stream.BeginAuthenticateAsClient(host, null, null);
			if (streamResult.AsyncWaitHandle.WaitOne(timeout))
				stream.EndAuthenticateAsClient(streamResult);
			return stream.IsAuthenticated;
		}

		public int Receive(byte[] buffer, int offset, int count)
		{
			return stream.Read(buffer, offset, count);
		}

		public void Send(byte[] buffer)
		{
			stream.Write(buffer);
		}

		public void Close()
		{
			stream.Close();
			client.Close();
		}
	}
}
