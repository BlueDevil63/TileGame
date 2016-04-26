using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using TileCollections;

namespace TileCollections
{

    public enum TileType
    {
        NONE,
        VOID,
        DUNGEON,
        FOREST,
        CAVE,
        VILLIAGE
    }

    [System.Serializable]
    public class Vec3
    {
        public float x;
        public float y;
        public float z;

        public Vec3(){}
        public Vec3(int vx, int vy, int vz)
        {
            x = vx;
            y = vy;
            z = vz;
        }
        public Vec3(Vector3 pos)
        {
            x = pos.x;
            y = pos.y;
            z = pos.z;
        }
        public void Fill(Vector3 pos)
        {
            x = pos.x;
            y = pos.y;
            z = pos.z;
        }

        public Vector3 Vec3Pos
        {
            get { return new Vector3(x, y, z); }
        }
    }
    [System.Serializable]
    public class MapTile
    {
      
        // 직접 추가
        [XmlElement("array_x")]
        public int array_x;
        [XmlElement("array_z")]
        public int array_z;

    
       // public Vector3 v_pos;
        public Vec3 pos;

        [XmlElement("cost")]
        public int cost;

        [XmlArray("edge")]
        [XmlArrayItem("Edge")]
        public Edge[] edges = new Edge[4];

        [XmlElement("build")]
        public bool build;
        [XmlEnum("type")]
        public TileType type;

        public MapTile()
        {
            array_x = 0;
            array_z = 0;
            cost = 0;
            build = false;
            type = TileType.VOID;
        }

        public MapTile(int x, int z, Vector3 vpos)
        {
            array_x = x;
            array_x = z;
            pos = new Vec3(vpos);
        }

        public MapTile (int x, int z,  bool b, int c, TileType t)
        {
            cost = c;
            array_x = x;
            array_z = z;
            build = b;
            type = t;
            pos = new Vec3(0, 0, 0);
        }

    }

    public class Tile
    {

        public int index_x;
        public int index_z;

        public Vector3 position;

        public Edge[] edges = new Edge[4];

        //public int value;

        public Tile(int x, int z)
        {
            index_x = x;
            index_z = z;
            //position = new Vector3(0, 0, 0);
        }
        public Tile(Vector3 pos) { position = pos; }
        public Tile(int x, int z, Vector3 pos)
        {
            index_x = x;
            index_z = z;
            position = pos;
        }
    }

    public class Edge
    {
        [XmlElement("from")]
        public MapTile from;
        [XmlElement("to")]
        public MapTile to;
        [XmlElement("cost")]
        public int cost;

        public Edge()
        {

        }
        public Edge(int c)
        {
            cost = c;
        }
        public Edge(MapTile f, MapTile t)
        {
            from = f;
            to = t;
        }
        public Edge(MapTile f, MapTile t, int c)
        {
            from = f;
            to = t;
            cost = c;
        }

    }
}
