using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using DataSpace;
using CardCollections;

namespace DataSpace
{
    [System.Serializable]
    public struct CardStruct
    {
        [XmlElement("indexNumber")]
        public int indexNumber;
        [XmlElement("cout")]
        public int count;
    }

    [System.Serializable]
    public class CharacterData
    {
        [XmlElement("charName")]
        public string charName;
        [XmlElement("level")]
        public float level;
        [XmlElement("def")]
        public float def;
        [XmlElement("maxHp")]
        public float maxHp;
        [XmlElement("dHp")]
        public float dHp;
        [XmlElement("maxMp")]
        public float maxMp;
        [XmlElement("dMp")]
        public float dMp;
        [XmlElement("modelAdress")]
        public string modelAdress;
    }
    [System.Serializable]
    public class PlayerData : CharacterData
    {
        [XmlArray("d_TCList")]
        [XmlArrayItem("CardStruct")]
        public List<CardStruct> d_TCList;
        [XmlArray("d_TCDeck")]
        [XmlArrayItem("int")]
        public List<int> d_TCDeck;
        [XmlArray("d_TCHand")]
        [XmlArrayItem("int")]
        public List<int> d_TCHand;
        [XmlArray("d_BCList")]
        [XmlArrayItem("CardStruct")]
        public List<CardStruct> d_BCList;
        [XmlArray("d_BCDeck")]
        [XmlArrayItem("int")]
        public List<int> d_BCDeck;
        [XmlArray("d_BCHand")]
        [XmlArrayItem("int")]
        public List<int> d_BCHand;

    }

    public class MonsterData : CharacterData
    {
        [XmlArray("attackList")]
        [XmlArrayItem("string")]
        public List<string> attackList;
        [XmlArray("defenseList")]
        [XmlArrayItem("string")]
        public List<string> defenseList;
        [XmlArray("skillList")]
        [XmlArrayItem("string")]
        public List<string> skillList;
        [XmlElement("style")]
        public int style;
        [XmlElement("extra")]
        public string extra;

    }
    public class MonsterList
    {
        [XmlArray("monsterList")]
        [XmlArrayItem("MonsterData")]
        public List<MonsterData> monsterList = null;
    }
    namespace Battle
    {
        public class DungeonData
        {
            [XmlElement("d_Name")]
            public string d_Name;
            [XmlElement("dungeonType")]
            public int dungeonType;
            [XmlElement("dungeonLevel")]
            public int dungeonLevel;
            [XmlElement("dungeonLength")]
            public int dungeonLength;
            [XmlArray("level1")]
            [XmlArrayItem("string")]
            public List<string> level1;
            [XmlArray("level2")]
            [XmlArrayItem("string")]
            public List<string> level2;
            [XmlArray("level3")]
            [XmlArrayItem("string")]
            public List<string> level3;
            [XmlArray("level4")]
            [XmlArrayItem("string")]
            public List<string> level4;

            public DungeonData(){ }
        }

        public class DungeonList
        {
            [XmlArray("dungeonList")]
            [XmlArrayItem("DungeonData")]
            public List<DungeonData> d_List;

            public DungeonList() { }
        }

        namespace Attack
        {

        }

        namespace Defense
        {

        }

        namespace Skill
        {

        }
    }

 
}
