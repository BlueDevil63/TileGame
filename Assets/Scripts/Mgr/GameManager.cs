using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using DataSpace;
using DataSpace.Battle;
using TileCollections;

public class GameManager //: DataTools
{
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
    public PlayerData p_Data;
    public TileMapdData mData = null;
    //최대 덱의 수
    public const int deckCount = 30;
    //Stack 플레이어 리스트
    public int pIndex;
    public Player _player;

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
            Debug.LogError("잘못된 타일이동");
        }

        return false;
    }

    public void LoadBattleScene()
    {
        //플레이어 HandCard(Tile)을 백업

        //현재 타일 맵 데이터를 저장;
        MapTile tile = mData.data[_player.pos_x, _player.pos_y];
        //씬 이동
        SceneManager.LoadScene("BattleScne");
    }

    public void LoadPlayerData()
    {
        p_Data = m_DataManager.LoadPlayerData("Blue");
        _player.charName = p_Data.charName;
        _player.maxHp = p_Data.hp;
        _player.maxMp = p_Data.mp;
        _player.def = p_Data.def;
        _player.level = p_Data.level;
    }
    public void SavePlayerData()
    {

    }
    public void TempPlayerDataSave()
    {

    }

    public void TempPlayerData()
    {

    }

  
}
