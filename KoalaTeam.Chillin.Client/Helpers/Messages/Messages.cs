using System;
using System.Linq;
using System.Collections.Generic;

namespace KoalaTeam.Chillin.Client.Helpers.Messages
{
	public partial class Message : KSObject
	{
		public string Type { get; set; }
		public string Payload { get; set; }
		

		public Message()
		{
		}
		
		public new const string NameStatic = "Message";
		
		public override string Name() => "Message";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize Type
			s.Add((byte)((Type == null) ? 0 : 1));
			if (Type != null)
			{
				List<byte> tmp0 = new List<byte>();
				tmp0.AddRange(BitConverter.GetBytes((uint)Type.Count()));
				while (tmp0.Count > 0 && tmp0.Last() == 0)
					tmp0.RemoveAt(tmp0.Count - 1);
				s.Add((byte)tmp0.Count);
				s.AddRange(tmp0);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(Type));
			}
			
			// serialize Payload
			s.Add((byte)((Payload == null) ? 0 : 1));
			if (Payload != null)
			{
				List<byte> tmp1 = new List<byte>();
				tmp1.AddRange(BitConverter.GetBytes((uint)Payload.Count()));
				while (tmp1.Count > 0 && tmp1.Last() == 0)
					tmp1.RemoveAt(tmp1.Count - 1);
				s.Add((byte)tmp1.Count);
				s.AddRange(tmp1);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(Payload));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Type
			byte tmp2;
			tmp2 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp2 == 1)
			{
				byte tmp3;
				tmp3 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp4 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp4, 0, tmp3);
				offset += tmp3;
				uint tmp5;
				tmp5 = BitConverter.ToUInt32(tmp4, (int)0);
				
				Type = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp5).ToArray());
				offset += tmp5;
			}
			else
				Type = null;
			
			// deserialize Payload
			byte tmp6;
			tmp6 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp6 == 1)
			{
				byte tmp7;
				tmp7 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp8 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp8, 0, tmp7);
				offset += tmp7;
				uint tmp9;
				tmp9 = BitConverter.ToUInt32(tmp8, (int)0);
				
				Payload = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp9).ToArray());
				offset += tmp9;
			}
			else
				Payload = null;
			
			return offset;
		}
	}
	
	public partial class JoinOfflineGame : KSObject
	{
		public string TeamNickname { get; set; }
		public string AgentName { get; set; }
		

		public JoinOfflineGame()
		{
		}
		
		public new const string NameStatic = "JoinOfflineGame";
		
		public override string Name() => "JoinOfflineGame";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize TeamNickname
			s.Add((byte)((TeamNickname == null) ? 0 : 1));
			if (TeamNickname != null)
			{
				List<byte> tmp10 = new List<byte>();
				tmp10.AddRange(BitConverter.GetBytes((uint)TeamNickname.Count()));
				while (tmp10.Count > 0 && tmp10.Last() == 0)
					tmp10.RemoveAt(tmp10.Count - 1);
				s.Add((byte)tmp10.Count);
				s.AddRange(tmp10);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(TeamNickname));
			}
			
			// serialize AgentName
			s.Add((byte)((AgentName == null) ? 0 : 1));
			if (AgentName != null)
			{
				List<byte> tmp11 = new List<byte>();
				tmp11.AddRange(BitConverter.GetBytes((uint)AgentName.Count()));
				while (tmp11.Count > 0 && tmp11.Last() == 0)
					tmp11.RemoveAt(tmp11.Count - 1);
				s.Add((byte)tmp11.Count);
				s.AddRange(tmp11);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(AgentName));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize TeamNickname
			byte tmp12;
			tmp12 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp12 == 1)
			{
				byte tmp13;
				tmp13 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp14 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp14, 0, tmp13);
				offset += tmp13;
				uint tmp15;
				tmp15 = BitConverter.ToUInt32(tmp14, (int)0);
				
				TeamNickname = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp15).ToArray());
				offset += tmp15;
			}
			else
				TeamNickname = null;
			
			// deserialize AgentName
			byte tmp16;
			tmp16 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp16 == 1)
			{
				byte tmp17;
				tmp17 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp18 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp18, 0, tmp17);
				offset += tmp17;
				uint tmp19;
				tmp19 = BitConverter.ToUInt32(tmp18, (int)0);
				
				AgentName = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp19).ToArray());
				offset += tmp19;
			}
			else
				AgentName = null;
			
			return offset;
		}
	}
	
	public partial class JoinOnlineGame : KSObject
	{
		public string Token { get; set; }
		public string AgentName { get; set; }
		

		public JoinOnlineGame()
		{
		}
		
		public new const string NameStatic = "JoinOnlineGame";
		
		public override string Name() => "JoinOnlineGame";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize Token
			s.Add((byte)((Token == null) ? 0 : 1));
			if (Token != null)
			{
				List<byte> tmp20 = new List<byte>();
				tmp20.AddRange(BitConverter.GetBytes((uint)Token.Count()));
				while (tmp20.Count > 0 && tmp20.Last() == 0)
					tmp20.RemoveAt(tmp20.Count - 1);
				s.Add((byte)tmp20.Count);
				s.AddRange(tmp20);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(Token));
			}
			
			// serialize AgentName
			s.Add((byte)((AgentName == null) ? 0 : 1));
			if (AgentName != null)
			{
				List<byte> tmp21 = new List<byte>();
				tmp21.AddRange(BitConverter.GetBytes((uint)AgentName.Count()));
				while (tmp21.Count > 0 && tmp21.Last() == 0)
					tmp21.RemoveAt(tmp21.Count - 1);
				s.Add((byte)tmp21.Count);
				s.AddRange(tmp21);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(AgentName));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Token
			byte tmp22;
			tmp22 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp22 == 1)
			{
				byte tmp23;
				tmp23 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp24 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp24, 0, tmp23);
				offset += tmp23;
				uint tmp25;
				tmp25 = BitConverter.ToUInt32(tmp24, (int)0);
				
				Token = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp25).ToArray());
				offset += tmp25;
			}
			else
				Token = null;
			
			// deserialize AgentName
			byte tmp26;
			tmp26 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp26 == 1)
			{
				byte tmp27;
				tmp27 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp28 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp28, 0, tmp27);
				offset += tmp27;
				uint tmp29;
				tmp29 = BitConverter.ToUInt32(tmp28, (int)0);
				
				AgentName = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp29).ToArray());
				offset += tmp29;
			}
			else
				AgentName = null;
			
			return offset;
		}
	}
	
	public partial class ClientJoined : KSObject
	{
		public bool? Joined { get; set; }
		public string SideName { get; set; }
		public Dictionary<string, List<string>> Sides { get; set; }
		

		public ClientJoined()
		{
		}
		
		public new const string NameStatic = "ClientJoined";
		
		public override string Name() => "ClientJoined";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize Joined
			s.Add((byte)((Joined == null) ? 0 : 1));
			if (Joined != null)
			{
				s.AddRange(BitConverter.GetBytes((bool)Joined));
			}
			
			// serialize SideName
			s.Add((byte)((SideName == null) ? 0 : 1));
			if (SideName != null)
			{
				List<byte> tmp30 = new List<byte>();
				tmp30.AddRange(BitConverter.GetBytes((uint)SideName.Count()));
				while (tmp30.Count > 0 && tmp30.Last() == 0)
					tmp30.RemoveAt(tmp30.Count - 1);
				s.Add((byte)tmp30.Count);
				s.AddRange(tmp30);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(SideName));
			}
			
			// serialize Sides
			s.Add((byte)((Sides == null) ? 0 : 1));
			if (Sides != null)
			{
				List<byte> tmp31 = new List<byte>();
				tmp31.AddRange(BitConverter.GetBytes((uint)Sides.Count()));
				while (tmp31.Count > 0 && tmp31.Last() == 0)
					tmp31.RemoveAt(tmp31.Count - 1);
				s.Add((byte)tmp31.Count);
				s.AddRange(tmp31);
				
				foreach (var tmp32 in Sides)
				{
					s.Add((byte)((tmp32.Key == null) ? 0 : 1));
					if (tmp32.Key != null)
					{
						List<byte> tmp33 = new List<byte>();
						tmp33.AddRange(BitConverter.GetBytes((uint)tmp32.Key.Count()));
						while (tmp33.Count > 0 && tmp33.Last() == 0)
							tmp33.RemoveAt(tmp33.Count - 1);
						s.Add((byte)tmp33.Count);
						s.AddRange(tmp33);
						
						s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(tmp32.Key));
					}
					
					s.Add((byte)((tmp32.Value == null) ? 0 : 1));
					if (tmp32.Value != null)
					{
						List<byte> tmp34 = new List<byte>();
						tmp34.AddRange(BitConverter.GetBytes((uint)tmp32.Value.Count()));
						while (tmp34.Count > 0 && tmp34.Last() == 0)
							tmp34.RemoveAt(tmp34.Count - 1);
						s.Add((byte)tmp34.Count);
						s.AddRange(tmp34);
						
						foreach (var tmp35 in tmp32.Value)
						{
							s.Add((byte)((tmp35 == null) ? 0 : 1));
							if (tmp35 != null)
							{
								List<byte> tmp36 = new List<byte>();
								tmp36.AddRange(BitConverter.GetBytes((uint)tmp35.Count()));
								while (tmp36.Count > 0 && tmp36.Last() == 0)
									tmp36.RemoveAt(tmp36.Count - 1);
								s.Add((byte)tmp36.Count);
								s.AddRange(tmp36);
								
								s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(tmp35));
							}
						}
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Joined
			byte tmp37;
			tmp37 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp37 == 1)
			{
				Joined = BitConverter.ToBoolean(s, (int)offset);
				offset += sizeof(bool);
			}
			else
				Joined = null;
			
			// deserialize SideName
			byte tmp38;
			tmp38 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp38 == 1)
			{
				byte tmp39;
				tmp39 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp40 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp40, 0, tmp39);
				offset += tmp39;
				uint tmp41;
				tmp41 = BitConverter.ToUInt32(tmp40, (int)0);
				
				SideName = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp41).ToArray());
				offset += tmp41;
			}
			else
				SideName = null;
			
			// deserialize Sides
			byte tmp42;
			tmp42 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp42 == 1)
			{
				byte tmp43;
				tmp43 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp44 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp44, 0, tmp43);
				offset += tmp43;
				uint tmp45;
				tmp45 = BitConverter.ToUInt32(tmp44, (int)0);
				
				Sides = new Dictionary<string, List<string>>();
				for (uint tmp46 = 0; tmp46 < tmp45; tmp46++)
				{
					string tmp47;
					byte tmp49;
					tmp49 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp49 == 1)
					{
						byte tmp50;
						tmp50 = (byte)s[(int)offset];
						offset += sizeof(byte);
						byte[] tmp51 = new byte[sizeof(uint)];
						Array.Copy(s, offset, tmp51, 0, tmp50);
						offset += tmp50;
						uint tmp52;
						tmp52 = BitConverter.ToUInt32(tmp51, (int)0);
						
						tmp47 = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp52).ToArray());
						offset += tmp52;
					}
					else
						tmp47 = null;
					
					List<string> tmp48;
					byte tmp53;
					tmp53 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp53 == 1)
					{
						byte tmp54;
						tmp54 = (byte)s[(int)offset];
						offset += sizeof(byte);
						byte[] tmp55 = new byte[sizeof(uint)];
						Array.Copy(s, offset, tmp55, 0, tmp54);
						offset += tmp54;
						uint tmp56;
						tmp56 = BitConverter.ToUInt32(tmp55, (int)0);
						
						tmp48 = new List<string>();
						for (uint tmp57 = 0; tmp57 < tmp56; tmp57++)
						{
							string tmp58;
							byte tmp59;
							tmp59 = (byte)s[(int)offset];
							offset += sizeof(byte);
							if (tmp59 == 1)
							{
								byte tmp60;
								tmp60 = (byte)s[(int)offset];
								offset += sizeof(byte);
								byte[] tmp61 = new byte[sizeof(uint)];
								Array.Copy(s, offset, tmp61, 0, tmp60);
								offset += tmp60;
								uint tmp62;
								tmp62 = BitConverter.ToUInt32(tmp61, (int)0);
								
								tmp58 = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp62).ToArray());
								offset += tmp62;
							}
							else
								tmp58 = null;
							tmp48.Add(tmp58);
						}
					}
					else
						tmp48 = null;
					
					Sides[tmp47] = tmp48;
				}
			}
			else
				Sides = null;
			
			return offset;
		}
	}
	
	public partial class AgentJoined : KSObject
	{
		public string SideName { get; set; }
		public string AgentName { get; set; }
		public string TeamNickname { get; set; }
		

		public AgentJoined()
		{
		}
		
		public new const string NameStatic = "AgentJoined";
		
		public override string Name() => "AgentJoined";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize SideName
			s.Add((byte)((SideName == null) ? 0 : 1));
			if (SideName != null)
			{
				List<byte> tmp63 = new List<byte>();
				tmp63.AddRange(BitConverter.GetBytes((uint)SideName.Count()));
				while (tmp63.Count > 0 && tmp63.Last() == 0)
					tmp63.RemoveAt(tmp63.Count - 1);
				s.Add((byte)tmp63.Count);
				s.AddRange(tmp63);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(SideName));
			}
			
			// serialize AgentName
			s.Add((byte)((AgentName == null) ? 0 : 1));
			if (AgentName != null)
			{
				List<byte> tmp64 = new List<byte>();
				tmp64.AddRange(BitConverter.GetBytes((uint)AgentName.Count()));
				while (tmp64.Count > 0 && tmp64.Last() == 0)
					tmp64.RemoveAt(tmp64.Count - 1);
				s.Add((byte)tmp64.Count);
				s.AddRange(tmp64);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(AgentName));
			}
			
			// serialize TeamNickname
			s.Add((byte)((TeamNickname == null) ? 0 : 1));
			if (TeamNickname != null)
			{
				List<byte> tmp65 = new List<byte>();
				tmp65.AddRange(BitConverter.GetBytes((uint)TeamNickname.Count()));
				while (tmp65.Count > 0 && tmp65.Last() == 0)
					tmp65.RemoveAt(tmp65.Count - 1);
				s.Add((byte)tmp65.Count);
				s.AddRange(tmp65);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(TeamNickname));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize SideName
			byte tmp66;
			tmp66 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp66 == 1)
			{
				byte tmp67;
				tmp67 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp68 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp68, 0, tmp67);
				offset += tmp67;
				uint tmp69;
				tmp69 = BitConverter.ToUInt32(tmp68, (int)0);
				
				SideName = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp69).ToArray());
				offset += tmp69;
			}
			else
				SideName = null;
			
			// deserialize AgentName
			byte tmp70;
			tmp70 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp70 == 1)
			{
				byte tmp71;
				tmp71 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp72 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp72, 0, tmp71);
				offset += tmp71;
				uint tmp73;
				tmp73 = BitConverter.ToUInt32(tmp72, (int)0);
				
				AgentName = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp73).ToArray());
				offset += tmp73;
			}
			else
				AgentName = null;
			
			// deserialize TeamNickname
			byte tmp74;
			tmp74 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp74 == 1)
			{
				byte tmp75;
				tmp75 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp76 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp76, 0, tmp75);
				offset += tmp75;
				uint tmp77;
				tmp77 = BitConverter.ToUInt32(tmp76, (int)0);
				
				TeamNickname = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp77).ToArray());
				offset += tmp77;
			}
			else
				TeamNickname = null;
			
			return offset;
		}
	}
	
	public partial class AgentLeft : KSObject
	{
		public string SideName { get; set; }
		public string AgentName { get; set; }
		

		public AgentLeft()
		{
		}
		
		public new const string NameStatic = "AgentLeft";
		
		public override string Name() => "AgentLeft";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize SideName
			s.Add((byte)((SideName == null) ? 0 : 1));
			if (SideName != null)
			{
				List<byte> tmp78 = new List<byte>();
				tmp78.AddRange(BitConverter.GetBytes((uint)SideName.Count()));
				while (tmp78.Count > 0 && tmp78.Last() == 0)
					tmp78.RemoveAt(tmp78.Count - 1);
				s.Add((byte)tmp78.Count);
				s.AddRange(tmp78);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(SideName));
			}
			
			// serialize AgentName
			s.Add((byte)((AgentName == null) ? 0 : 1));
			if (AgentName != null)
			{
				List<byte> tmp79 = new List<byte>();
				tmp79.AddRange(BitConverter.GetBytes((uint)AgentName.Count()));
				while (tmp79.Count > 0 && tmp79.Last() == 0)
					tmp79.RemoveAt(tmp79.Count - 1);
				s.Add((byte)tmp79.Count);
				s.AddRange(tmp79);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(AgentName));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize SideName
			byte tmp80;
			tmp80 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp80 == 1)
			{
				byte tmp81;
				tmp81 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp82 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp82, 0, tmp81);
				offset += tmp81;
				uint tmp83;
				tmp83 = BitConverter.ToUInt32(tmp82, (int)0);
				
				SideName = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp83).ToArray());
				offset += tmp83;
			}
			else
				SideName = null;
			
			// deserialize AgentName
			byte tmp84;
			tmp84 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp84 == 1)
			{
				byte tmp85;
				tmp85 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp86 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp86, 0, tmp85);
				offset += tmp85;
				uint tmp87;
				tmp87 = BitConverter.ToUInt32(tmp86, (int)0);
				
				AgentName = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp87).ToArray());
				offset += tmp87;
			}
			else
				AgentName = null;
			
			return offset;
		}
	}
	
	public partial class StartGame : KSObject
	{
		public uint? StartTime { get; set; }
		

		public StartGame()
		{
		}
		
		public new const string NameStatic = "StartGame";
		
		public override string Name() => "StartGame";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize StartTime
			s.Add((byte)((StartTime == null) ? 0 : 1));
			if (StartTime != null)
			{
				s.AddRange(BitConverter.GetBytes((uint)StartTime));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize StartTime
			byte tmp88;
			tmp88 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp88 == 1)
			{
				StartTime = BitConverter.ToUInt32(s, (int)offset);
				offset += sizeof(uint);
			}
			else
				StartTime = null;
			
			return offset;
		}
	}
	
	public partial class EndGame : KSObject
	{
		public string WinnerSidename { get; set; }
		public Dictionary<string, Dictionary<string, string>> Details { get; set; }
		

		public EndGame()
		{
		}
		
		public new const string NameStatic = "EndGame";
		
		public override string Name() => "EndGame";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize WinnerSidename
			s.Add((byte)((WinnerSidename == null) ? 0 : 1));
			if (WinnerSidename != null)
			{
				List<byte> tmp89 = new List<byte>();
				tmp89.AddRange(BitConverter.GetBytes((uint)WinnerSidename.Count()));
				while (tmp89.Count > 0 && tmp89.Last() == 0)
					tmp89.RemoveAt(tmp89.Count - 1);
				s.Add((byte)tmp89.Count);
				s.AddRange(tmp89);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(WinnerSidename));
			}
			
			// serialize Details
			s.Add((byte)((Details == null) ? 0 : 1));
			if (Details != null)
			{
				List<byte> tmp90 = new List<byte>();
				tmp90.AddRange(BitConverter.GetBytes((uint)Details.Count()));
				while (tmp90.Count > 0 && tmp90.Last() == 0)
					tmp90.RemoveAt(tmp90.Count - 1);
				s.Add((byte)tmp90.Count);
				s.AddRange(tmp90);
				
				foreach (var tmp91 in Details)
				{
					s.Add((byte)((tmp91.Key == null) ? 0 : 1));
					if (tmp91.Key != null)
					{
						List<byte> tmp92 = new List<byte>();
						tmp92.AddRange(BitConverter.GetBytes((uint)tmp91.Key.Count()));
						while (tmp92.Count > 0 && tmp92.Last() == 0)
							tmp92.RemoveAt(tmp92.Count - 1);
						s.Add((byte)tmp92.Count);
						s.AddRange(tmp92);
						
						s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(tmp91.Key));
					}
					
					s.Add((byte)((tmp91.Value == null) ? 0 : 1));
					if (tmp91.Value != null)
					{
						List<byte> tmp93 = new List<byte>();
						tmp93.AddRange(BitConverter.GetBytes((uint)tmp91.Value.Count()));
						while (tmp93.Count > 0 && tmp93.Last() == 0)
							tmp93.RemoveAt(tmp93.Count - 1);
						s.Add((byte)tmp93.Count);
						s.AddRange(tmp93);
						
						foreach (var tmp94 in tmp91.Value)
						{
							s.Add((byte)((tmp94.Key == null) ? 0 : 1));
							if (tmp94.Key != null)
							{
								List<byte> tmp95 = new List<byte>();
								tmp95.AddRange(BitConverter.GetBytes((uint)tmp94.Key.Count()));
								while (tmp95.Count > 0 && tmp95.Last() == 0)
									tmp95.RemoveAt(tmp95.Count - 1);
								s.Add((byte)tmp95.Count);
								s.AddRange(tmp95);
								
								s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(tmp94.Key));
							}
							
							s.Add((byte)((tmp94.Value == null) ? 0 : 1));
							if (tmp94.Value != null)
							{
								List<byte> tmp96 = new List<byte>();
								tmp96.AddRange(BitConverter.GetBytes((uint)tmp94.Value.Count()));
								while (tmp96.Count > 0 && tmp96.Last() == 0)
									tmp96.RemoveAt(tmp96.Count - 1);
								s.Add((byte)tmp96.Count);
								s.AddRange(tmp96);
								
								s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(tmp94.Value));
							}
						}
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize WinnerSidename
			byte tmp97;
			tmp97 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp97 == 1)
			{
				byte tmp98;
				tmp98 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp99 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp99, 0, tmp98);
				offset += tmp98;
				uint tmp100;
				tmp100 = BitConverter.ToUInt32(tmp99, (int)0);
				
				WinnerSidename = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp100).ToArray());
				offset += tmp100;
			}
			else
				WinnerSidename = null;
			
			// deserialize Details
			byte tmp101;
			tmp101 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp101 == 1)
			{
				byte tmp102;
				tmp102 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp103 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp103, 0, tmp102);
				offset += tmp102;
				uint tmp104;
				tmp104 = BitConverter.ToUInt32(tmp103, (int)0);
				
				Details = new Dictionary<string, Dictionary<string, string>>();
				for (uint tmp105 = 0; tmp105 < tmp104; tmp105++)
				{
					string tmp106;
					byte tmp108;
					tmp108 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp108 == 1)
					{
						byte tmp109;
						tmp109 = (byte)s[(int)offset];
						offset += sizeof(byte);
						byte[] tmp110 = new byte[sizeof(uint)];
						Array.Copy(s, offset, tmp110, 0, tmp109);
						offset += tmp109;
						uint tmp111;
						tmp111 = BitConverter.ToUInt32(tmp110, (int)0);
						
						tmp106 = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp111).ToArray());
						offset += tmp111;
					}
					else
						tmp106 = null;
					
					Dictionary<string, string> tmp107;
					byte tmp112;
					tmp112 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp112 == 1)
					{
						byte tmp113;
						tmp113 = (byte)s[(int)offset];
						offset += sizeof(byte);
						byte[] tmp114 = new byte[sizeof(uint)];
						Array.Copy(s, offset, tmp114, 0, tmp113);
						offset += tmp113;
						uint tmp115;
						tmp115 = BitConverter.ToUInt32(tmp114, (int)0);
						
						tmp107 = new Dictionary<string, string>();
						for (uint tmp116 = 0; tmp116 < tmp115; tmp116++)
						{
							string tmp117;
							byte tmp119;
							tmp119 = (byte)s[(int)offset];
							offset += sizeof(byte);
							if (tmp119 == 1)
							{
								byte tmp120;
								tmp120 = (byte)s[(int)offset];
								offset += sizeof(byte);
								byte[] tmp121 = new byte[sizeof(uint)];
								Array.Copy(s, offset, tmp121, 0, tmp120);
								offset += tmp120;
								uint tmp122;
								tmp122 = BitConverter.ToUInt32(tmp121, (int)0);
								
								tmp117 = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp122).ToArray());
								offset += tmp122;
							}
							else
								tmp117 = null;
							
							string tmp118;
							byte tmp123;
							tmp123 = (byte)s[(int)offset];
							offset += sizeof(byte);
							if (tmp123 == 1)
							{
								byte tmp124;
								tmp124 = (byte)s[(int)offset];
								offset += sizeof(byte);
								byte[] tmp125 = new byte[sizeof(uint)];
								Array.Copy(s, offset, tmp125, 0, tmp124);
								offset += tmp124;
								uint tmp126;
								tmp126 = BitConverter.ToUInt32(tmp125, (int)0);
								
								tmp118 = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp126).ToArray());
								offset += tmp126;
							}
							else
								tmp118 = null;
							
							tmp107[tmp117] = tmp118;
						}
					}
					else
						tmp107 = null;
					
					Details[tmp106] = tmp107;
				}
			}
			else
				Details = null;
			
			return offset;
		}
	}
	
	public partial class BaseSnapshot : KSObject
	{
		public string WorldPayload { get; set; }
		

		public BaseSnapshot()
		{
		}
		
		public new const string NameStatic = "BaseSnapshot";
		
		public override string Name() => "BaseSnapshot";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize WorldPayload
			s.Add((byte)((WorldPayload == null) ? 0 : 1));
			if (WorldPayload != null)
			{
				List<byte> tmp127 = new List<byte>();
				tmp127.AddRange(BitConverter.GetBytes((uint)WorldPayload.Count()));
				while (tmp127.Count > 0 && tmp127.Last() == 0)
					tmp127.RemoveAt(tmp127.Count - 1);
				s.Add((byte)tmp127.Count);
				s.AddRange(tmp127);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(WorldPayload));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize WorldPayload
			byte tmp128;
			tmp128 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp128 == 1)
			{
				byte tmp129;
				tmp129 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp130 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp130, 0, tmp129);
				offset += tmp129;
				uint tmp131;
				tmp131 = BitConverter.ToUInt32(tmp130, (int)0);
				
				WorldPayload = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp131).ToArray());
				offset += tmp131;
			}
			else
				WorldPayload = null;
			
			return offset;
		}
	}
	
	public partial class RealtimeSnapshot : BaseSnapshot
	{
		public uint? CurrentCycle { get; set; }
		public float? CycleDuration { get; set; }
		

		public RealtimeSnapshot()
		{
		}
		
		public new const string NameStatic = "RealtimeSnapshot";
		
		public override string Name() => "RealtimeSnapshot";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize parents
			s.AddRange(base.Serialize());
			
			// serialize CurrentCycle
			s.Add((byte)((CurrentCycle == null) ? 0 : 1));
			if (CurrentCycle != null)
			{
				s.AddRange(BitConverter.GetBytes((uint)CurrentCycle));
			}
			
			// serialize CycleDuration
			s.Add((byte)((CycleDuration == null) ? 0 : 1));
			if (CycleDuration != null)
			{
				s.AddRange(BitConverter.GetBytes((float)CycleDuration));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize parents
			offset = base.Deserialize(s, offset);
			
			// deserialize CurrentCycle
			byte tmp132;
			tmp132 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp132 == 1)
			{
				CurrentCycle = BitConverter.ToUInt32(s, (int)offset);
				offset += sizeof(uint);
			}
			else
				CurrentCycle = null;
			
			// deserialize CycleDuration
			byte tmp133;
			tmp133 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp133 == 1)
			{
				CycleDuration = BitConverter.ToSingle(s, (int)offset);
				offset += sizeof(float);
			}
			else
				CycleDuration = null;
			
			return offset;
		}
	}
	
	public partial class TurnbasedSnapshot : RealtimeSnapshot
	{
		public List<string> TurnAllowedSides { get; set; }
		

		public TurnbasedSnapshot()
		{
		}
		
		public new const string NameStatic = "TurnbasedSnapshot";
		
		public override string Name() => "TurnbasedSnapshot";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize parents
			s.AddRange(base.Serialize());
			
			// serialize TurnAllowedSides
			s.Add((byte)((TurnAllowedSides == null) ? 0 : 1));
			if (TurnAllowedSides != null)
			{
				List<byte> tmp134 = new List<byte>();
				tmp134.AddRange(BitConverter.GetBytes((uint)TurnAllowedSides.Count()));
				while (tmp134.Count > 0 && tmp134.Last() == 0)
					tmp134.RemoveAt(tmp134.Count - 1);
				s.Add((byte)tmp134.Count);
				s.AddRange(tmp134);
				
				foreach (var tmp135 in TurnAllowedSides)
				{
					s.Add((byte)((tmp135 == null) ? 0 : 1));
					if (tmp135 != null)
					{
						List<byte> tmp136 = new List<byte>();
						tmp136.AddRange(BitConverter.GetBytes((uint)tmp135.Count()));
						while (tmp136.Count > 0 && tmp136.Last() == 0)
							tmp136.RemoveAt(tmp136.Count - 1);
						s.Add((byte)tmp136.Count);
						s.AddRange(tmp136);
						
						s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(tmp135));
					}
				}
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize parents
			offset = base.Deserialize(s, offset);
			
			// deserialize TurnAllowedSides
			byte tmp137;
			tmp137 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp137 == 1)
			{
				byte tmp138;
				tmp138 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp139 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp139, 0, tmp138);
				offset += tmp138;
				uint tmp140;
				tmp140 = BitConverter.ToUInt32(tmp139, (int)0);
				
				TurnAllowedSides = new List<string>();
				for (uint tmp141 = 0; tmp141 < tmp140; tmp141++)
				{
					string tmp142;
					byte tmp143;
					tmp143 = (byte)s[(int)offset];
					offset += sizeof(byte);
					if (tmp143 == 1)
					{
						byte tmp144;
						tmp144 = (byte)s[(int)offset];
						offset += sizeof(byte);
						byte[] tmp145 = new byte[sizeof(uint)];
						Array.Copy(s, offset, tmp145, 0, tmp144);
						offset += tmp144;
						uint tmp146;
						tmp146 = BitConverter.ToUInt32(tmp145, (int)0);
						
						tmp142 = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp146).ToArray());
						offset += tmp146;
					}
					else
						tmp142 = null;
					TurnAllowedSides.Add(tmp142);
				}
			}
			else
				TurnAllowedSides = null;
			
			return offset;
		}
	}
	
	public partial class BaseCommand : KSObject
	{
		public string Type { get; set; }
		public string Payload { get; set; }
		

		public BaseCommand()
		{
		}
		
		public new const string NameStatic = "BaseCommand";
		
		public override string Name() => "BaseCommand";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize Type
			s.Add((byte)((Type == null) ? 0 : 1));
			if (Type != null)
			{
				List<byte> tmp147 = new List<byte>();
				tmp147.AddRange(BitConverter.GetBytes((uint)Type.Count()));
				while (tmp147.Count > 0 && tmp147.Last() == 0)
					tmp147.RemoveAt(tmp147.Count - 1);
				s.Add((byte)tmp147.Count);
				s.AddRange(tmp147);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(Type));
			}
			
			// serialize Payload
			s.Add((byte)((Payload == null) ? 0 : 1));
			if (Payload != null)
			{
				List<byte> tmp148 = new List<byte>();
				tmp148.AddRange(BitConverter.GetBytes((uint)Payload.Count()));
				while (tmp148.Count > 0 && tmp148.Last() == 0)
					tmp148.RemoveAt(tmp148.Count - 1);
				s.Add((byte)tmp148.Count);
				s.AddRange(tmp148);
				
				s.AddRange(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(Payload));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize Type
			byte tmp149;
			tmp149 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp149 == 1)
			{
				byte tmp150;
				tmp150 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp151 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp151, 0, tmp150);
				offset += tmp150;
				uint tmp152;
				tmp152 = BitConverter.ToUInt32(tmp151, (int)0);
				
				Type = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp152).ToArray());
				offset += tmp152;
			}
			else
				Type = null;
			
			// deserialize Payload
			byte tmp153;
			tmp153 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp153 == 1)
			{
				byte tmp154;
				tmp154 = (byte)s[(int)offset];
				offset += sizeof(byte);
				byte[] tmp155 = new byte[sizeof(uint)];
				Array.Copy(s, offset, tmp155, 0, tmp154);
				offset += tmp154;
				uint tmp156;
				tmp156 = BitConverter.ToUInt32(tmp155, (int)0);
				
				Payload = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(s.Skip((int)offset).Take((int)tmp156).ToArray());
				offset += tmp156;
			}
			else
				Payload = null;
			
			return offset;
		}
	}
	
	public partial class RealtimeCommand : BaseCommand
	{
		public uint? Cycle { get; set; }
		

		public RealtimeCommand()
		{
		}
		
		public new const string NameStatic = "RealtimeCommand";
		
		public override string Name() => "RealtimeCommand";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize parents
			s.AddRange(base.Serialize());
			
			// serialize Cycle
			s.Add((byte)((Cycle == null) ? 0 : 1));
			if (Cycle != null)
			{
				s.AddRange(BitConverter.GetBytes((uint)Cycle));
			}
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize parents
			offset = base.Deserialize(s, offset);
			
			// deserialize Cycle
			byte tmp157;
			tmp157 = (byte)s[(int)offset];
			offset += sizeof(byte);
			if (tmp157 == 1)
			{
				Cycle = BitConverter.ToUInt32(s, (int)offset);
				offset += sizeof(uint);
			}
			else
				Cycle = null;
			
			return offset;
		}
	}
	
	public partial class TurnbasedCommand : RealtimeCommand
	{
		

		public TurnbasedCommand()
		{
		}
		
		public new const string NameStatic = "TurnbasedCommand";
		
		public override string Name() => "TurnbasedCommand";
		
		public override byte[] Serialize()
		{
			List<byte> s = new List<byte>();
			
			// serialize parents
			s.AddRange(base.Serialize());
			
			return s.ToArray();
		}
		
		public override uint Deserialize(byte[] s, uint offset = 0)
		{
			// deserialize parents
			offset = base.Deserialize(s, offset);
			
			return offset;
		}
	}
} // namespace KS.Messages
