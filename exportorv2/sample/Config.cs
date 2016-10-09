// Generated by github.com/davyxu/tabtoy
// Version: 2.2.1
// DO NOT EDIT!!
using System.Collections.Generic;
using System.IO;

namespace gamedef
{
	
	public enum ActorType
	{
		
		// 格斗士
		Fighter = 0,
		
		// 超能
		Power = 21,
	
	}
	
	
	public partial class Config : tabtoy.DataObject
	{	
		
		// Sample
		public List<SampleDefine> Sample = new List<SampleDefine>();
		
		// Exp
		public List<ExpDefine> Exp = new List<ExpDefine>();
	
	
	
	 	Dictionary<long, SampleDefine> _SampleByID = new Dictionary<long, SampleDefine>();
        public SampleDefine GetSampleByID(long ID)
        {
            SampleDefine ret;
            if ( _SampleByID.TryGetValue( ID, out ret ) )
            {
                return ret;
            }

            return null;
        }
	
	 	Dictionary<string, SampleDefine> _SampleByName = new Dictionary<string, SampleDefine>();
        public SampleDefine GetSampleByName(string Name)
        {
            SampleDefine ret;
            if ( _SampleByName.TryGetValue( Name, out ret ) )
            {
                return ret;
            }

            return null;
        }
	
	 	Dictionary<int, ExpDefine> _ExpByLevel = new Dictionary<int, ExpDefine>();
        public ExpDefine GetExpByLevel(int Level)
        {
            ExpDefine ret;
            if ( _ExpByLevel.TryGetValue( Level, out ret ) )
            {
                return ret;
            }

            return null;
        }
	
		public void Deserialize( tabtoy.DataReader reader )
		{
			
			// Sample
			if ( reader.MatchTag(0x90000) )
			{
				reader.ReadList_Struct<SampleDefine>( this.Sample );
			}
			
			// Exp
			if ( reader.MatchTag(0x90001) )
			{
				reader.ReadList_Struct<ExpDefine>( this.Exp );
			}
			
			
			// Build Sample Index
            for( int i = 0;i< this.Sample.Count;i++)
            {
                var element = this.Sample[i];
				
                _SampleByID.Add(element.ID, element);                
				
                _SampleByName.Add(element.Name, element);                
				
            }
			
			// Build Exp Index
            for( int i = 0;i< this.Exp.Count;i++)
            {
                var element = this.Exp[i];
				
                _ExpByLevel.Add(element.Level, element);                
				
            }
			
		}
	}
	
	public partial class Prop : tabtoy.DataObject
	{	
		
		// 血量
		public int HP = 10;
		
		// 攻击速率
		public float AttackRate = 0;
		
		// 额外类型
		public ActorType ExType = ActorType.Fighter;
	
	
	
		public void Deserialize( tabtoy.DataReader reader )
		{
			
			// 血量
			if ( reader.MatchTag(0x10000) )
			{
				this.HP = reader.ReadInt32( );
			}
			
			// 攻击速率
			if ( reader.MatchTag(0x50001) )
			{
				this.AttackRate = reader.ReadFloat( );
			}
			
			// 额外类型
			if ( reader.MatchTag(0x80002) )
			{
				this.ExType = reader.ReadEnum<ActorType>( );
			}
			
			
		}
	}
	
	public partial class SampleDefine : tabtoy.DataObject
	{	
		
		// 唯一ID
		public long ID = 0;
		
		// 名称
		public string Name = "";
		
		// 图标ID
		public int IconID = 0;
		
		// 攻击率
		public float NumericalRate = 0;
		
		// 物品id
		public int ItemID = 100;
		
		// BuffID
		public List<int> BuffID = new List<int>();
		
		// 类型
		public ActorType Type = ActorType.Fighter;
		
		// 技能ID列表
		public List<int> SkillID = new List<int>();
		
		// 单结构解析
		public Prop SingleStruct = new Prop();
		
		// 字符串结构
		public List<Prop> StrStruct = new List<Prop>();
	
	
	
		public void Deserialize( tabtoy.DataReader reader )
		{
			
			// 唯一ID
			if ( reader.MatchTag(0x20000) )
			{
				this.ID = reader.ReadInt64( );
			}
			
			// 名称
			if ( reader.MatchTag(0x60001) )
			{
				this.Name = reader.ReadString( );
			}
			
			// 图标ID
			if ( reader.MatchTag(0x10002) )
			{
				this.IconID = reader.ReadInt32( );
			}
			
			// 攻击率
			if ( reader.MatchTag(0x50003) )
			{
				this.NumericalRate = reader.ReadFloat( );
			}
			
			// 物品id
			if ( reader.MatchTag(0x10004) )
			{
				this.ItemID = reader.ReadInt32( );
			}
			
			// BuffID
			if ( reader.MatchTag(0x10005) )
			{
				reader.ReadList_Int32( this.BuffID );
			}
			
			// 类型
			if ( reader.MatchTag(0x80006) )
			{
				this.Type = reader.ReadEnum<ActorType>( );
			}
			
			// 技能ID列表
			if ( reader.MatchTag(0x10007) )
			{
				reader.ReadList_Int32( this.SkillID );
			}
			
			// 单结构解析
			if ( reader.MatchTag(0x90008) )
			{
				this.SingleStruct = reader.ReadStruct<Prop>( );
			}
			
			// 字符串结构
			if ( reader.MatchTag(0x90009) )
			{
				reader.ReadList_Struct<Prop>( this.StrStruct );
			}
			
			
		}
	}
	
	public partial class ExpDefine : tabtoy.DataObject
	{	
		
		// 唯一ID
		public int Level = 0;
		
		// 名称
		public int Exp = 0;
		
		// 类型
		public ActorType Type = ActorType.Fighter;
	
	
	
		public void Deserialize( tabtoy.DataReader reader )
		{
			
			// 唯一ID
			if ( reader.MatchTag(0x10000) )
			{
				this.Level = reader.ReadInt32( );
			}
			
			// 名称
			if ( reader.MatchTag(0x10001) )
			{
				this.Exp = reader.ReadInt32( );
			}
			
			// 类型
			if ( reader.MatchTag(0x80002) )
			{
				this.Type = reader.ReadEnum<ActorType>( );
			}
			
			
		}
	}
	

}
