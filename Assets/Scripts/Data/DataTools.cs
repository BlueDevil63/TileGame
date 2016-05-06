using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using DataSpace;
using DataSpace.Battle;
using CardCollections;
using TileCollections;


public class DataTools
{
    public  string UTF8ByteArrayToString(byte[] gameData)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(gameData);
        return (constructedString);
    }
    //String -> byte
    public byte[] StringToUTF8ByteArray(string pxmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pxmlString);
        return byteArray;
    }
    //세이브 할때 사용

    private XmlSerializer InitType(string type)
    {
        XmlSerializer xs = null;
        switch (type)
        {
            case "Player":
                xs = new XmlSerializer(typeof(PlayerData));
                break;
            case "BattleCardList":
                xs = new XmlSerializer(typeof(TileCard));
                break;
            case "TileCardList":
                xs = new XmlSerializer(typeof(TileCard));
                break;
            case "MonsterList":
                xs = new XmlSerializer(typeof(MonsterList));
                break;
            case "ArmorList":
                xs = new XmlSerializer(typeof(ArmorList));
                break;
            case "WeaponList":
                xs = new XmlSerializer(typeof(WeaponList));
                break;
            case "ItemList":
                xs = new XmlSerializer(typeof(ItemList));
                break;
            case "MapData":
                xs = new XmlSerializer(typeof(MapData));
                break;
            case "DungeonList":
                xs = new XmlSerializer(typeof(DungeonList));
                break;
            case "VilliageList":
                break;
            case "SaveData":
                break;
            default:
                xs = xs = new XmlSerializer(typeof(PlayerData));
                Debug.LogError("Error!!");
                break;
        }

        return xs;
    }
    
    public string SerlializeObject(object pObject, string type)
    {
        string xmlizedString = null;
        MemoryStream mStream = new MemoryStream();
        XmlSerializer xs = InitType(type);

        XmlTextWriter textWriter = new XmlTextWriter(mStream, Encoding.UTF8);
        xs.Serialize(textWriter, pObject);
        mStream = (MemoryStream)textWriter.BaseStream;
        xmlizedString = UTF8ByteArrayToString(mStream.ToArray());
        return xmlizedString;
       
    }
 
    public  object DeserializeObject(string pXmlizedString, string type)
    {
        //XmlSerializer xs;
        XmlSerializer xs = InitType(type);
        MemoryStream mStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
        XmlTextWriter textWriter = new XmlTextWriter(mStream, Encoding.UTF8);
        return xs.Deserialize(mStream);
    }
 
        
    public void CreateXML(string _data, string _FileName, string _FileLocation)
    {
        StreamWriter writer;
        FileInfo t = new FileInfo(_FileLocation + "\\" + _FileName);
            if(!t.Exists)
            {
                writer = t.CreateText();
            }
            else
            {
                t.Delete();
                writer = t.CreateText();
            }
            writer.Write(_data);
            writer.Close();
    }

    public string LoadXML(string _FileName, string _FileLocation)
    {

        StreamReader reader = File.OpenText(_FileLocation + "\\" + _FileName);
        string _info = reader.ReadToEnd();
        reader.Close();
        string _data = _info;
        return _data;
    }




    //public PlayerData LoadPlayerData(string name, string path)
    //{
    //    PlayerData _pData = new PlayerData();
    //    XmlSerializer deserializer = new XmlSerializer(typeof(PlayerData));
    //    TextAsset _TAsset = (TextAsset)Resources.Load("Data/" + name);
    //    TextReader reader = new StreamReader(_TAsset.text);
    //    _pData = (PlayerData)deserializer.Deserialize(reader);
    //    reader.Close();

    //}


//    public StorageData LoadStorageData(string playerName)
//    {
//        StorageData _pData = new StorageData();

//        if (playerName == string.Empty)
//        {
//            XmlSerializer deserializer = new XmlSerializer(typeof(StorageData));
//            TextAsset textAsset = (TextAsset)Resources.Load("Data/StorageData");
//            TextReader reader = new StringReader(textAsset.text);
//            _pData = (StorageData)deserializer.Deserialize(reader);
//            reader.Close();
//        }
//        else
//        {
//            string name = "StorageData";
//#if UNITY_EDITOR
//            StreamReader reader2 = File.OpenText(Application.dataPath + "/Resources/Data/Player/" + playerName + name + ".xml");
//#else
//        StreamReader reader2 = File.OpenText(Application.dataPath + "/Resources/" + playerName+ name + ".xml");
//#endif
//            string _info = reader2.ReadToEnd();
//            reader2.Close();
//            string data = _info;
//            _pData = (StorageData)DeserializeObject(data, "storage");
//        }

//        //#endif
//        return _pData;

//    }
}


