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
    public class CharterData
    {
        [XmlElement("charName")]
        public string charName;
        [XmlElement("level")]
        public float level;
        [XmlElement("def")]
        public float def;
        [XmlElement("hp")]
        public float hp;
        [XmlElement("mp")]
        public float mp;
        [XmlElement("modelAdress")]
        public string modelAdress;
    }
    [System.Serializable]
    public class PlayerData : CharterData
    {
        [XmlArray("d_TCList")]
        [XmlArrayItem("string")]
        public List<string> d_TCList;
        [XmlArray("d_TCDeck")]
        [XmlArrayItem("string")]
        public List<string> d_TCDeck;
        [XmlArray("d_BCList")]
        [XmlArrayItem("string")]
        public List<string> d_BCList;
        [XmlArray("d_BCDeck")]
        [XmlArrayItem("string")]
        public List<string> d_BCDeck;
    }

    public class MonsterData : CharterData
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
    public class MonsterDataBase
    {
        [XmlArray("monsterList")]
        [XmlArrayItem("MonsterData")]
        public List<MonsterData> monsterList = null;
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
