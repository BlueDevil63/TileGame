using UnityEngine;
using System.Collections;
using TileCollections;

[RequireComponent(typeof(TileMap))]
public class TileMapMouse : MonoBehaviour {

    private TileMap _tileMap;
   // private MapData mData;
    private Vector3 currentTileCoord;
    public GameObject MapTiles;
    public InGameMgr mgr;

    private bool onMap;

    private int mousePos_x = 0;
    private int mousePos_z = 0;

    private int buildPos_x = 0;
    private int buildPos_z = 0;
    public Transform selectionCube;
  //  public GameObject tileObj;
	// Use this for initialization
	void Start () {
        _tileMap = GetComponent<TileMap>();
        onMap = false;
    }
	
	// Update is called once per frame
	void Update() {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(GetComponent<Collider>().Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            onMap = true;
            int x = Mathf.FloorToInt(hitInfo.point.x / _tileMap.tileSize);
            int z = Mathf.FloorToInt(hitInfo.point.z / _tileMap.tileSize);

            mousePos_x = (int)currentTileCoord.x;
            mousePos_z = (int)currentTileCoord.z;
            currentTileCoord.x = x +0.5f;
            currentTileCoord.z = z +0.5f;

            selectionCube.transform.position = currentTileCoord;
        }
        else
        {
            onMap = false;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(onMap)
            CheckTile();
        }
	
	}
    private void CheckTile()
    {
        bool check_x = false;
        bool check_z= false;
        Debug.Log("Click!" + "X : " + mousePos_x + "  Y : " + mousePos_z);
        if (!GameManager.instance.mData.data[mousePos_x , mousePos_z ].build && GameManager.instance.isSelect && mgr.buildMode)
        {
            if (mousePos_x == 0 && mousePos_z == 0)
            {
                CreateTile();
                GameManager.instance.mData.data[mousePos_x, mousePos_z].build = true;
                Debug.Log("CreateTile");
                Debug.Log("a");
            }
            else {
                // 좌측 검사
                if (mousePos_x != 0)
                {
                    if (GameManager.instance.mData.data[mousePos_x -1 ,mousePos_z].build)
                    {
                        check_x = true;
                    }
                }
                //우측검사
                if (mousePos_x != 29)
                {
                    if (GameManager.instance.mData.data[mousePos_x + 1, mousePos_z].build)
                    //if (GameManager.instance.mData.data[(mousePos_x * GameManager.instance.mData.size_x + mousePos_z +1)].build) 
                    {
                        check_x = true;
                    }
                }
                //상 검사
                if (mousePos_z != 0)
                {
                    if (GameManager.instance.mData.data[mousePos_x, mousePos_z - 1].build)
                    //if (GameManager.instance.mData.data[mousePos_x + 1 * GameManager.instance.mData.size_x + mousePos_z - 2].build)
                    {
                        check_z = true;
                    }
                }
                //하 검사
                if (mousePos_z != 29)
                {
                    if (GameManager.instance.mData.data[mousePos_x, mousePos_z + 1].build)
                    //if (GameManager.instance.mData.data[mousePos_x - 1 * GameManager.instance.mData.size_x + mousePos_z].build)
                    {
                        check_z = true;
                    }
                }

                if (check_x || check_z)
                {
                    CreateTile();
                    GameManager.instance.mData.data[mousePos_x, mousePos_z].build = true;
                    //GameManager.instance.mData.data[buildPos_x * GameManager.instance.mData.size_x + buildPos_z - 1].build = true;
                    buildPos_x = mousePos_x;
                    buildPos_z = mousePos_z;
                    //mgr.mData.data[mousePos_x, mousePos_z].type = mgr.buildType;
                    Debug.Log("CreateTile");
                    //Debug.Log(mgr.mData.data[mousePos_x, mousePos_z].type = mgr.buildType);
                }
            }
        }

    }

    private void CreateTile()
    {
        Vector3 buildTile = new Vector3();
        buildTile = currentTileCoord;
        buildTile.y = 0.13f;
        if(mgr.tileObj != null)
        {
            GameObject tile = Instantiate(mgr.tileObj, buildTile, transform.rotation) as GameObject;
            tile.transform.parent = MapTiles.transform;
            mgr.isBuild = true;
        }
    }
    public void SetBuildType(TileType type)
    {
        GameManager.instance.mData.data[buildPos_x , buildPos_z].type = type;
    }
}
