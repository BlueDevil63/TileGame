﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CardCollections;
using DataSpace;
using TileCollections;

public class CreateData : MonoBehaviour {
    ///##### xml 파일 저장 순서#####
    ///1. 파일명 지정 string _fileName = "file.xml"
    ///2. 파일 위치 지정 string _fileLocation = 위치;
    ///3. string _data  = SerlializeObject() 시킴
    ///4. CreateXML(_data, _fileName, _fileLocation);


    DataTools dTool = new DataTools();
    private string _fileName;
    private string _fileLocation;
    private string _data;
    
    void Start()
    {
        _fileLocation = Application.dataPath + "/Resources/Data";
    }

    public void CreatePlayerBase()
    {
        PlayerData _pData = new PlayerData();
        _pData.charName = "NoName";
        _pData.level = 1.0f;
        _pData.def = 1.0f;
        _pData.hp = 2.0f;
        _pData.mp = 1.5f;
        _pData.modelAdress = "Prefabs/PlayerChar/Warrior_0";
        _pData.d_TCList = new List<string>();
        _pData.d_TCList.Add("Move2");
        _pData.d_TCList.Add("Forest");
        _pData.d_TCList.Add("Cave");
        _pData.d_TCList.Add("Dungeon");

        _pData.d_TCDeck = new List<string>();
        _pData.d_TCDeck.Add("Move2");
        _pData.d_TCDeck.Add("Forest");
        _pData.d_TCDeck.Add("Cave");
        _pData.d_TCDeck.Add("Dungeon");
        _pData.d_TCDeck.Add("Move2");
        _pData.d_TCDeck.Add("Forest");
        _pData.d_TCDeck.Add("Cave");
        _pData.d_TCDeck.Add("Dungeon");


        _pData.d_BCList = new List<string>();
        _pData.d_BCList.Add("Punch");
        _pData.d_BCList.Add("Slash_1");
        _pData.d_BCList.Add("Guard");
        _pData.d_BCList.Add("X");

        _pData.d_BCDeck = new List<string>();
        _pData.d_BCDeck.Add("Punch");
        _pData.d_BCDeck.Add("Slash_1");
        _pData.d_BCDeck.Add("Guard");
        _pData.d_BCDeck.Add("X");



        _fileName = "BasicPlayer.xml";
        _data = dTool.SerlializeObject(_pData, "Player");
        dTool.CreateXML(_data, _fileName, _fileLocation);

    }
    public void CreateMapData()
    {
        MapData mData = new MapData();
        _fileName = "BasicMap.xml";
        _data = dTool.SerlializeObject(mData, "MapData");
        dTool.CreateXML(_data, _fileName, _fileLocation);
    }
    public void CreateItemData()
    {
        ItemData rPortion = new ItemData();
        rPortion.itemName = "회복약";
        rPortion.type = 1;
        rPortion.price = 30;
        rPortion.effect = 1;
        rPortion.effectObj = "None";
        //rPortion.
        ItemList iList = new ItemList();
        iList.iData = new List<ItemData>();
        iList.iData.Add(rPortion);

        _fileName = "ItemList.xml";
        _data = dTool.SerlializeObject(iList, "ItemList");
        dTool.CreateXML(_data, _fileName, _fileLocation);

    }
    public void CreateAttackCard()
    {

    }
    public void CreateSkillCard()
    {

    }
    public void CreateTileCard()
    {

    }
    public void CreatMosterData()
    {
        MonsterDataBase mDataBase = new MonsterDataBase();
        mDataBase.monsterList = new List<MonsterData>();

        MonsterData mData = new MonsterData();
        mData.charName = "Monkey";
        mData.level = 1;
        mData.def = 1.5f;
        mData.hp = 1.5f;
        mData.mp = 1.0f;

        mData.attackList = new List<string>();
        mData.attackList.Add("Punch");
        mData.defenseList = new List<string>();
        mData.skillList = new List<string>();
        mData.skillList.Add("Apeal");
        mData.style = 1;
        mData.extra = string.Empty;

        mDataBase.monsterList.Add(mData);

        _fileName = "MonsterList.xml";
        _data = dTool.SerlializeObject(mDataBase, "MonsterList");
        dTool.CreateXML(_data, _fileName, _fileLocation);
       
    }

}
