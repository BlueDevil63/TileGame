using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using CardCollections;

namespace CardCollections
{
   
    public enum SkillType
    {
        Void,
        Knock,          //타격계
        Cut,            //절단계
        Avoidence,      //회피계
        Guard,          //방어계
        Magic,          //마법계
        Recovery,       //회복계
        Spell,          //스펠계
        Extra           //특수계
    }

    public enum ElementType
    {
        Void,
        Fire,           //불속성
        Water,          //물속성
        Ice,            //얼음속성       
        Electricity,    //전기속성
        Holy,           //성속성
        Dark            //어둠속성
    }

    [System.Serializable]
    public class BattleCard : CardBase
    {
        [XmlEnum("type")]
        public SkillType skillType;
        [XmlEnum("elementType")]
        public ElementType elementType;
        [XmlElement("skill_ID")]
        public int skill_ID;

        public BattleCard() { }

        public BattleCard(int index, string name, SkillType stype, ElementType etype, int id, string im, string address)
        {
            indexNumber = index;
            cardName = name;
            skillType = stype;
            elementType = etype;
            skill_ID = id;
            imageAddress = im;
            prfObjAddress = address;
        }
    }
    [System.Serializable]
    public class BattleCardLIst
    {
        [XmlArray("battleCards")]
        [XmlArrayItem("BattleCard")]
        public List<BattleCard> battleCards;

        public BattleCardLIst() { battleCards = new List<BattleCard>(); }
    }
}