﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TileCollections;


public class InGameMgr :MonoBehaviour {


    public enum InGameState
    {
        None,
        SetGame,
        Pause,
        PopCard,
        UseCard,
        MovePlayer,
        ActPlayer,
        Ready
    }
    delegate void FsmFunc();

    Dictionary<InGameState, FsmFunc> inGameDic = new Dictionary<InGameState, FsmFunc>();

    private InGameState gState;
    [HideInInspector]
    public bool buildMode;
    //[HideInInspector]
    //public bool isSelect;
    [HideInInspector]
    public bool isBuild;
   // [HideInInspector]
   // public int cardNumber;

    public GameObject _playerObj;

    [HideInInspector]
    public GameObject tileObj;

    //[HideInInspector]
    public TileType buildType;

    private PlayerMove move;
    public GameObject movePanel;
    private PlayerAct act;
    public TileMapMouse mouse;
    public Text curPlayerText;     //현재 플레이어 텍스트
    public Text curAct;            //현재 턴 진행사항
    

    // Use this for initialization
    void Start()
    {
        inGameDic[InGameState.Pause] = Pause;
        inGameDic[InGameState.PopCard] = PopCard;
        inGameDic[InGameState.UseCard] = UseCard;
        inGameDic[InGameState.MovePlayer] = MovePlayer;
        inGameDic[InGameState.ActPlayer] = ActPlayer;
        inGameDic[InGameState.SetGame] = SetGame;

        tileObj = null;

        movePanel.SetActive(false);
        move = gameObject.GetComponent<PlayerMove>();
        act = gameObject.GetComponent<PlayerAct>();
        act.Init();
        buildMode = false;
       // isSelect = false;                  //카드를 선택했는가?
        isBuild = false;                   //카드를 설치했는가?

        gState = InGameState.SetGame;
    }


    void Update()
    {
        inGameDic[gState]();
    }



    private void Pause()
    {

    }

    private void SetGame()
    {

        if(GameManager.instance.loadCount == 0)
        {
            GameManager.instance._player = _playerObj.GetComponent<Player>();
            Debug.Log("처음");
            buildType = TileType.NONE;
            GameManager.instance._player.InGameInit();
            GameManager.instance._player.InGameStart();
            GameManager.instance.pIndex = 0;
            GameManager.instance.loadCount++;
        }
        else
        {

        }

        gState = InGameState.PopCard;
    }

    private void PopCard()
    {
        curAct.text = "카드 드로우";
       // GameManager.instance._player = GameManager.instance.playerList[GameManager.instance.pIndex];
        GameManager.instance._player.InGamePopCard();

        gState = InGameState.UseCard;
    }

    private void UseCard()
    {
        buildMode = true;
        curAct.text = "카드 사용";

        
        if (GameManager.instance._player.selectCard.cardName != string.Empty)
        {
             GameManager.instance.isSelect = true;
        }
        if (GameManager.instance.isSelect == true)
        {
            tileObj = Resources.Load( GameManager.instance._player.handCard[GameManager.instance.cardNumber].prfObjAddress) as GameObject;
        }

       if (isBuild)
        {
            buildType = GameManager.instance._player.Build(GameManager.instance.cardNumber);
            mouse.SetBuildType(buildType);
            move.Init();
            gState = InGameState.MovePlayer;
            isBuild = false;
            GameManager.instance.isSelect = false;
            Debug.Log(buildType);
            buildType = TileType.NONE;
        }
    }

    private void MovePlayer()
    {
        movePanel.SetActive(true);
        buildMode = false;
        
        curAct.text = "플레이어 이동";
       if(move.Move(_playerObj, GameManager.instance.mData))
        {
            GameManager.instance._player.pos_x = move.PosX();
            GameManager.instance._player.pos_y = move.PosY();
            movePanel.SetActive(false);
            act.Init();
            gState = InGameState.ActPlayer;
        }
    }

    private void ActPlayer()
    {
        curAct.text = "행동 선택";
        if(act.SelcetAct(GameManager.instance._player, GameManager.instance.mData))
        {
            if(act.mComfirm)
            {
                gState = InGameState.Ready;
                GameManager.instance._player = GameManager.instance._player;
                GameManager.instance.nextBattle = true;
            }
        }
    }
 

}
