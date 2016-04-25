using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using DataSpace;

namespace DataSpace
{
    [System.Serializable]
    public class ItemData
    {
        [XmlElement("itemName")]
        public string itemName;
        [XmlElement("price")]
        public int price;
        [XmlElement("type")]
        public int type;
        [XmlElement("effect")]
        public int effect;
        [XmlElement("effectObj")]
        public string effectObj;
    }
    [System.Serializable]
    public class ItemList
    {
        [XmlArray("iData")]
        [XmlArrayItem("ItemData")]
        public List<ItemData> iData;
    }
}




public class Item : MonoBehaviour
{
    string itemName;
    int price;
    int type;
    int effect;
    string effectObj;
}
