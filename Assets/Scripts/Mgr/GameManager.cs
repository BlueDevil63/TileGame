using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using DataSpace;
using TileCollections;

public class GameManager : DataTools
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
               // Debug.LogError("GameManager = null!!");
                _instance = new GameManager();
            }
            return _instance;
        }
    
    }

    //타이틀 
    private bool loadMap = false;
    public bool nextBattle= false;
    //세이브 & 로드
    protected string _FName;
    protected string _FLoaction = Application.dataPath + "/Resources/Data";
    protected string _TempData;

    public PlayerData p_Data;
    public TileMapdData mData = null;
   // public MapTile[,] mData;

    //최대 덱의 수
    public const int deckCount = 30;
    //Stack 플레이어 리스트
    public int pIndex;
    public Player _player;
   

    public int loadCount = 0;

    public int cardNumber;
    public bool isSelect = false;

    public void SelectCard(int number)
    {
        cardNumber = number;
        isSelect = true;
    }


    void Awake()
    {
        _instance = this;
    }

    public void MapDataInit(int x, int z)
    {
        mData = new TileMapdData(x,z);
       // mData.Init(x, z);
        mData.data[0, 0].build = true;
        mData.data[0, 0].type = TileType.VILLIAGE;
    }

    public string SceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
    public void LoadTileMapData()
    {
      

    }

    public void GenerateTileMap()
    {

    }
    public void LoadBattleScene()
    {

    }
    public void LoadPlayerData()
    {
        _FName = "Blue.xml";
        _TempData = LoadXML(_FName, _FLoaction);
        p_Data = (PlayerData)DeserializeObject(_TempData, "Player");
        Debug.Log("성공");

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
