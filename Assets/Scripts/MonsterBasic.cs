using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterBasic : MonoBehaviour {

    public string charName;
    public float level;
    public float def;
    public float hp;
    public float mp;
    public List<string> attackList;
    public List<string> defenseList;
    public List<string> skillList;
    public int style;
    public string extra;
    public int pos;         //1~6까지 있음 1~3 전방 4~6 후방 1부터 좌측
                            //FSM을 사용한다.

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
