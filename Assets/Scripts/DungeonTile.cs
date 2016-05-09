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
        public GameObject[] monsters = new GameObject[3];
        //임시용
        // public GameObject[] monsterPrf = new GameObject[3];
        public DungeonEdge[] d_Edge = new DungeonEdge[4];

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
