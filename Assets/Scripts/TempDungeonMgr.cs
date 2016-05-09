using UnityEngine;
using System.Collections;
using DataSpace;
using DataSpace.Battle;
using Dungeon;
public class TempDungeonMgr {

    protected DungeonTile[] dungeon;
    protected GameObject[] tileObj;
    protected GameObject dungeonTileObj;
    protected DungeonData m_dungeonData;
    protected GameObject dungeonParent;

    private float tileTerm = 30f; //타일간의 간격


    public void GenerateDungeon()
    {
        LoadDungeonData();
        SearchTileObject();
        Tiling(m_dungeonData.dungeonLength);
    }

    private void LoadDungeonData()
    {
        m_dungeonData = GameManager.instance.m_DataManager.LoadDungeonData(GameManager.instance.dungeonName);
    }

    private void SearchTileObject()
    {
        string address = "Prefabs/Battle/Tile/";
        switch (m_dungeonData.dungeonType)
        {
            case 0:
                dungeonTileObj = Resources.Load<GameObject>(address + "prfCaveTile");
                break;
            case 1:
                dungeonTileObj = Resources.Load<GameObject>(address + "prfForestTile");
                break;
            case 2:
                dungeonTileObj = Resources.Load<GameObject>(address + "prfDungeonTile");
                break;
            case 3:
                dungeonTileObj = Resources.Load<GameObject>(address + "prfDungeonTile");
                break;
            default:
                Debug.LogError("잘못된 타입정보");
                break;
        }
        try
        {
            dungeonParent = GameObject.Find("Dungeon");
        }
        catch
        {
            Debug.LogError("찾지못했습니다.");
        }

    }

    private void Tiling(int length)
    {
        Vector3 pos = new Vector3(0, 0, 0);
        tileObj = new GameObject[length];
        dungeon = new DungeonTile[length];
        for(int k = 0;  k< length; k++)
        {
            pos.z = k * tileTerm;
            tileObj[k] = GameObject.Instantiate(dungeonTileObj, pos, dungeonTileObj.transform.rotation) as GameObject;
            tileObj[k].transform.parent = dungeonParent.transform;
            dungeon[k] = tileObj[k].GetComponent<DungeonTile>();
        }
    }
    private void PositioningMonster()
    {

    }
	
}
