using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

    private GameObject inGameCardScrollObj;
    public CardScroll inGameCardScroll;

    private GameObject battleCardScrollObj;
    public CardScroll battleCardScroll;

    private GUI_Bar hpBar;
    private GUI_Bar mpBar;

    public void Init()
    {
        if(GameManager.instance.SceneName() == "InGame")
        {
            Debug.Log("findScene");
            inGameCardScrollObj = GameObject.FindGameObjectWithTag("CardScroll");
            inGameCardScroll = inGameCardScrollObj.GetComponent<CardScroll>();

           
        }
        if (GameManager.instance.SceneName() == "Battle")
        {
            battleCardScrollObj = GameObject.FindGameObjectWithTag("CardScroll");
            battleCardScroll = battleCardScrollObj.GetComponent<CardScroll>();
        }

        GameObject hpObj = GameObject.FindGameObjectWithTag("PlayerHpBar");
        hpBar = hpObj.GetComponent<GUI_Bar>();

        GameObject mpObj = GameObject.FindGameObjectWithTag("PlayerMpBar");
        mpBar = mpObj.GetComponent<GUI_Bar>();
    }


    public void HpUpDate(float max, float damage)
    {
        hpBar.BarUpdate(max, damage, 0);
    }

    public void MpUpDate(float max, float damage)
    {
        mpBar.BarUpdate(max, damage, 1);
    }


}
