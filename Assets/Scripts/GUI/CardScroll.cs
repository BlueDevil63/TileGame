using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TileCollections;
using CardCollections;

public class CardScroll : ItemScroll {
    //카드의 수
   // public int count;
    private List<GameObject> cardImage = null;
    // Use this for initialization

    public GameObject item;
    private float movPos;           //움질일 스크롤의 위치
    private float curPos;           //스크롤의 현재 위치
    private float minPos;           //최소 위치
    private float maxPos;           //최대 위치
    private RectTransform localPos = null;

    public int usingNum = 0;


    public void SetUpCard(Player player)
    {
        ///1. 카드 개수 확인
        ///2. 처음이므로 자동으로 카드 뽑기
        ///3. itemScroll의 상속함수를 이용하여 카드를 생성
        ///4. 생성한 카드의 스프라이트 이미지를 리소스 로드를 통하여 교체한다.
        //만들 이미지 리스트를 초기화
        cardImage = new List<GameObject>();
        
        //GameManager.instance.
        //스크롤 생성
        cardImage = AdvenceSideScorll(10, item);
        //위치값 초기화
        localPos = gameObject.GetComponent<RectTransform>();
        curPos = localPos.localPosition.x;
        movPos = localPos.rect.xMax - localPos.rect.xMax / 7;
        //이미지 교체
        ChangeImage(player);

        maxPos = - localPos.rect.width/2;
        minPos = localPos.rect.width /2;
        movPos = maxPos;
        curPos = movPos;
       StartCoroutine(Scrolling(true));
    }
    public void UseCard(Player player)
    {
        ChangeImage(player);

        if(player.handCard.Count <= 0)
        {
            Debug.Log("Pop");
            player.InGamePopCard();
        }
    }

    public void PopCard(Player player)
    {
        ChangeImage(player);
     
        maxPos = -localPos.rect.width / 2;
        minPos = localPos.rect.width / 2;
        movPos = maxPos;
        curPos = movPos;
        StartCoroutine(Scrolling(true));
    }


    public void Right()
    {
        //if (curPos >= minPos + (localPos.rect.width / 9) * (8 - (GameManager.instance.curPlayer.handCard.Count)))
        //{
        //if (BattleMgr.Instance.cardM.handCards.Count < BattleMgr.Instance.cardM.selnumber)
        //{
        //    BattleMgr.Instance.cardM.selnumber = BattleMgr.Instance.cardM.handCards.Count;
        //}
        //if (curPos >= minPos)
        //{
            movPos = curPos - (localPos.rect.width / 7);
            curPos = movPos;
            StartCoroutine(Scrolling(true));
        //}
    }
    public void Left()
    {
        //if ( curPos < maxPos)
        //{
           // Debug.Log("방향체크" + BattleMgr.Instance.cardM.selnumber);
           // BattleMgr.Instance.cardM.selnumber--;

            //if (0 > BattleMgr.Instance.cardM.selnumber)
            //{
            //    Debug.Log("체크");
            //    BattleMgr.Instance.cardM.selnumber = 0;
            //}
            movPos = curPos + (localPos.rect.width / 7);
            curPos = movPos;
            StartCoroutine(Scrolling(true));
        //}
    }

    IEnumerator Scrolling(bool isScroll)
    {
        while (isScroll)
        {
            localPos.localPosition = Vector2.Lerp(localPos.localPosition, new Vector2(movPos, 60), Time.deltaTime * 5);
            //Debug.Log(Vector2.Distance(containerRectTrans.localPosition, new Vector2(movPos, 0)));
            if (Vector2.Distance(localPos.localPosition, new Vector2(movPos, 60)) < 0.1f)
            {
                isScroll = false;
            }

        }
        yield return null;
    }

    private void ChangeImage(Player player)
    {
        TileCard _sprite = new TileCard(0, string.Empty, TileType.NONE, 0, string.Empty, null);

        GameObject change;

        int count = player.handCard.Count;

        int num = count + 2;

        int cardNum = 0;
        for (int i = 0; i < 10; i++)
        {
            if (i > 0 && i <= count)
            {
                /// D 0 1 2 3 4 D   D = 더미 아무것도 없는 더미를 만든다. 선택이 불가능(없음)하다는 표시
               ///  0 1 2 3 4 5 6   생성수
                ///  
               //Debug.Log("drawCard = "+i);
                change = cardImage[i];
                _sprite = player.handCard[i - 1];
                change.GetComponent<Image>().sprite = Resources.Load<Sprite>(_sprite.imageAddress);
                change.GetComponent<CardButton>().number = cardNum;
                cardNum++;
            }
            else
            {
                //  Debug.Log("drawBlock = " + i);
                change = cardImage[i];
                change.GetComponent<Image>().sprite = Resources.Load<Sprite>("Card/None");
                change.GetComponent<CardButton>().number = -1;
            }
        }
    }

}