using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class InfoReader : MonoBehaviour
{
    public class Base_Info
    {
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
    }
    
    public void GetInfo(GameObject target)
    {
        SpawnID spawnID = target.GetComponent<SpawnID>();
        int id = spawnID.GetID();
        string name = target.name;
        BaseFight baseFight = target.GetComponent<BaseFight>();
        int soldierAmount = baseFight.soldierAmount;
        int army = baseFight.goFightSoldierAmount;
    }

}
