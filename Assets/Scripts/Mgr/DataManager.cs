using UnityEngine;
using System.Collections;
using CardCollections;
using DataSpace;
using DataSpace.Battle;
using TileCollections;

public class DataManager : DataTools {

    private string f_Name;
    private string f_Location = Application.dataPath + "/Resources/Data";
    protected string f_Data;
    
#if UNITY_EDITOR
    private string path = Application.dataPath + "/Resources/Data";
#elif UNITY_ANDROID
   private string path = Application.persistentDataPath;
#endif
    public void SaveDungeonList(DungeonList dungeon)
    {
        f_Name = "DungeonList.xml";
        f_Data = SerlializeObject(dungeon, "DungeonList");
        CreateXML(f_Data, f_Name, f_Location);
    }

    public void SavePlayerData(PlayerData player, string type)
    {
        string location;
        if (type == "Basic")
        {
            f_Name = "BasicPlayer.xml";
            location = f_Location;
        }
        else
        {
            f_Name = type + ".xml";
            location = path;
        }
        f_Data = SerlializeObject(player, "Player");
        CreateXML(f_Data, f_Name, location);
    }

    public void SaveMonsterData(MonsterList monster)
    {
        f_Name = "MonsterList.xml";
        f_Data = SerlializeObject(monster, "MonsterList");
        CreateXML(f_Data, f_Name, f_Location);
    }

    public void SaveItemData(ItemList item)
    {
        f_Name = "ItemList.xml";
        f_Data = SerlializeObject(item, "ItemList");
        CreateXML(f_Data, f_Name, f_Location);
    }

    public void SaveWeaponData(WeaponList weapon)
    {
        f_Name = "WeaponList.xml";
        f_Data = SerlializeObject(weapon, "WeaponList");
        CreateXML(f_Data, f_Name, f_Location);
    }

    public void SaveArmorData(ArmorList arm)
    {
        f_Name = "ArmorList.xml";
        f_Data = SerlializeObject(arm, "ArmorList");
        CreateXML(f_Data, f_Name, f_Location);
    }

    public void SaveTileCardData(TileCardList tile)
    {
        f_Name = "TileCardList.xml";
        f_Data = SerlializeObject(tile, "TileCardList");
        CreateXML(f_Data, f_Name, f_Location);
    }

    public void SaveBattleCardData(BattleCardLIst battle)
    {
        f_Name = "BattleCardLIst.xml";
        f_Data = SerlializeObject(battle, "BattleCardLIst");
        CreateXML(f_Data, f_Name, f_Location);
    }

    public DungeonList LoadDungeonList()
    {
        f_Name = "DungeonList.xml";
        f_Data = LoadXML(f_Name, f_Location);
        DungeonList m_DungeonList = (DungeonList)DeserializeObject(f_Data, "DungeonList");
        return m_DungeonList;
    }
    public DungeonData LoadDungeonData(string s_Name)
    {
        DungeonData m_Dungeon = new DungeonData();
        DungeonList m_DungeonList = LoadDungeonList();
        for (int i = 0; i < m_DungeonList.d_List.Count; i++)
        {
            if (m_DungeonList.d_List[i].d_Name == s_Name)
            {
                m_Dungeon = m_DungeonList.d_List[i];
            }
        }
        return m_Dungeon;
    }

    public PlayerData LoadPlayerData(string p_Name)
    {
        string location = string.Empty;
        if (p_Name == "None")
        {
            f_Name = "BasicPlayer.xml";
            location = f_Location;
        }
        else
        {
            f_Name = p_Name + ".xml";
            location = path;
        }
        f_Data = LoadXML(f_Name, location);
        PlayerData d_Player = (PlayerData)DeserializeObject(f_Data, "Player");
        return d_Player;
    }

    public MonsterList LoadMonsterList()
    {
        f_Name = "MonsterList.xml";
        f_Data = LoadXML(f_Name, f_Location);
        MonsterList d_MonsterList = (MonsterList)DeserializeObject(f_Data, "MonsterList");
        return d_MonsterList;
    }
    public MonsterData LoadMonsterData(string monsterName)
    {

        MonsterList d_MonsterList = LoadMonsterList();
        MonsterData d_Monster = new MonsterData();

        for(int k = 0;  k< d_MonsterList.monsterList.Count; k++)
        {
           if(d_MonsterList.monsterList[k].charName == monsterName)
            {
                d_Monster = d_MonsterList.monsterList[k];
            }
        }

        return d_Monster;
    }

    public ItemList LoadItemList()
    {
        f_Name = "ItemList.xml";
        f_Data = LoadXML(f_Name, f_Location);
        ItemList d_ItemList = (ItemList)DeserializeObject(f_Data, "ItemList");

        return d_ItemList;
    }
    public ItemData LoadItemData(string itemName)
    {
        ItemList d_ItemList = LoadItemList();
        ItemData d_item = new ItemData();

        for(int k = 0; k< d_ItemList.iData.Count; k++)
        {
            if (d_ItemList.iData[k].itemName == itemName)
                d_item = d_ItemList.iData[k];
        }
        return d_item;
    }

    public WeaponList LoadWeaponList()
    {
        f_Name = "WeaponList.xml";
        f_Data = LoadXML(f_Name, f_Location);
        WeaponList d_WeaponList = (WeaponList)DeserializeObject(f_Data, "WeaponList");

        return d_WeaponList;
    }
    public WeaponData LoadWeaponData(string weaponName)
    {
        WeaponList d_WeaponList = LoadWeaponList();
        WeaponData d_Weapon = new WeaponData();

        for(int k = 0; k< d_WeaponList.wData.Count; k++)
        {
            if (d_WeaponList.wData[k].itemName == weaponName)
                d_Weapon = d_WeaponList.wData[k];
        }

        return d_Weapon;
    }

    public ArmorList LoadArmorList()
    {
        f_Name = "ArmorList.xml";
        f_Data = LoadXML(f_Name, f_Location);
        ArmorList d_ArmorList = (ArmorList)DeserializeObject(f_Data, "ArmorList");

        return d_ArmorList;
    }
    public ArmorData LoadArmorData(string armorName)
    {
        ArmorList d_ArmorList = LoadArmorList();
        ArmorData d_Armor = new ArmorData();
        
        for(int k = 0; k< d_ArmorList.aData.Count; k++)
        {
            if (d_ArmorList.aData[k].itemName == armorName)
                d_Armor = d_ArmorList.aData[k];
        }

        return d_Armor;
    }

    public TileCardList LoadTileCardList()
    {
        f_Name = "TileCardList.xml";
        f_Data = LoadXML(f_Name, f_Location);
        TileCardList d_TileCardList = (TileCardList)DeserializeObject(f_Data, "TileCardList");

        return d_TileCardList;
     }
    public TileCard LoadTileCardData(string tileCardName)
    {
        TileCardList d_TileCardList = LoadTileCardList();
        TileCard d_TileCard = new TileCard();

        for(int k = 0; k<d_TileCardList.tileCards.Count; k++)
        {
            if (d_TileCardList.tileCards[k].cardName == tileCardName)
                d_TileCard = d_TileCardList.tileCards[k];
        }

        return d_TileCard;
    }

    public BattleCardLIst LoadBattleCardList()
    {
        f_Name = "BattleCardLIst.xml";
        f_Data = LoadXML(f_Name, f_Location);
        BattleCardLIst d_BattleCardLIst = (BattleCardLIst)DeserializeObject(f_Data, "BattleCardLIst");

        return d_BattleCardLIst;
    }
    public BattleCard LoadBattleCardData(string battleCardName)
    {
        BattleCardLIst d_BattleCardLIst = LoadBattleCardList();
        BattleCard d_BattleCard = new BattleCard();

        for (int k = 0; k < d_BattleCardLIst.battleCards.Count; k++)
        {
            if (d_BattleCardLIst.battleCards[k].cardName == battleCardName)
                d_BattleCard = d_BattleCardLIst.battleCards[k];
        }

        return d_BattleCard;
    }

}
