using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TileCollections;
using CardCollections;

public class Player : MonoBehaviour {

    public string charName;
    public float level;
    public float def;
    public float maxHp;
    public float maxMp;

    public int actPoint;
    public Deck deck;
    public List<TileCard> handCard;
    public BattleDeck battleDeck;
    public List<BattleCard> battleHands;

    public float cHp;
    public float cMp;

    public TileCard selectCard;
    public int pos_x;
    public int pos_y;

    public PlayerGUI pGUI;
   
    public void InGameInit() {

        pGUI = gameObject.GetComponent<PlayerGUI>();
        
        deck = new Deck();
        handCard = new List<TileCard>();
        battleDeck = new BattleDeck();
        battleHands = new List<BattleCard>();
        selectCard = new TileCard(string.Empty, TileType.NONE, 0, string.Empty, null);
        //name = "BlueTeam";

        deck.Init();
        deck.Mix();

        pos_x = 0;
        pos_y = 0;

        for(int i = 0; i < 5; i++)
        {
            handCard.Add(deck.Pop());
        }
    }

    public void InGameStart()
    {
        pGUI.Init();
        pGUI.HpUpDate(maxHp, 0);
        pGUI.MpUpDate(maxMp, 0);
        pGUI.inGameCardScroll.SetUpCard(this);
    }

    public void BattleStart()
    {
        pGUI.Init();
        pGUI.HpUpDate(maxHp, 0);
        pGUI.MpUpDate(maxMp, 0);
        pGUI.battleCardScroll.SetUpCard(this);
    }

    public void InGamePopCard()
    {
        handCard.Add(deck.Pop());
        Debug.Log("이름확인 = " + handCard[3].cardName);
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


    //public int CheckSelected()
    //{
    //    int number = -1;
    //    for(int n = 0; n <= handCard.Count; n++ )
    //    {
    //       if( handCard[n].selected == true )
    //        {
    //            number = n;
    //        }
    //    }

    //    return number;
    //}
}


public class TempDeck
{
    public List<TileCard> deck = new List<TileCard>();

    TileCard village = new TileCard();
    TileCard dungeon = new TileCard();
    TileCard cave = new TileCard();
    TileCard forest = new TileCard();

    public void Init()
    {
        village = new TileCard("Villiage", TileType.VILLIAGE, 1, "Villiage", "Prefabs/prfVilliage");
        dungeon = new TileCard("Dungeon", TileType.DUNGEON, 2, "Dungeon", "Prefabs/prfDungeon");
        cave = new TileCard("Cave", TileType.CAVE, 3, "Cave", "Prefabs/prfCave");
        forest = new TileCard("Forest", TileType.FOREST, 4, "Forest", "Prefabs/prfForest");

    }

    public void Setting()
    {

        Init();
        for (int k = 0; k < 30; k++)
        {
            if (k < 7)
            {
                deck.Add(village);
            }
            else if (k < 14)
            {
                deck.Add(dungeon);
            }
            else if (k < 21)
            {
                deck.Add(cave);
            }
            else
            {
                deck.Add(forest);
            }
        }
    }

}
