using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace KoalaTeam.Chillin.Client
{
	public sealed class Config
	{

		private static Config instance = null;

		private IDictionary<string, Func<string, object>> inlineConfig;
		public JObject Configuration { get; private set; }

		private Config() { }

		public static Config GetInstance()
		{
			if (instance == null)
				instance = new Config();
			return instance;
		}

		public void Initialize(string cfgPath)
		{
			instance.InitInlineConfig();
			instance.ParseFile(cfgPath);
			instance.ParseArgs();
		}

		private void InitInlineConfig()
		{
			inlineConfig = new Dictionary<string, Func<string, object>>() {
				{ "net.host", (x) => x },
				{ "net.port", (x) => int.Parse(x) },
				{ "ai.agent_name", (x) => x },
				{ "ai.team_nickname", (x) => x },
				{ "ai.token", (x) => x }
			};
		}

		private void ParseFile(string cfgPath)
		{
			Configuration = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(cfgPath));
		}

		private void ParseArgs()
		{
			string pattern = "config\\.(.+)(\\.(.+))*\\=(.+)?";
			var regex = new Regex(pattern, RegexOptions.Compiled);

			foreach (var arg in Environment.GetCommandLineArgs())
			{
				var match = regex.Match(arg);
				if (!match.Success)
					continue;

				string key = match.Groups[1].Value;
				string[] keys = key.Split('.');
				object value = match.Groups.Last().Value;
				if (!string.IsNullOrEmpty((string)value))
					value = inlineConfig[key].Invoke((string)value);

				var tmp = instance.Configuration;
				for (int i = 0; i < keys.Length - 1; i++)
					tmp = tmp.Value(keys[i]);
				tmp[keys.Last()] = JToken.FromObject(value);
			}
		}
	}

	public static class Extensions
	{
		public static JObject Value(this JObject obj, string key)
		{
			return obj.Value<JObject>(key);
		}

		public static Group Last(this GroupCollection obj)
		{
			return obj[obj.Count - 1];
		}
	}
}
