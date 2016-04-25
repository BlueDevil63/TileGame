using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

    private GameObject inGameCardScrollObj;
    public CardScroll inGameCardScroll;

    private GameObject battleCardScrollObj;
    public CardScroll battleCardScroll;

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
    }
	

}
