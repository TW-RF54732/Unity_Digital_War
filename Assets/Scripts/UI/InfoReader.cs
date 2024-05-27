using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class InfoReader : MonoBehaviour
{
    public class Base_Info
    {
        public string relation = null;
        public struct MagaType
        {
            public string InfoType;
            public object Data;
            public bool Readable;
            public MagaType(string type,object data,bool isRead)
            {
                InfoType = type;
                Data = data;
                Readable = isRead;
            }
        }
        public MagaType Type,Name,ID,SoldierAmount,Army = new MagaType();
        public Base_Info(string baseName, int id,int soldierAmount,int army)
        {
            Type = new MagaType("Type","Base",true);
            Name = new MagaType("Name",baseName,false);
            ID = new MagaType("ID",id,false);
            SoldierAmount = new MagaType("SoldierAmount", soldierAmount, false);
            Army = new MagaType("Army",army,false);
        }
        public void All_Readable()
        {
            Type.Readable = true;
            Name.Readable = true;
            ID.Readable = true;
            SoldierAmount.Readable = true;
            Army.Readable = true;
        }
        public void Un_Readable()
        {
            Type.Readable = true;
            Name.Readable = false;
            ID.Readable = false;
            SoldierAmount.Readable = false;
            Army.Readable = false;
        }
        public void SetCanRead(MagaType stuff)
        {
            stuff.Readable = true;
        }
    }
    
    public Base_Info GetInfo(GameObject target)
    {
        SpawnID spawnID = target.GetComponent<SpawnID>();
        int id = spawnID.GetID();
        string name = target.name;
        BaseFight baseFight = target.GetComponent<BaseFight>();
        int soldierAmount = baseFight.soldierAmount;
        int army = baseFight.goFightSoldierAmount;

        PlayerID playerID = GetComponent<PlayerID>();

        Base_Info readedinfo = new Base_Info(name,id,soldierAmount,army);
        if(Convert.ToInt32(readedinfo.ID.Data) == playerID.getID())
        {
            readedinfo.All_Readable();
            readedinfo.relation = "Own";
        }
        else
        {
            readedinfo.relation = "Hostile";
            readedinfo.Un_Readable();
        }
        return readedinfo;
    }

}
