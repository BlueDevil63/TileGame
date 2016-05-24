using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CardCollections;
using DataSpace;
using DataSpace.Battle;
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
    //플레이어 기본데이터 생성
    public void CreatePlayerBase()
    {
        PlayerData _pData = new PlayerData();
        _pData.charName = "NoName";
        _pData.level = 1.0f;
        _pData.def = 1.0f;
        _pData.maxHp = 2.0f;
        _pData.dHp = 0;
        _pData.maxMp = 1.5f;
        _pData.dMp = 0;
        _pData.modelAdress = "Prefabs/PlayerChar/Warrior_0";
        _pData.d_TCList = new List<CardStruct>();
        CardStruct cards;
        cards.indexNumber = 1;
        cards.count = 10;
        _pData.d_TCList.Add(cards);
        cards.indexNumber = 2;
        cards.count = 10;
        _pData.d_TCList.Add(cards);
        cards.indexNumber = 7;
        _pData.d_TCList.Add(cards);
        cards.indexNumber = 8;
        _pData.d_TCList.Add(cards);

        _pData.d_TCDeck = new List<int>();
        int num = 0;
        for (int i = 0; i < 4; i++)
        {
            switch(i)
            {
                case 0:
                    num = 1;
                    break;
                case 1:
                    num = 2;
                    break;
                case 2:
                    num = 7;
                    break;
                case 3:
                    num = 8;
                    break;
                default:
                    num = 0;
                    break;

            }
            for (int k = 0; k < 10; k++)
            {
                _pData.d_TCDeck.Add(num);
            }
        }



        _pData.d_TCHand = new List<int>();
        _pData.d_TCHand.Add(-1);



        _pData.d_BCList = new List<CardStruct>();
        cards.indexNumber = 0;
        cards.count = 10;
        _pData.d_BCList.Add(cards);
        cards.indexNumber = 1;
        _pData.d_BCList.Add(cards);
        cards.indexNumber = 2;
        _pData.d_BCList.Add(cards);
        cards.indexNumber = 3;
        _pData.d_BCList.Add(cards);
        cards.indexNumber = 4;
        _pData.d_BCList.Add(cards);

        _pData.d_BCDeck = new List<int>();
        for(int i = 0; i< 5; i++)
        {
            for (int k = 0; k < 10; k++)
            {
                _pData.d_BCDeck.Add(i);
            }
        }



        _pData.d_BCHand = new List<int>();
        _pData.d_BCHand.Add(-1);

        _fileName = "BasicPlayer.xml";
        _data = dTool.SerlializeObject(_pData, "Player");
        dTool.CreateXML(_data, _fileName, _fileLocation);

    }
    //맵 기본데이터 생성
    public void CreateMapData()
    {
        MapData mData = new MapData(30, 30);

        _fileName = "BasicMap.xml";
        _data = dTool.SerlializeObject(mData, "MapData");
        dTool.CreateXML(_data, _fileName, _fileLocation);
    }
    //아이템 데이터xml생성
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
    //웨폰 데이터xml생성
    public void CreateWeaponData()
    {
        WeaponData weapon = new WeaponData();
        WeaponList wLIst = new WeaponList();

        weapon.itemName = "BasicSword";
        weapon.price = 60;
        weapon.type = 1;
        weapon.damage = 30;
        weapon.durability = 100;
        weapon.imageAdress = "None";

        wLIst.wData = new List<WeaponData>();
        wLIst.wData.Add(weapon);
        _fileName = "WeaponList.xml";
        _data = dTool.SerlializeObject(wLIst, "WeaponList");
        dTool.CreateXML(_data, _fileName, _fileLocation);
    }
    //아머 데이터xml생성
    public void CreateArmorData()
    {
        ArmorData arm = new ArmorData();
        ArmorList armList = new ArmorList();

        arm.itemName = "BasicArmor";
        arm.price = 45;
        arm.type = 1;
        arm.defense = 20;
        arm.durability = 100;
        arm.imageAdress = "None";

        armList.aData = new List<ArmorData>();
        armList.aData.Add(arm);
        _fileName = "ArmorList.xml";
        _data = dTool.SerlializeObject(armList, "ArmorList");
        dTool.CreateXML(_data, _fileName, _fileLocation);
    }
    //타일 카드 데이터xml생성
    public void CreateTileCardData()
    {
        TileCard villiage = new TileCard(0, "Villiage", TileType.VILLIAGE, 0, "None", "None");
        TileCard forest = new TileCard(1, "Forest", TileType.FOREST, 1, "None", "None");
        TileCard cave = new TileCard(2, "Cave", TileType.CAVE, 2, "None", "None");
        TileCard river = new TileCard(3, "River", TileType.RIVER, 3, "None", "None");
        TileCard desert = new TileCard(4, "Desert", TileType.DESERT, 4, "None", "None");
        TileCard mountain = new TileCard(5, "Mountain", TileType.MOUNTAIN, 5, "None", "None");
        TileCard plain = new TileCard(6, "Plain", TileType.PLAIN, 6, "None", "None");
        TileCard dungeon = new TileCard(7, "Dungeon", TileType.DUNGEON, 7, "None", "None");
        TileCard Move2 = new TileCard(8, "Move2", TileType.VOID, 8, "None", "None");
        TileCard Move3 = new TileCard(9, "Move3", TileType.VOID, 9, "None", "None");

        TileCardList t_Data = new TileCardList();
        t_Data.tileCards.Add(villiage);
        t_Data.tileCards.Add(forest);
        t_Data.tileCards.Add(cave);
        t_Data.tileCards.Add(river);
        t_Data.tileCards.Add(desert);
        t_Data.tileCards.Add(mountain);
        t_Data.tileCards.Add(plain);
        t_Data.tileCards.Add(dungeon);
        t_Data.tileCards.Add(Move2);
        t_Data.tileCards.Add(Move3);

        _fileName = "TileCardList.xml";
        _data = dTool.SerlializeObject(t_Data, "TileCardList");
        dTool.CreateXML(_data, _fileName, _fileLocation);
    }
    //배틀 카드 데이터xml생성
    public void CreateBattleCardData()
    {
        BattleCard punch = new BattleCard(0, "Punch", SkillType.Knock, ElementType.Void, 0, "None", "None");
        BattleCard slash = new BattleCard(1, "Slash", SkillType.Cut, ElementType.Void, 1, "None", "None");
        BattleCard avoid = new BattleCard(2, "Avoidence", SkillType.Avoidence, ElementType.Void, 2, "None", "None");
        BattleCard guard = new BattleCard(3, "Guard", SkillType.Guard, ElementType.Void, 3, "None", "None");
        BattleCard fireBall = new BattleCard(4, "FireBall", SkillType.Magic, ElementType.Fire, 4, "None", "None");
        BattleCard createWater = new BattleCard(5, "CreateWater", SkillType.Magic, ElementType.Water, 5, "None", "None");
        BattleCard freeze = new BattleCard(6, "Freeze", SkillType.Magic, ElementType.Ice, 6, "None", "None");
        BattleCard electricShock = new BattleCard(7, "ElectricShock", SkillType.Magic, ElementType.Electricity, 7, "None", "None");
        BattleCard holyWave = new BattleCard(8, "HolyWave", SkillType.Magic, ElementType.Holy, 8, "None", "None");
        BattleCard darkBall = new BattleCard(9, "DarkBall", SkillType.Magic, ElementType.Dark, 9, "None", "None");
        BattleCard buffAttck = new BattleCard(10, "AttackBuff", SkillType.Spell, ElementType.Void, 10, "None", "None");
        BattleCard recovery = new BattleCard(11, "Recovery", SkillType.Recovery, ElementType.Void, 11, "None", "None");
        BattleCard slash_Flame = new BattleCard(12, "FlameSlash", SkillType.Cut, ElementType.Fire, 12, "None", "None");

        BattleCardLIst b_Data = new BattleCardLIst();

        b_Data.battleCards.Add(punch);
        b_Data.battleCards.Add(slash);
        b_Data.battleCards.Add(avoid);
        b_Data.battleCards.Add(guard);
        b_Data.battleCards.Add(fireBall);
        b_Data.battleCards.Add(createWater);
        b_Data.battleCards.Add(freeze);
        b_Data.battleCards.Add(electricShock);
        b_Data.battleCards.Add(holyWave);
        b_Data.battleCards.Add(darkBall);
        b_Data.battleCards.Add(buffAttck);
        b_Data.battleCards.Add(recovery);
        b_Data.battleCards.Add(slash_Flame);

        _fileName = "BattleCardLIst.xml";
        _data = dTool.SerlializeObject(b_Data, "BattleCardList");
        dTool.CreateXML(_data, _fileName, _fileLocation);

    }
    //몬스터 데이터xml생성
    public void CreatMosterData()
    {
        MonsterList mDataBase = new MonsterList();
        mDataBase.monsterList = new List<MonsterData>();

        MonsterData mData = new MonsterData();
        mData.charName = "Evil Mushroom";
        mData.level = 1;
        mData.def = 1.5f;
        mData.maxHp = 1.5f;
        mData.dHp = 0;
        mData.maxMp = 1.0f;
        mData.dMp = 0;
        mData.modelAdress = "ProtoAsset/Forest Creatures Pack/Evil Mushroom/Prefabs/Evil Mushroom-Blue";
        mData.attackList = new List<string>();
        mData.attackList.Add("Punch");
        mData.defenseList = new List<string>();
        mData.defenseList.Add("None");
        mData.skillList = new List<string>();
        mData.skillList.Add("Apeal");
        mData.style = 1;
        mData.extra ="None";

        mDataBase.monsterList.Add(mData);

        _fileName = "MonsterList.xml";
        _data = dTool.SerlializeObject(mDataBase, "MonsterList");
        dTool.CreateXML(_data, _fileName, _fileLocation);
       
    }
    //던전 데이터xml생성
    public void CreateDungeonData()
    {
        DungeonData dData = new DungeonData();
        dData.d_Name = "Forest";
        dData.dungeonType = 1;
        dData.dungeonLength = 1;
        dData.dungeonLevel = 2;
        dData.level1 = new List<string>();
        dData.level1.Add("Evil Mushroom");
        dData.level1.Add("Nymph Fairy");
        dData.level2 = new List<string>();
        dData.level2.Add("Forest Wolf");
        dData.level2.Add("Monster Bee");
        dData.level3 = new List<string>();
        dData.level3.Add("None");
        dData.level4 = new List<string>();
        dData.level4.Add("None");

        DungeonList dungeonList = new DungeonList();
        dungeonList.d_List = new List<DungeonData>();
        dungeonList.d_List.Add(dData);

        _fileName = "DungeonList.xml";
        _data = dTool.SerlializeObject(dungeonList, "DungeonList");
        dTool.CreateXML(_data, _fileName, _fileLocation);
    }

}
