using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using TileCollections;

namespace TileCollections
{
    public class TileMapdData
    {
        public int size_x;
        public int size_z;
        public MapTile[,] data;

        public TileMapdData() { }
        public TileMapdData(int x, int z)
        {
            size_x = x;
            size_z = z;
            data = new MapTile[x, z];

            for (int k = 0; k < size_x; k++)
            {
                for (int j = 0; j < size_z; j++)
                {
                    MapTile tile = new MapTile();
                    data[k, j] = tile;

                }
            }
            Debug.Log("Done MapData");
        }
    }
    [System.Serializable]
    public class MapData
    {
        
        [XmlElement("size_x")]
        public int size_x;

        [XmlElement("size_z")]
        public int size_z;
        [XmlElement("start")]
        public MapTile start;

        [XmlArray("data")]
        [XmlArrayItem("MapTile")]
        public MapTile[] data;

       // public List<List<MapTile>> mData; 


        public MapData()
        { 
        }
        public MapData(int x, int z)
        {
            size_x = x;
            size_z = z;
            start = new MapTile();
            data = new MapTile[size_x * size_z];
            MapTile tile = new MapTile(0, 0, false, 10, TileType.NONE);

         
            for (int k = 0; k < size_x * size_z; k++)
            {

                data[k] = tile;
            }
   
            /*
            for(int row = 0; row < size_x; row++)
            {
                for(int roll = 0; roll < size_z; roll++)
                {
                    data[row * size_z + roll] = tile;
                    data[row * size_z + roll].array_x = row;
                    data[row * size_z + roll].array_z = roll;
                    
                }
            }
            */
        }
        /*
        public void Init(int x, int z)
        {
            size_x = x;
            size_z = z;
            data = new MapTile[size_x, size_z];

            for (int k = 0; k < size_x; k++)
            {
                for (int j = 0; j < size_z; j++)
                {
                    MapTile tile = new MapTile();
                    data[k, j] = tile;

                }
            }
            Debug.Log("Done MapData");
        }
        */
    }
}
