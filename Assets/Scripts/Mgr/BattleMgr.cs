using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataSpace.Battle;
using DataSpace;
using Dungeon;
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


    private static BattleMgr _instance;
    public static BattleMgr instance
    {
        get
        {
            if (_instance == null)
            {
                // Debug.LogError("GameManager = null!!");
                _instance = new BattleMgr();
            }
            return _instance;
        }
    }

    public GameObject tilePrefab;
    //public List<GameObject> dTileList;
    public GameObject playerObj;   
    // protected DungeonMgr m_DungeonMgr;
    protected DungeonMgr m_DungeonMgr;
    private int currentPos;
    private BattleUI uiMgr;
    private Player s_Player;
    private enum EnumProgress
    {
       StartDungeon,
       DecideAct,
       BattleBegin,
       BattleEnd,
       EndDungeon
    }
    private enum EnumBattle
    {
        MonsterAppear,
        DecideSeqaunece,
        SeqaunceInTurn,
        Result
    }
    delegate void Progress();   //현재 던전 진행
    Dictionary<EnumProgress, Progress> dic_Progress = new Dictionary<EnumProgress, Progress>();
    EnumProgress e_Progress;
    delegate void Battle();     //현재 배틀의 순서대로의 진행
    Dictionary<EnumBattle, Battle> dic_Battle = new Dictionary<EnumBattle, Battle>();
    EnumBattle e_Battle;

    // Use this for initialization
    void Start() {
        SetProgress();
        e_Progress = EnumProgress.StartDungeon;
        SetBattle();
        e_Battle = EnumBattle.MonsterAppear;
        currentPos = 0;
        //m_DungeonMgr = new DungeonMgr();
        m_DungeonMgr = gameObject.AddComponent<DungeonMgr>();
        m_DungeonMgr.GenerateDungeon();
        m_DungeonMgr.PositionLoad(currentPos);
        LoadDatas();      //던전데이터 불러오기
                          //플레이어의 정보를 불러오고의 데이터를 통해 GUI 세팅
        SettingThePlayer();
       // uiMgr.Init();
        uiMgr.InsertMonster(m_DungeonMgr.curMonsters);
    }

    // Update is called once per frame
    void Update() {
        ///업데이트 순서
        ///1. 던전 시작하기(알림, 혹은 경고등장)
        ///2. 행동선택, 이동 or 회복
        ///3. 배틀시작(텍스트 : 수폴속에서 뭔가가 나왔다!! 등)
        ///    --> Battle 진행
        ///     
        ///4. 배틀 종료
        ///5. 던전이 끝인가? 아니라면 다시 행동선택

        dic_Progress[e_Progress]();
    }

    private void SetProgress()
    {
        dic_Progress[EnumProgress.StartDungeon] = StartDungeon;
        dic_Progress[EnumProgress.DecideAct] = DecideAct;
        dic_Progress[EnumProgress.BattleBegin] = BattleBegin;
        dic_Progress[EnumProgress.BattleEnd] = BattleEnd;
        dic_Progress[EnumProgress.EndDungeon] = EndDungeon;
    }

    private void SetBattle()
    {
        dic_Battle[EnumBattle.MonsterAppear] = MonsterAppear;
        dic_Battle[EnumBattle.DecideSeqaunece] = DecideSeqaunece;
        dic_Battle[EnumBattle.SeqaunceInTurn] = SeqaunceInTurn;
        dic_Battle[EnumBattle.Result] = Result;

    }

    private void LoadDatas()
    {
        s_Player = playerObj.GetComponent<Player>();
        s_Player.InGameInit();
        s_Player = GameManager.instance.LoadMgrPlayerData(s_Player);
        
    }

    private void SettingThePlayer()
    {

    }

    private void StartDungeon()
    {

    }

    private void DecideAct()
    {

    }

    private void BattleBegin()
    {

    }

    private void BattleEnd()
    {

    }

    private void EndDungeon()
    {

    }

    private void MonsterAppear()
    {

    }

    private void DecideSeqaunece()
    {

    }

    private void SeqaunceInTurn()
    {

    }

    private void Result()
    {

    }


}
