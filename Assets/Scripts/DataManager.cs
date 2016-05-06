using UnityEngine;
using System.Collections;
using CardCollections;
using DataSpace;
using DataSpace.Battle;
using TileCollections;

public class DataManager : DataTools {

    private string f_Name;
    private string f_Location = Application.dataPath + "/Resources/Data";
    protected string f_data;
    
#if UNITY_EDITOR
    private string path = Application.dataPath + "/Resources/Data";
#elif UNITY_ANDROID
   private string path = Application.persistentDataPath;
#endif
    public void SaveDungeonList(DungeonList dungeon)
    {
        f_Name = "DungeonList.xml";
        f_data = SerlializeObject(dungeon, "DungeonList");
        CreateXML(f_data, f_Name, f_Location);
    }

    public void SavePlayerData(PlayerData player, string type)
    {
        if (type == "Basic")
        {
            f_Name = "BasicPlayer.xml";
        }
        else
        {
            f_Name = type + ".xml";
            f_Location = path;
        }
        f_data = SerlializeObject(player, "Player");
        CreateXML(f_data, f_Name, f_Location);
    }
    public void SaveMonsterData(MonsterList monster)
    {
        f_Name = "MonsterList.xml";
        f_data = SerlializeObject(monster, "MonsterList");
        CreateXML(f_data, f_Name, f_Location);
    }
    public void SaveItemData(ItemList item)
    {
        f_Name = "ItemList.xml";
        f_data = SerlializeObject(item, "ItemList");
        CreateXML(f_data, f_Name, f_Location);
    }
    public void SaveWeaponData(WeaponList weapon)
    {
        f_Name = "WeaponList.xml";
        f_data = SerlializeObject(weapon, "WeaponList");
        CreateXML(f_data, f_Name, f_Location);
    }
    public void SaveArmorData(ArmorList arm)
    {
        f_Name = "ArmorList.xml";
        f_data = SerlializeObject(arm, "ArmorList");
        CreateXML(f_data, f_Name, f_Location);
    }
    public void SaveTileCardData()
    {

    }
    public void SaveBattleCardData()
    {

    }
    public DungeonList LoadDungeonList()
    {
        f_Name = "DungeonList.xml";
        f_data = LoadXML(f_Name, f_Location);
        DungeonList m_DungeonList = (DungeonList)DeserializeObject(f_data, "DungeonList");
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

    public void LoadPlayerData()
    {

    }
    public void LoadMonsterData()
    {

    }
    public void LoadItemData()
    {

    }
    public void LoadWeaponData()
    {

    }
    public void LoadArmorData()
    {

    }
    public void LoadTileCardData()
    {

    }
    public void LoadBattleCardData()
    {

    }



}
