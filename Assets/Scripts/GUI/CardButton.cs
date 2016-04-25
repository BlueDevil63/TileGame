using UnityEngine;
using System.Collections;
using CardCollections;

public class CardButton : MonoBehaviour {
    [SerializeField]
    public int number;
    private InGameMgr inGameMgr;

    public void Use()
    { 
        if(number != -1)
        {
            GameManager.instance.SelectCard(number);
        }
    }
}
