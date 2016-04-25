using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemScroll : MonoBehaviour
{
   
    //횡 스크롤
    public void SideScorll(int itemCount, GameObject itemPrefab)
    {
        //아이템 프리팹의 트랜스폼
        RectTransform sideRectTrans = itemPrefab.GetComponent<RectTransform>();
        //컨테이너(스크롤 리스트)의 트랜스폼
        RectTransform containerRectTrans = gameObject.GetComponent<RectTransform>();
        //높이 = 컨테이너->로컬렉트크기 ->높이
        float height = containerRectTrans.rect.height;
        //기준비율 = 콘테이너 높이/ 아이템프리팹의 높이 
        float ratio = height / sideRectTrans.rect.height;
        //너비 = 아이템프리팹의 너비 * 비율
        float width = sideRectTrans.rect.width * ratio;
        //스크롤 너비 = 너비 * 개수
        float ScrollWidth = width * itemCount;
        //오프셋 최소 = - 스크롤의 길이/ 2  ,  컨테이너 오프셋 최소 y
        containerRectTrans.offsetMin = new Vector2(-ScrollWidth / 2, containerRectTrans.offsetMin.y);
        //오프셋 최소 = - 스크롤의 길이/ 2  ,  컨테이너 오프셋 최소 y
        containerRectTrans.offsetMax = new Vector2(ScrollWidth / 2, containerRectTrans.offsetMax.y);


        for (int i = 0; i < itemCount; i++)
        {
            //프리팹 생성
            GameObject newItem = Instantiate(itemPrefab) as GameObject;
            //아이템 이름 지정
            newItem.name = i.ToString();
            //아이템의 부모를 현재 오브젝트로 지정
           newItem.transform.parent = gameObject.transform;

            //아이템의 트랜스폼 컴포넌트를 가지고옴
            RectTransform rectTrans = newItem.GetComponent<RectTransform>();
            //x = - 컨테이너의 넓이/2 + 넓이 * i
            float x = -containerRectTrans.rect.width / 2 + width * i;
            float y = containerRectTrans.rect.height / 2 - height;

            rectTrans.offsetMin = new Vector2(x, y);

            x = rectTrans.offsetMin.x + width;
            y = rectTrans.offsetMin.y + height;
            rectTrans.offsetMax = new Vector2(x, y);
        }

    }


    //종 스크롤
    public void RowScroll(int itemCount, GameObject itemPrefab)
    {

        //아이템 프리팹의 트랜스폼
        RectTransform rowRectTrans = itemPrefab.GetComponent<RectTransform>();
        //컨테이너(스크롤 리스트)의 트랜스폼
        RectTransform containerRectTrans = gameObject.GetComponent<RectTransform>();
        //너비 = 컨테이너->로컬렉트크기 ->너비
        float width = containerRectTrans.rect.width;
        //기준비율 = 콘테이너 너비/ 아이템프리팹의 너비
        float ratio = width / rowRectTrans.rect.width;
        //높이 = 아이템프리팹의 높이 * 비율
        float height = rowRectTrans.rect.height * ratio;
        //스크롤 높이 = 너비 * 개수
        float Scrollheight = height * itemCount;
        //오프셋 최소 = - 스크롤의 길이/ 2  ,  컨테이너 오프셋 최소 y
        containerRectTrans.offsetMin = new Vector2(containerRectTrans.offsetMin.x, -Scrollheight/2);
        //오프셋 최소 = - 스크롤의 길이/ 2  ,  컨테이너 오프셋 최소 y
        containerRectTrans.offsetMax = new Vector2(containerRectTrans.offsetMax.x, Scrollheight/2);


        for (int i = 0; i < itemCount; i++)
        {
            //프리팹 생성
            GameObject newItem = Instantiate(itemPrefab) as GameObject;
            //아이템 이름 지정
            newItem.name = i.ToString();
            //아이템의 부모를 현재 오브젝트로 지정
           newItem.transform.parent = gameObject.transform;

            //아이템의 트랜스폼 컴포넌트를 가지고옴
            RectTransform rectTrans = newItem.GetComponent<RectTransform>();
            //x = - 컨테이너의 넓이/2 + 넓이 * i
            float x = -containerRectTrans.rect.width / 2 ;
            float y = containerRectTrans.rect.height / 2 - height*i;

            rectTrans.offsetMin = new Vector2(x, y);

            x = rectTrans.offsetMin.x + width;
            y = rectTrans.offsetMin.y + height;
            rectTrans.offsetMax = new Vector2(x, y);
        }
    }
    public List<GameObject> AdvenceRowScroll(int itemCount, GameObject itemPrefab )
    {
        List<GameObject> gList = new List<GameObject>();
        //아이템 프리팹의 트랜스폼
        RectTransform rowRectTrans = itemPrefab.GetComponent<RectTransform>();
        //컨테이너(스크롤 리스트)의 트랜스폼
        RectTransform containerRectTrans = gameObject.GetComponent<RectTransform>();
        //너비 = 컨테이너->로컬렉트크기 ->너비
       // Debug.Log(width);
        float width = containerRectTrans.rect.width;
        //기준비율 = 콘테이너 너비/ 아이템프리팹의 너비

        float ratio = rowRectTrans.rect.width /width;
     
        //높이 = 아이템프리팹의 높이 * 비율
        float height = rowRectTrans.rect.height * ratio;
        //스크롤 높이 = 너비 * 개수
        float Scrollheight = height * itemCount;
        //오프셋 최소 = - 스크롤의 길이/ 2  ,  컨테이너 오프셋 최소 y
        containerRectTrans.offsetMin = new Vector2(containerRectTrans.offsetMin.x, -Scrollheight*2);
        //오프셋 최소 = - 스크롤의 길이/ 2  ,  컨테이너 오프셋 최소 y
        containerRectTrans.offsetMax = new Vector2(containerRectTrans.offsetMax.x, containerRectTrans.offsetMax.y);
        

        for (int i = 0; i < itemCount; i++)
        {
            //프리팹 생성
            GameObject newItem = Instantiate(itemPrefab) as GameObject;
            //아이템 이름 지정
            newItem.name = i.ToString();
            //아이템의 부모를 현재 오브젝트로 지정
            newItem.transform.parent = gameObject.transform;

            //아이템의 트랜스폼 컴포넌트를 가지고옴
            RectTransform rectTrans = newItem.GetComponent<RectTransform>();
            //x = - 컨테이너의 넓이/2 
            // float x = containerRectTrans.rect.width / 2;
            float x = width / 2;
            //float y = containerRectTrans.rect.height / 2 - height * i;
            float y = containerRectTrans.rect.height/2  - height * i;
            rectTrans.offsetMax = new Vector2(x, y);

            x = rectTrans.offsetMax.x - width;
            y = rectTrans.offsetMax.y - height;
            rectTrans.offsetMin = new Vector2(x, y);
            ///rectTrans.transform.position = new Vector3(1, 1, 1);
            //Debug.Log("pos x " + rectTrans.position.x + "\n" + "pos z" + rectTrans.position.z);
            //Debug.Log("offestMax x " + rectTrans.offsetMax.x + "\n" + "OffsetMinx" + rectTrans.offsetMin.x);

            //Debug.Log("offestMax y " + rectTrans.offsetMax.y + "\n" + "OffsetMiny" + rectTrans.offsetMin.y);
            rectTrans.localPosition = new Vector3(rectTrans.localPosition.x,
                rectTrans.localPosition.y,
                0);
            
            newItem.transform.localScale = new Vector3(1, 1, 1);
          //  newItem.transform.position = new Vector3(1, 1, 1);
            gList.Add(newItem);
            //Debug.Log(rectTrans.rect.position);
            //Debug.Log(rectTrans.transform.position);
        }
            return gList;
    }


    public List<GameObject> AdvenceSideScorll(int itemCount, GameObject itemPrefab)
    {
        List<GameObject> list = new List<GameObject>();
        //아이템 프리팹의 트랜스폼
        RectTransform sideRectTrans = itemPrefab.GetComponent<RectTransform>();
        //컨테이너(스크롤 리스트)의 트랜스폼
        RectTransform containerRectTrans = gameObject.GetComponent<RectTransform>();
        //높이 = 컨테이너->로컬렉트크기 ->높이
        float height = containerRectTrans.rect.height;
        //기준비율 = 콘테이너 높이/ 아이템프리팹의 높이 
        float ratio = height / sideRectTrans.rect.height;
        //너비 = 아이템프리팹의 너비 * 비율
        float width = sideRectTrans.rect.width * ratio;
        //스크롤 너비 = 너비 * 개수
        float ScrollWidth = width * itemCount;
        //오프셋 최소 = - 스크롤의 길이/ 2  ,  컨테이너 오프셋 최소 y
        containerRectTrans.offsetMin = new Vector2(-ScrollWidth / 2 +(width*1.5f), containerRectTrans.offsetMin.y);
        //오프셋 최소 = - 스크롤의 길이/ 2  ,  컨테이너 오프셋 최소 y
        containerRectTrans.offsetMax = new Vector2(ScrollWidth / 2 + (width * 1.5f), containerRectTrans.offsetMax.y);


        for (int i = 0; i < itemCount; i++)
        {
            //프리팹 생성
            GameObject newItem = Instantiate(itemPrefab) as GameObject;
            //아이템 이름 지정
            newItem.name = i.ToString();
            //아이템의 부모를 현재 오브젝트로 지정
            newItem.transform.parent = gameObject.transform;

            //아이템의 트랜스폼 컴포넌트를 가지고옴
            RectTransform rectTrans = newItem.GetComponent<RectTransform>();
            //x = - 컨테이너의 넓이/2 + 넓이 * i
            float x = -containerRectTrans.rect.width / 2  + width * i;
            float y = containerRectTrans.rect.height / 2 - height;

            rectTrans.offsetMin = new Vector2(x, y);

            x = rectTrans.offsetMin.x + width;
            y = rectTrans.offsetMin.y + height;
            rectTrans.offsetMax = new Vector2(x, y);

          

            list.Add(newItem);
            
           
        }
        return list;
    }

    public void initSideScroll(int ScrollSize, int number, GameObject itemPrefab)
    {
        RectTransform sideRectTrans = itemPrefab.GetComponent<RectTransform>();
        //컨테이너(스크롤 리스트)의 트랜스폼
        RectTransform containerRectTrans = gameObject.GetComponent<RectTransform>();
        //높이 = 컨테이너->로컬렉트크기 ->높이
        float height = containerRectTrans.rect.height;
        //기준비율 = 콘테이너 높이/ 아이템프리팹의 높이 
        float ratio = height / sideRectTrans.rect.height;
        //너비 = 아이템프리팹의 너비 * 비율
        float width = sideRectTrans.rect.width * ratio;

        if (number < 2)
        {
            containerRectTrans.offsetMin = new Vector2(-(width * 2)+width/2, containerRectTrans.offsetMin.y);
            containerRectTrans.offsetMax = new Vector2(width * (ScrollSize - 2)+ width / 2, containerRectTrans.offsetMax.y);
        }
        else
        {
            number -= 2;
            containerRectTrans.offsetMin = new Vector2(-(width * number)+width/2, containerRectTrans.offsetMin.y);
            containerRectTrans.offsetMax = new Vector2(width * (ScrollSize - number)+ width / 2, containerRectTrans.offsetMax.y);
        }
    }

    public void initRowScroll(int ScrollSize, int number, GameObject itemPrefab)
    {
        //아이템 프리팹의 트랜스폼
        RectTransform rowRectTrans = itemPrefab.GetComponent<RectTransform>();
        //컨테이너(스크롤 리스트)의 트랜스폼
        RectTransform containerRectTrans = gameObject.GetComponent<RectTransform>();
        //너비 = 컨테이너->로컬렉트크기 ->너비
        float width = containerRectTrans.rect.width;
        //기준비율 = 콘테이너 너비/ 아이템프리팹의 너비
        float ratio = width / rowRectTrans.rect.width;
        //높이 = 아이템프리팹의 높이 * 비율
        float height = rowRectTrans.rect.height * ratio;
        if (number < 2)
        {
            containerRectTrans.offsetMin = new Vector2(containerRectTrans.offsetMin.x, -(height * 2) + height / 2);
            containerRectTrans.offsetMax = new Vector2(containerRectTrans.offsetMax.x, height * (ScrollSize - 2) + height / 2);
        }
        else
        {
            number -= 2;
            containerRectTrans.offsetMin = new Vector2( containerRectTrans.offsetMin.x, - (height * number) + height / 2);
            containerRectTrans.offsetMax = new Vector2(containerRectTrans.offsetMax.x, height * (ScrollSize - number) + height / 2);
        }
    }



   

  
}