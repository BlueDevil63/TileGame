using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool
{
    /// <summary>
    /// 원본 소스코드 출처 : http://dolphin.ivyro.net/file/mobile/unity/tutorial27/ObjectPoolManager.cs
    /// 일종의 큐처럼 활용하는 방식
    /// 각각의 인스턴스된 객체를 저장하고, 일종의 주소를 mReleasedIndex에 저장한다.
    /// mReleaseCount는 현재 몇개나 저장(SetActive(false)되 있는지에 대한 숫자
    /// mUsinge 현재 해당하는 주소가 사용됬는지 체크한다.
    /// </summary>
    public List<GameObject> mInstance = new List<GameObject>();
    public List<bool> mUsing = new List<bool>();
    public GameObject mSourcePrefab;
    //다썻는지 안썻는지 알아야함
    public int mReleasedCount;
    //꺼낼 인덱스의 넘버가 들어있다.
    public List<int> mRealsedIndex = new List<int>();

    public ObjectPool() { }
    public ObjectPool(string soucePath)
    {
        mSourcePrefab = (GameObject)Resources.Load(soucePath);
    }
    public ObjectPool(GameObject SourcePrfab)
    {
        mSourcePrefab = SourcePrfab;
    }
    public void Add(GameObject Instacne)
    {
        mRealsedIndex.Add(mInstance.Count);
        mInstance.Add(Instacne);
        mUsing.Add(true);
        mReleasedCount++;
        Instacne.SetActive(false);
    }

    public GameObject Create()
    {
        int index = mRealsedIndex[0];
        GameObject target;

        target = mInstance[index];
        mUsing[index] = false;
        mReleasedCount--;
        mRealsedIndex.RemoveAt(0);
        target.SetActive(true);
        return target;
    }
    public bool Release(GameObject instance)
    {
        int index;

        if (!mInstance.Contains(instance))
            return false;

        index = mInstance.IndexOf(instance);

        mReleasedCount++;
        mRealsedIndex.Add(index);
        mUsing[index] = false;

        mInstance[index].SetActive(false);

        return true;
    }

    public void Destroy()
    {
        mSourcePrefab = null;
        mInstance.Clear();
        mUsing = null;
        return;
    }
}
