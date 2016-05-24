using UnityEngine;
using System.Collections;

namespace Dungeon
{
    public struct position
    {
       public int x;
       public int z;
    }
    public class DungeonTile : MonoBehaviour
    {
        public position pos;
        public bool road = false;
        public GameObject[] spawnPoint = new GameObject[3];
        public GameObject[] monsters;
        public int size;
        //임시용
        // public GameObject[] monsterPrf = new GameObject[3];
        public DungeonEdge[] d_Edge = new DungeonEdge[4];


        public void Init()
        {
            monsters = new GameObject[3];
            size = 0;
        }
        public void GenerateMonster(GameObject originalObj)
        {
            if(size < 3)
            {
                monsters[size] = Instantiate(originalObj,
                    spawnPoint[size].transform.position,
                    spawnPoint[size].transform.rotation) as GameObject;
                monsters[size].transform.parent = gameObject.transform;
                size++;

            }
        }
        public void ActiveControlAllMonster(bool act)
        {
            for(int k =0; k < monsters.Length; k++)
            {
                monsters[k].SetActive(act);
            }
        }

    }


    public class DungeonEdge
    {
        public DungeonTile from;
        public DungeonTile to;

        public DungeonEdge() { }
        public DungeonEdge(DungeonTile f, DungeonTile t)
        {
            from = f;
            to = t;
        }

    }
}
