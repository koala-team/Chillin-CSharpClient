using System;

namespace KoalaTeam.Chillin.Client.Helpers
{
	public static class Logger
	{
		public static void Log(string value)
		{
			Console.WriteLine(value);
		}

		public static void Log(object value)
		{
			Console.WriteLine(value);
		}
	}
}
