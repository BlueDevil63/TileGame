using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using TileCollections;

namespace TileCollections
{
    [System.Serializable]
    public class MapData
    {
        
        [XmlElement("size_x")]
        public int size_x;
        [XmlElement("size_z")]
        public int size_z;        
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
            data = new MapTile[size_x * size_z];
            for(int k = 0; k < size_x * size_z; k++)
            {
                MapTile tile = new MapTile();
                data[k] = tile;
            }
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
