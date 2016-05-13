using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataSpace;
using DataSpace.Battle;
using Dungeon;
public class TempDungeonMgr : MonoBehaviour {

    //protected DungeonTile[] dungeon;
    protected GameObject[] tileObj;
    protected GameObject dungeonTileObj;
    protected DungeonData m_dungeonData;
    protected GameObject dungeonParent;
    private List<GameObject> monsterList1;
    private List<GameObject> monsterList2;
    private List<GameObject> monsterList3;
    private List<GameObject> monsterList4;

    private float tileTerm = 30f; //타일간의 간격

    //던전생성을 담당
    public void GenerateDungeon()
    {
        LoadDungeonData();
        LoadMonsterList();
        SearchTileObject();
        Debug.Log("던전의 길이 = " + m_dungeonData.dungeonLength);

        Tiling(m_dungeonData.dungeonLength);
        PositioningMonster(m_dungeonData.dungeonLength, m_dungeonData.dungeonLevel);
    }
    //데이터 불러오기
    private void LoadDungeonData()
    {
        m_dungeonData = GameManager.instance.m_DataManager.LoadDungeonData(GameManager.instance.dungeonName);
    }
    //몬스터 정보 추출
    private void LoadMonsterList()
    {
        monsterList1 = new List<GameObject>();
        monsterList2 = new List<GameObject>();
        monsterList3 = new List<GameObject>();
        monsterList4 = new List<GameObject>();
        MonsterList mList = GameManager.instance.m_DataManager.LoadMonsterList();

        //MonsterData mMonster = new MonsterData();
        for (int count = 1; count <= m_dungeonData.dungeonLevel; count++)
        {
            switch (count)
            {
                case 1:
                    SearchMonsterData(m_dungeonData.level1, mList.monsterList, count);
                    break;
                case 2:
                    SearchMonsterData(m_dungeonData.level2, mList.monsterList, count);
                    break;
                case 3:
                    SearchMonsterData(m_dungeonData.level3, mList.monsterList, count);
                    break;
                case 4:
                    SearchMonsterData(m_dungeonData.level4, mList.monsterList, count);
                    break;
            }  
        }
    }
    //몬스터를 찾아서 해당 리스트에 넣어준다.
    private void SearchMonsterData(List<string> level, List<MonsterData> mList, int levelCount)
    {
      //  Debug.Log("level.Count = " + level.Count);
        GameObject monster = new GameObject();
        for (int k = 0; k < level.Count; k++)
        {
            for (int i = 0; i < mList.Count; i++)
            {
                //string리스트와 몬스터 리스트의 이름이 서로 같은가?(검색)
                if (level[k] == mList[i].charName)
                {
                    //정보에서 리소스주소를 찾아서 몬스터를 생성해준다.
                    monster = Resources.Load<GameObject>(mList[i].modelAdress);

                    switch(levelCount)                        //맞는 리스트에 넣어줌
                    {
                        case 1:
                            monsterList1.Add(monster);
                            Debug.Log("ADD");
                            break;
                        case 2:
                            monsterList2.Add(monster);
                            break;
                        case 3:
                            monsterList3.Add(monster);
                            break;
                        case 4:
                            monsterList4.Add(monster);
                            break;

                    }
                }
            }
        }
    }
    //MonsterData -> MonsterBasic 로 데이터 이동
    private MonsterBasic MoveMonsterData(MonsterBasic m_Basic, MonsterData mData)
    {
        m_Basic.charName = mData.charName;
        m_Basic.level = mData.level;
        m_Basic.def = mData.def;
        m_Basic.maxHp = mData.hp;
        m_Basic.maxMp = mData.mp;
        m_Basic.dHp = 0;
        m_Basic.dMp = 0;
        m_Basic.actPoint = 0;
        m_Basic.attackList = mData.attackList;
        m_Basic.defenseList = mData.defenseList;
        m_Basic.skillList = mData.skillList;
        m_Basic.style = mData.style;
        m_Basic.extra = mData.extra;
        m_Basic.pos = -1;

        return m_Basic;
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
        //dungeon = new DungeonTile[length];
        for(int k = 0;  k< length; k++)
        {
            pos.z = k * tileTerm;
            tileObj[k] = (GameObject)Instantiate(dungeonTileObj, pos, dungeonTileObj.transform.rotation);
            tileObj[k].transform.parent = dungeonParent.transform;
            tileObj[k].name = k.ToString();
           // dungeon[k] = tileObj[k].GetComponent<DungeonTile>();
           
        }
    }
    //몬스터를 배치시킨다.
    private void PositioningMonster(int length, int level)
    {
        int divid = length / level;         //나눈값
        int remain = length % level;        //나머지값 마지막 레벨은 이정도만 반복
        ///만약 5인데 레벨이 3단계라면, 
        ///2 2 1 씩된다.
        ///
        //int reDivid = remain / (level - divid);
        int number = 0;     //타일의 넘버
        for (int i = 1; i <= level; i++)
        {
            if ((divid * level) >= length) 
            {
                if ((number + 1) != (length - remain))
                {
                    for (int k = 0; k < divid; k++)
                    {
                        number = PositioningDungeon(number, i);
                    }
                }
                else
                {
                    number = PositioningDungeon(number, i);
                }
            }
            else
            {
                int ca = 0;
                if (i == level)
                    ca = remain;
                for (int k = 0; k < divid +ca; k++)
                {
                    number = PositioningDungeon(number, i);
                }
            }
        }
    }
    private int PositioningDungeon(int value, int level)
    {
        Debug.Log(value);
        int rand = 0;
        MonsterList mList = GameManager.instance.m_DataManager.LoadMonsterList();
        DungeonTile dungeon = tileObj[value].GetComponent<DungeonTile>();
        dungeon.Init();
        for(int m = 0;  m<3; m++)
        {
           // GameObject monster = new GameObject();
            switch (level)
            {
                case 1:
                    rand = Random.Range(0, monsterList1.Count);
                    Debug.Log("랜덤으로 나온수 = " + rand);
                    Debug.Log("몬스터리스트의 사이즈 = " + monsterList1.Count );
                    dungeon.GenerateMonster(monsterList1[rand]);
                    break;
                case 2:
                    rand = Random.Range(0, monsterList2.Count);
                    dungeon.GenerateMonster(monsterList2[rand]);
                    break;
                case 3:
                    rand = Random.Range(0, monsterList3.Count);
                    dungeon.GenerateMonster(monsterList3[rand]);
                    break;
                case 4:
                    rand = Random.Range(0, monsterList4.Count);
                    dungeon.GenerateMonster(monsterList4[rand]);
                    break;
            }
            dungeon.monsters[m].AddComponent<MonsterBasic>(); //몬스터 AI에 해당하는 부분을 넣어줌
            MonsterBasic m_Ai = dungeon.monsters[m].GetComponent<MonsterBasic>();   //할당
            m_Ai = MoveMonsterData(m_Ai, mList.monsterList[m]);                     //데이터를 이전

        }
        value += 1;
        return value;
    }
	
}
