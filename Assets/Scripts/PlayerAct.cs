using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TileCollections;

public class PlayerAct : MonoBehaviour {
    // public GameObject villiageMassage;
    // public GameObject dungeonMassage;
    public GameObject massageObject;
    public Text massage;

    public bool mComfirm;

    public void Init()
    {
        massageObject.SetActive(false);
        mComfirm = false;
    }
    public bool SelcetAct(Player player, TileMapdData mdata)
    {
        switch( mdata.data[ player.pos_x ,player.pos_y].type)
        {
            case TileType.VILLIAGE :
                massage.text = "마을에 도착하였습니다.";
                break;
            case TileType.DUNGEON :
                massage.text = "던전에 들어갑니다.";
                break;
            case TileType.CAVE :
                massage.text = "동굴에 들어갑니다.";
                break;
            case TileType.FOREST :
                massage.text = "숲속으로 진입합니다";
                break;
        }
        massageObject.SetActive(true);
        return false;
    }
    public void MassageComfirm()
    {
        mComfirm = true;
    }

}
