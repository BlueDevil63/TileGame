using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourTree;

public class MonsterBasic : BlackBoard {

    public string charName;
    public float level;
    public float def;
    public float maxHp;
    public float dHp;
    public float maxMp;
    public float dMp;
    public int actPoint;
    public List<string> attackList;
    public List<string> defenseList;
    public List<string> skillList;
    public int style;
    public string extra;
    public int pos;         //1~6까지 있음 1~3 전방 4~6 후방 1부터 좌측
                            //FSM을 사용한다.

    public void SetBeheviourTree()
    {

    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //public MonsterBasic() { }
    //public MonsterBasic(string vname, float vlevel, float vDef, float vHP, float vMP, List<string> at, List<string> df, List<string> sk, int st, int vExtra)
    //{

    //}
}
