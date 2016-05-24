using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourTree;
using DataSpace;

public class MonsterBasic : BlackBoard {
    /*
    public string charName;
    public float level;
    public float def;
    public float maxHp;
    public float dHp;
    public float maxMp;
    public float dMp;
    public List<string> attackList;
    public List<string> defenseList;
    public List<string> skillList;
    public int style;
    public string extra;
    
 
    public int actPoint;
    */
    public MonsterData status;
    public int pos;         //1~6까지 있음 1~3 전방 4~6 후방 1부터 좌측
                            //FSM을 사용한다.
   // public GameObject target;

    public void Init()
    {
        status = new MonsterData();
        target = null;
    }

    public void SetBeheviourTree()
    {
        //Ai타입에 따라 넣어지는 순서가 달라짐(성향)
    }
    //행동을 선택한다.
    public void SelectBeheviour()
    {

    }

}
