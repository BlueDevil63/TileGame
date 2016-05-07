using UnityEngine;
using System.Collections;
using DataSpace.Battle;
using DataSpace;
using System.Collections.Generic;

///   실행 순서
///1. GameManager를 통해서 던전 데이터를 로드
///2. 던전 정보 불러오기 
///3. 불러온 던전 정보를 이용해 오브젝트 풀에 프리팹 동록하기
///4. 자동 던전 정보 배치 시작
///5. 자동으로 생성된 던전에 난이도 1-2->3 순으로 몬스터를 나열 혹은 랜던으로 몬스터 나열
///6. 몬스터를 배치시킬 던전 타일을 생성(한 칸당 z축으로 20간격) 
///   1.  (0,0,0)  2 .(0,0,20)  3. (0,0,40) 4. (0,0,60 )  5. (0,0,80) 6. (0,0,100) 으로 생성
///   타일 생성 후 부모는 Dungeon 오브젝트로 함
///7. 던전타일 -> CreateMonster를 통해서 프리팹을 각자 불러와 몬스터를 배치
///8. GameManager에서 임시 저장된 플레이어 정보를 로드
///9. 플레이어의 정보를 GUI에 표시
///10. 플레이어 카드 및 아이템을 불러오기
///11 플레이어가 클릭할 버튼을 다시 체크 1~3까지 공격
/// 0 좌 1 중앙 2 우측
public class BattleMgr : MonoBehaviour {

    public GameObject TilePrefab;
    public GameObject Dungeon;
    public List<GameObject> dTileList;
    protected DungeonData d_Dungeon;
    protected MonsterList d_monsterList;
    // Use this for initialization
    void Start() {
        /*
        //임시적으로 타일 부터 생성
        Vector3 pos = new Vector3(0, 0, 0);
        for (int k = 0; k < 6; k++)
        {
            pos.z = k * 20;
            GameObject tile = Instantiate(TilePrefab, pos, transform.rotation) as GameObject;
            tile.transform.parent = Dungeon.transform;
            tile.GetComponent<DungeonTile>().CreateMonster();
            dTileList.Add(tile);
        }
        */

        LoadDatas();      //던전데이터 불러오기
        SettingObjectPool();    //오브젝트풀에 몬스터 정보를 불러와 넣어준다.
        GenerateDungeon();      //자동적으로 던전을 생성시킨다.
        PositioningMonster();   //몬스터를 위치시킨다.
        SetActvieDungeon();     //던전의 SetActvie를 조정한다.
        SettingThePlayer();     //플레이어의 정보를 불러오고의 데이터를 통해 GUI 세팅
    }

    // Update is called once per frame
    void Update() {
        ///업데이트 순서
        ///1. 순서 정하기 : 플레이어와 몬스터중의 우선공격관 확인하기
        ///2. 차례대로 행동
        ///3. 타일의 몬스터 제거 -> 던전이 당겨지고 던전타일이 맨뒤에 추가(타일 생성 -> 몬스터 추가)
    }

    private void LoadDatas()
    {
        d_Dungeon = GameManager.instance.m_DataManager.LoadDungeonData(GameManager.instance.dungeonName);
        d_monsterList = GameManager.instance.m_DataManager.LoadMonsterList();
    }
    private void SettingObjectPool()
    {

    }
    private void GenerateDungeon()
    {
        string path = "/Prefabs/Battle/Tile/";
        GameObject tileObj = null;
        switch(d_Dungeon.d_Name)
        {
            case "Forest":
                tileObj = Resources.Load<GameObject>(path + "prfForestTile");
                break;
            case "Cave":
                tileObj = Resources.Load<GameObject>(path + "prfCaveTile");
                break;
            case "Dungeon":
                tileObj = Resources.Load<GameObject>(path + "prfDungeonTile");
                break;
        }
        for (int k = 0; k< d_Dungeon.dungeonLength; k++)
        {
        }
    }
    private void PositioningMonster()
    {

    }
    private void SetActvieDungeon()
    {
        //몬스터의 SetActive 시킨다.

    }
    private void SettingThePlayer()
    {

    }

    private void AddDungeon()
    {

    }


}
