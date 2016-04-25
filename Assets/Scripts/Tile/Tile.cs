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
        VILLIAGE,
    }

    [System.Serializable]
    public class MapTile
    {
        // 직접 추가
        [XmlElement("index_x")]
        public int index_x;
        [XmlElement("index_x")]
        public int index_z;

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
            index_x = 0;
            index_z = 0;
            build = false;
            type = TileType.VOID;
        }
        public MapTile (int x, int z,  bool b, TileType t)
        {
            index_x = x;
            index_z = z;
            build = b;
            type = t;
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
        public Tile from;

        public Tile to;

        public int cost;

        public Edge(int c)
        {
            cost = c;
        }
        public Edge(Tile f, Tile t)
        {
            from = f;
            to = t;
        }
        public Edge(Tile f, Tile t, int c)
        {
            from = f;
            to = t;
            cost = c;
        }

    }
}
