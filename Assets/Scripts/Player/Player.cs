using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TileCollections;
using CardCollections;
using DataSpace;

public class Player : MonoBehaviour {

    public PlayerData status;
    public int actPoint;
    public TileDeck tileDeck;
    public List<TileCard> handCard;
    public BattleDeck battleDeck;
    public List<BattleCard> battleHands;

    public TileCard selectCard;
    public int pos_x;
    public int pos_y;

    public PlayerGUI pGUI;
   
    public void InGameInit() {

        status = new PlayerData();
        pGUI = gameObject.GetComponent<PlayerGUI>();
        actPoint = 0;
        tileDeck = new TileDeck();
        handCard = new List<TileCard>();
        battleDeck = new BattleDeck();
        battleHands = new List<BattleCard>();
        selectCard = new TileCard(0,string.Empty, TileType.NONE, 0, string.Empty, null);
        tileDeck.Init();
        pos_x = 0;
        pos_y = 0;
     
    }

    public void InGameStart()
    {
        pGUI.Init();
        //덱 삽입
        tileDeck.Set(status.d_TCDeck);
        pGUI.HpUpDate(status.maxHp, 0);
        pGUI.MpUpDate(status.maxMp, 0);
        pGUI.inGameCardScroll.SetUpCard(this);
    }

    public void BattleStart()
    {
        pGUI.Init();
        battleDeck.Set(status.d_BCDeck);
        pGUI.HpUpDate(status.maxHp, 0);
        pGUI.MpUpDate(status.maxMp, 0);
        pGUI.battleCardScroll.SetUpCard(this);
    }

    public void InGamePopCard()
    {
        handCard.Add(tileDeck.Pop());
       // Debug.Log("이름확인 = " + handCard[3].cardName);
        pGUI.inGameCardScroll.PopCard(this);
    }

    public void BattlePopCard()
    {
        battleHands.Add(battleDeck.Pop());
        pGUI.battleCardScroll.PopCard(this);
    }
    public TileType Build(int num)
    {
        TileType type = handCard[num].type;
        handCard.RemoveAt(num);
        pGUI.inGameCardScroll.UseCard(this);
        return type;
    }
}

public class TileDeck
{
    public Stack<TileCard> deck;

    public void Init()
    {
        deck = new Stack<TileCard>();
    }
    public void Set(List<int> intDeck)
    {
        List<TileCard> list = new List<TileCard>();
        for(int i = 0; i< intDeck.Count; i++)
        {
            list.Add(GameManager.instance.d_TileCardList.tileCards[intDeck[i]]);
        }
        Mix(list);
    }

    public void Mix(List<TileCard> original)
    {
        //중복 체크용
        bool[] checkExistofNum = new bool[40];
        for (int k = 0; k < 40; k++)
        {
            checkExistofNum[k] = false;
        }

        for (int i = 0; i < 40;)
        {
            int nTemp = Random.Range(0, 39);
            if (checkExistofNum[i] == false)
            {
                deck.Push(original[nTemp]);
                checkExistofNum[i] = true;
                i++;

            }
        }

    }
    public void Remix()
    {

    }
    public TileCard Pop()
    {
        TileCard popCard = deck.Pop();
        return popCard;
    }
    public void Push(TileCard card)
    {
        deck.Push(card);
    }
}

public class BattleDeck
{
    public Stack<BattleCard> deck;

    public void Init()
    {
        deck = new Stack<BattleCard>();
    }
    public void Set(List<int> intDeck)
    {
        List<BattleCard> list = new List<BattleCard>();
        for (int i = 0; i < intDeck.Count;)
        {
            list.Add(GameManager.instance.d_BattleCardList.battleCards[intDeck[i]]);
        }
        Mix(list);
    }

    public void Mix(List<BattleCard> original)
    {

        //중복 체크용
        bool[] checkExistofNum = new bool[50];
        for (int k = 0; k < 50; k++)
        {
            checkExistofNum[k] = false;
        }

        for (int i = 0; i < 50;)
        {
            int nTemp = Random.Range(0, 49);
            if (checkExistofNum[i] == false)
            {
                deck.Push(original[nTemp]);
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