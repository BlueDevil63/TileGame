using UnityEngine;
using System.Collections;
using TileCollections;

public class PlayerMove : MonoBehaviour{
    private bool[] check = new bool[4];
    private int dirNumber;

    private int pos_x;
    private int pos_y;

    public void Init()
    {
        dirNumber = -1;
        check[0] = false;
        check[1] = false;
        check[2] = false;
        check[3] = false;
    }
    //0 업 1 다운 2 레프트 3 라이트

    public void ButtonDown(int number)
    {
        Init();
        dirNumber = number;
    }

    public bool Move(GameObject playerObj, MapData mdata)
    {
        bool moving = false;

        Player player = playerObj.GetComponent<Player>();
        CheckTile(player, mdata);

        Vector3 pos = playerObj.transform.position;

        if (dirNumber != -1)
        {
            switch (dirNumber)
            {
                case 0:
                    if (check[0])
                    {
                        pos = new Vector3(pos.x, pos.y, pos.z + 1);
                        pos_y++;
                        moving = true;
                    }
                    break;
                case 1:
                    if (check[1])
                    {
                        pos = new Vector3(pos.x, pos.y, pos.z + -1);
                        pos_y--;
                        moving = true;
                    }
                    break;
                case 2:
                    if (check[2])
                    {
                        pos = new Vector3(pos.x - 1, pos.y, pos.z);
                        pos_x--;
                        moving = true;
                    }
                    break;
                case 3:
                    if (check[3])
                    {
                        pos = new Vector3(pos.x + 1, pos.y, pos.z);
                        pos_x++;
                        moving = true;
                    }
                    break;
            }
            
        }
        playerObj.transform.position = pos;
        dirNumber = -1;
        return moving;
    }

    private void CheckTile(Player player, MapData mData)
    {
        int x = player.pos_x;
        int y = player.pos_y;
        if (y <= mData.size_z - 2)
        {
            //상
            //if (mData.data[x, y + 1].build)
            if (mData.data[(x +1 * mData.size_x) + y].build)
                check[0] = true;
        }
        if (y >= 1)
        {
            //하
            //if (mData.data[x, y - 1].build)
            if (mData.data[(x -1 * mData.size_x) + y].build)
                check[1] = true;
        }
        if (x >= 1)
        {
            //좌
            //if (mData.data[x - 1, y].build)
            if (mData.data[x * mData.size_x + y-2].build)
                check[2] = true;
        }
        if(x <= mData.size_x - 2)
        {
            //우
            //if (mData.data[x + 1, y].build)
            if (mData.data[x * mData.size_x + y].build)
                    check[3] = true;
        }
        pos_x = x;
        pos_y = y;
    }

    public int PosX()
    {
        return pos_x;
    }
    public int PosY()
    {
        return pos_y;
    }

}
