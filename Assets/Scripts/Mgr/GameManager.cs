using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using DataSpace;
using DataSpace.Battle;
using CardCollections;
using TileCollections;

public class GameManager //: DataTools
{
    public struct position
    {
       public int x { get; set; }
       public int z { get; set; }
    }
    private static GameManager _instance;
    public static GameManager instance {
        get {
            if (_instance == null) {
               // Debug.LogError("GameManager = null!!");
                _instance = new GameManager();
            }
            return _instance;
        }
    }
    //타이틀 
    private bool loadMap = false;
    //세이브 & 로드
    public DataManager m_DataManager = new DataManager();
    public string dungeonName;
   //로드된 데이터
    public PlayerData p_Data;
    public TileMapdData mData = null;
    public TileCardList d_TileCardList;
    public BattleCardLIst d_BattleCardList;
    //최대 덱의 수
    public const int deckCount = 30;
    //Stack 플레이어 리스트
    public int pIndex;
    public position pos;
    //public Player _player;

    public string selectTileName;
    public int loadCount = 0;
    public int cardNumber;
    public bool isSelect = false;

    public void SelectCard(int number){

        cardNumber = number;
        isSelect = true;
    }
    void Awake(){
        _instance = this;
    }
    //맵데이터 초기화
    public void MapDataInit(int x, int z)
    {
        mData = new TileMapdData(x,z);
       // mData.Init(x, z);
        mData.data[0, 0].build = true;
        mData.data[0, 0].type = TileType.VILLIAGE;
    }
    //씬이름을 체크후 리턴한다.
    public string SceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
    //타일맵 데이터를 불러온다.
    protected MapData LoadTileMapData(string name)
    {
        MapData mData = new MapData();

        return mData;
    }
    //타일맵 생성
    public void GenerateTileMap(string name)
    {
        ///데이터 불러오기
        ///불러온 데이터로 맵생성 시작
        ///for문을 이용해 타일을 하나하나 체크하면서 프리팹 설치;

        LoadTileMapData(name);
    }
    public bool CheckNextScene(TileType type)
    {
        ///타일 타입이 던전타입(동굴, 숲, 요새, 사막) 자동을 LoadBattleScene을 호출하여 씬을 바꾸고,
        ///데이터를 임시 저장한다 = false;
        ///마을이면 마을GUI를 로드시킨다. = true
        ///
        if(type == TileType.VILLIAGE){
            return true;
        }
        else if(type != TileType.NONE && type != TileType.VOID)
        {
            return false;
        }
        else
        {
            Debug.Log(type.ToString());
            Debug.LogError("잘못된 타일이동");
        }

        return false;
    }
   
    public void LoadBattleScene()
    {
        //플레이어 HandCard(Tile)을 백업

        //현재 타일 맵 데이터를 저장;
        Debug.Log(dungeonName);
        MapTile tile = mData.data[pos.x, pos.z];
        //씬 이동
        SceneManager.LoadScene("Battle");
    }
    public Player LoadPlayerData(string name, Player player)
    {
       PlayerData data = m_DataManager.LoadPlayerData(name);
        
        player.status = data;
        
        
        // 덱 불러오기
        for(int dCount = 0; dCount <data.d_TCDeck.Count; dCount++)
        {

        }
        return player;
    }
    public Player LoadMgrPlayerData(Player player)
    {
        Debug.Log(p_Data.charName);
        player.status = p_Data;
        return player;
    }
    public void LoadTileCardList()
    {
       d_TileCardList =  m_DataManager.LoadTileCardList();
    }
    public void LoadBattleCardList()
    {
        d_BattleCardList = m_DataManager.LoadBattleCardList();
    }

    public void SaveMgrPlayerData(Player player)
    {
        p_Data = player.status;
        p_Data.d_TCDeck = new List<int>();
        TileCard card = new TileCard();
        if (player.tileDeck.deck.Count != 0)
        {
            for (int k = 0; k < player.tileDeck.deck.Count; k++)
            {
                card = player.tileDeck.deck.Pop();
                p_Data.d_TCDeck.Add(card.indexNumber);
            }
        }

        p_Data.d_TCHand = new List<int>();
        for(int k = 0; k< player.handCard.Count; k++)
        {
            p_Data.d_TCHand.Add(player.handCard[k].indexNumber);
        }
        if(p_Data.d_TCHand.Count == 0 )
        {
            p_Data.d_TCHand.Add(-1);
        }
        if (p_Data.d_BCHand.Count == 0)
        {
            p_Data.d_BCHand.Add(-1);
        }

    }
    public void TempPlayerDataSave()
    {

    }

    public void TempPlayerData()
    {

    }

  
}
