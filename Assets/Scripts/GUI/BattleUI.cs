using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleUI : MonoBehaviour {
    [SerializeField]
    private Text[] monsterName = new Text[3];
    [SerializeField]
    private GameObject[] monsterGui = new GameObject[3];
    [SerializeField]
    private GUI_Bar[] hpBar = new GUI_Bar[3];
    /*
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void Init()
    {
        hpBar[0] = monsterGui[0].GetComponent<GUI_Bar>();
        hpBar[1] = monsterGui[1].GetComponent<GUI_Bar>();
        hpBar[2] = monsterGui[2].GetComponent<GUI_Bar>();
    }
    */
    public void InsertMonster(MonsterBasic[] monster)
    {
        for(int k= 0; k< monster.Length; k++)
        {
            monsterName[k].text = monster[k].status.charName;
            hpBar[k].BarUpdate(monster[k].status.maxHp, monster[k].status.dHp, 0);
        }
    }
}
