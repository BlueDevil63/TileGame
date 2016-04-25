using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
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
    public MapData mData = null;

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
        mData = new MapData(x,z);
       // mData.Init(x, z);
        mData.data[0].build = true;
        mData.data[0].type = TileType.VILLIAGE;
    }

    public string SceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
    public void LoadTileMap()
    {

    }
    public void LoadBattleScene()
    {

    }
    public void LoadPlayerData()
    {

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
