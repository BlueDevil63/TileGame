using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TileCollections;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class TileMap : MonoBehaviour {

    public int size_x = 30;
    public int size_z = 30;
    public float tileSize = 1.0f;
    public Tile[,] tiles = new Tile[30,30];

	// Use this for initialization
	void Start () {
        BuildMesh();
        GameManager.instance.MapDataInit(size_x, size_z);
	}
	
	public void BuildMesh()
    {
        tiles = new Tile[size_x, size_z];
        int numTiles = size_x * size_z;
        int numTris = numTiles * 2;
        
        //버텍스의 개수 = 1칸을 만들려면 4개의 버택스가 필요하다 즉 하나의 선을 구성하려면 2개가 필요
        //그러므로 +1
        int vsize_x = size_x + 1;
        int vsize_z = size_z + 1;
        int numVerts = vsize_x * vsize_z;

        //메쉬 데이터를 생성
        Vector3[] vertices = new Vector3[numVerts];
        Vector3[] normals = new Vector3[numVerts];
        Vector2[] uv = new Vector2[numVerts];

        //트라이 앵글 버텍스 정보이므로 곱하기 3
        int[] triangles = new int[numTris * 3];

        //버텍스 생성
        int x, z;      
        for (z = 0; z < vsize_z; z++)
        {
            for( x = 0; x < vsize_x; x++)
            {
                vertices[z * vsize_x + x] = new Vector3(x * tileSize, 0, z * tileSize);
                normals[z * vsize_x + x] = Vector3.up;
                uv[z * vsize_x + x] = new Vector2((float)x / vsize_x, (float)z / vsize_z);
            }
        }
        Debug.Log("Done Verts!");


        //트라이 앵글 생성
        for(z = 0; z < size_z; z++)
        {
            for (x = 0; x < size_x; x++)
            {
                int squareIndex = z * size_x + x;
                int triOffset = squareIndex * 6;
                triangles[triOffset + 0] = z * vsize_x + x + 0;
                triangles[triOffset + 1] = z * vsize_x + x + vsize_x + 0;
                triangles[triOffset + 2] = z * vsize_x + x + vsize_x + 1;

                triangles[triOffset + 3] = z * vsize_x + x + 0;
                triangles[triOffset + 4] = z * vsize_x + x + vsize_x+ 1;
                triangles[triOffset + 5] = z * vsize_x + x + 1;

            }
        }
        Debug.Log("Done Tirangles");

        //메쉬를 생성하고 만든 데이터를 넣어준다.
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        MeshFilter mesh_filter = GetComponent<MeshFilter>();
        MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
        MeshCollider mesh_collider = GetComponent<MeshCollider>();

        mesh_filter.mesh = mesh;
        mesh_collider.sharedMesh = mesh;
        Debug.Log("Done Mehs!");

    }

    public void CreateNode()
    {
        for(int k =0; k<size_z; k++)
        {
            for(int q = 0; q < size_x; q++)
            {
                float x = 0.5f + q * 0.5f;
                float z = 0.5f + q * 0.5f;
                float y = 0;
                Vector3 pos = new Vector3(0.5f + q * 0.5f, 0, 0.5f + k * 0.5f);
                Tile tile = new Tile(q, k, pos);
                tiles[q,k] = tile;
            }
        }
    }

    public void CreateEdge()
    {
        for (int k = 0; k < size_z; k++)
        {
            for (int q = 0; q < size_x; q++)
            {
                // 좌 우 상 하 순으로 엣지
                Edge[] edge = new Edge[4];
                edge[0].from = tiles[q, k];
                edge[1].from = tiles[q, k];
                edge[2].from = tiles[q, k];
                edge[3].from = tiles[q, k];

                
                if (q !=0 && q!= size_x-1)
                {
                    edge[0].to = tiles[q - 1, k];
                    edge[1].to = tiles[q +1, k];
                    tiles[q, k].edges[0] = edge[0];
                    tiles[q, k].edges[1] = edge[1];
                }
                else
                {
                    if (q == 0)
                    {
                        edge[0].to = null;
                        edge[1].to = tiles[q + 1, k];
                        tiles[q, k].edges[0] = edge[0];
                        tiles[q, k].edges[1] = edge[1];
                    }
                    else
                    {
                        edge[0].to = tiles[q - 1, k];
                        edge[1].to = null;
                        tiles[q, k].edges[0] = edge[0];
                        tiles[q, k].edges[1] = edge[1];
                    }
                }

                if (k != 0 && k != size_z - 1)
                {
                    edge[2].to = tiles[q, k-1];
                    edge[3].to = tiles[q , k+1];
                    tiles[q, k].edges[2] = edge[2];
                    tiles[q, k].edges[3] = edge[3];
                }
                else
                {
                    if (q == 0)
                    {
                        edge[2].to = null;
                        edge[3].to = tiles[q, k + 1];
                        tiles[q, k].edges[2] = edge[2];
                        tiles[q, k].edges[3] = edge[3];
                    }
                    else
                    {
                        edge[2].to = tiles[q, k - 1];
                        edge[3].to = null;
                        tiles[q, k].edges[2] = edge[2];
                        tiles[q, k].edges[3] = edge[3];
                    }
                }

            }
        }

    }
}
