using UnityEngine;
using System.Collections;


public class DungeonTile : MonoBehaviour {

    public GameObject[] spawnPoint = new GameObject[3];
    public GameObject[] monsters = new GameObject[3];
    //임시용
    public GameObject[] monsterPrf = new GameObject[3];

    public void CreateMonster()
    {
       // monsters = new GameObject[3];
        for(int k = 0; k< 3; k++)
        {
            monsters[k] = Instantiate(monsterPrf[k], spawnPoint[k].transform.position, spawnPoint[k].transform.rotation) as GameObject;
        }
    }
}
