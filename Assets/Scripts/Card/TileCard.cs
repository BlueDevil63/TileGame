﻿using UnityEngine;
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
        [XmlElement("indexNumber")]
        public int indexNumber;
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

        public TileCard(int index, string n, TileType t, int id, string im, string address)
        {
            indexNumber = index;
            cardName = n;
            type = t;
            eventID = id;
            imageAddress = im;
            prfObjAddress = address;

        }
    }
    [System.Serializable]
    public class TileCardList
    {

        [XmlArray("cards")]
        [XmlArrayItem("TileCard")]
        public List<TileCard> tileCards;

        public TileCardList() { tileCards = new List<TileCard>(); }
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

