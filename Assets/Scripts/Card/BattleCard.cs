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
        None,
        Knock,          //타격계
        Cut,            //절단계
        Recovery,       //회복계
        Buff,           //버프계
        Guard,          //방어계
        Avoidence,      //회피계
        Extra           //특수계
    }

    public enum ElementType
    {
        None,
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

        public BattleCard(string name, SkillType stype, ElementType etype, int id, string im, string address)
        {
            cardName = name;
            skillType = stype;
            elementType = etype;
            skill_ID = id;
            imageAddress = im;
            prfObjAddress = address;
        }
    }
}

public class BattleDeck
{
    public Stack<BattleCard> deck;

    public void Init()
    {
        deck = new Stack<BattleCard>();
    }

    public void Mix()
    {
        //List<string> dummy = new List<string>();
        //임시용 더미
        TempBattleDeck temp = new TempBattleDeck();
        temp.Setting();

        //중복 체크용
        bool[] checkExistofNum = new bool[40];
        for (int k = 0; k < 40; k++)
        {
            checkExistofNum[k] = false;
        }

        for (int i = 0; i < 40;)
        {
            int nTemp = Random.RandomRange(0, 39);
            if (checkExistofNum[i] == false)
            {
                deck.Push(temp.deck[nTemp]);
                checkExistofNum[i] = true;
                i++;

            }
        }

    }
    public BattleCard Pop()
    {
        BattleCard popCard = deck.Pop();
        return popCard;
    }
    public void Push(BattleCard card)
    {
        deck.Push(card);
    }
}


public class TempBattleDeck
{
    public List<BattleCard> deck;

    private BattleCard cuttig = new BattleCard("Cutting", SkillType.Cut, ElementType.None, 1, "btCutting", null);
    private BattleCard punch = new BattleCard("Punch", SkillType.Knock, ElementType.None, 2, "btGuard", null);
    private BattleCard guard = new BattleCard("Guard", SkillType.Guard, ElementType.None, 3, "btPunch", null);
    private BattleCard hpPortion = new BattleCard("hpPortion", SkillType.Recovery, ElementType.None, 4, "btHpPortion", null);


    public void Init()
    {
        deck = new List<BattleCard>();
    }

    public void Setting()
    {

    }
}