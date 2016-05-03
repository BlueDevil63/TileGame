using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using DataSpace;


public class Item : MonoBehaviour
{
    string itemName;
    int price;
    int type;
    int effect;
    string effectObj;
}

namespace DataSpace
{
    [System.Serializable]
    public class BaseItemData
    {
        [XmlElement("itemName")]
        public string itemName;
        [XmlElement("price")]
        public int price;
        [XmlElement("type")]
        public int type;
        [XmlElement("imageAdress")]
        public string imageAdress;
    }
    //아이템 정보 -----------------------------------------
    [System.Serializable]
    public class ItemData : BaseItemData
    {
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
    //Weapon 데이터 리스트--------------
    [System.Serializable]
    public class WeaponData : BaseItemData
    {
        [XmlElement("damage")]
        public float damage;
        [XmlElement("durability")]
        public float durability;

    }
    [System.Serializable]
    public class WeaponList
    {
        [XmlArray("wData")]
        [XmlArrayItem("WeaponData")]
        public List<WeaponData> wData;
    }
    //Armor 데이터 리스트----------------
    [System.Serializable]
    public class ArmorData : BaseItemData
    {
        [XmlElement("defense")]
        public float defense;
        [XmlElement("durability")]
        public float durability;

    }
    [System.Serializable]
    public class ArmorList
    {
        [XmlArray("aData")]
        [XmlArrayItem("ArmorData")]
        public List<ArmorData> aData;
    }

}