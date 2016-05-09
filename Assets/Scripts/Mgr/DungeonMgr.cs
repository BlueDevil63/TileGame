using UnityEngine;
using System.Collections;
using DataSpace;
using DataSpace.Battle;
using Dungeon;

namespace Dungeon
{
    public class DungeonMgr
    {
        public position startPoint;
        protected DungeonData d_DungeonData;
        protected MonsterList d_MonsterList;
        private GameObject tileObj;
        public GameObject t_Dungeon;


        public DungeonTile[,] dungeon;

        public DungeonMgr()
        {
            d_DungeonData = new DungeonData();
            d_MonsterList = new MonsterList();
            dungeon = new DungeonTile[60, 60];
            for(int i = 0; i< 60; i++)
            {
                for (int k = 0; k < 60; k++)
                {
                    dungeon[i, k].pos.x = i;
                    dungeon[i, k].pos.z = k;
                }
            }

        }

        public void Generate()
        {
            LoadData();
            SettingObjectPool();    //오브젝트풀에 몬스터 정보를 불러와 넣어준다.
            GenerateDungeon();      //자동적으로 던전을 생성시킨다.
            PositioningMonster();   //몬스터를 위치시킨다.
            SetActvieDungeon();     //던전의 SetActvie를 조정한다.

        }

        private void LoadData()
        {
            d_DungeonData = GameManager.instance.m_DataManager.LoadDungeonData(GameManager.instance.dungeonName);
            d_MonsterList = GameManager.instance.m_DataManager.LoadMonsterList();
        }

        private void GenerateDungeon()
        {
            startPoint.x = Random.Range(0, 59);
            startPoint.z = Random.Range(0, 59);

            string path = "/Prefabs/Battle/Tile/";
            switch (d_DungeonData.d_Name)
            {
                case "Forest":
                    tileObj = Resources.Load<GameObject>(path + "prfForestTile");
                    break;
                case "Cave":
                    tileObj = Resources.Load<GameObject>(path + "prfCaveTile");
                    break;
                case "Dungeon":
                    tileObj = Resources.Load<GameObject>(path + "prfDungeonTile");
                    break;
            }
            dungeon[startPoint.x, startPoint.z].road = true;
            GenerateTile(0,d_DungeonData.dungeonLength, startPoint);
        }

        private int GenerateTile(int build, int length, position pos)
        {
            if (build == length)
            {
                return build;
            }
            else
            {
                position buildPos;
                //현재 좌표에서 랜덤으로 좌상우하의 새로운 타일을 설치.
                //타일이 설치되있는 지를 체크하고 설치 - false라면 설치, true라면 다른 타일을 찾아서 함
                //그후 인자의 타일과 현재 설치한 타일을 에지로 연결시킨다.
               // build = GenerateTile(build++, length, buildPos);
                return build;
            }
            

        }

        private void SettingObjectPool()
        {

        }

        private void PositioningMonster()
        {

        }
        private void SetActvieDungeon()
        {
            //몬스터의 SetActive 시킨다.

        }
        private void AddDungeon()
        {

        }

    }
}
