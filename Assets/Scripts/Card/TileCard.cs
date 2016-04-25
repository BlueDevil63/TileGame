using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using TileCollections;

namespace CardCollections
{
    [System.Serializable]
    public class CardBase
    {
        [XmlElement("cardName")]
        public string cardName;
        [XmlElement("image")]
        public string imageAddress;
        [XmlElement("prfObjAddress")]
        public string prfObjAddress;
    }
    [System.Serializable]
    public class TileCard : CardBase
    {
        [XmlEnum("type")]
        public TileType type;
        [XmlElement("eventID")]
        public int eventID;

        public TileCard() { }

        public TileCard(string n, TileType t, int id, string im, string address)
        {
            cardName = n;
            type = t;
            eventID = id;
            imageAddress = im;
            prfObjAddress = address;

        }
    }

    namespace CardEvent
    {
        namespace TileCardEvent
        { 
            public class Move
            {
                [XmlElement("eventID")]
                int eventID;
                [XmlElement("effectAdress")]
                string effectAdress;
            }

        }
} 
}

