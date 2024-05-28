using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static InfoReader;

public class BaseView : MonoBehaviour
{
    [SerializeField]GameObject look;
    [SerializeField] TextMeshProUGUI relationText,baseID,soldierAmount,army;
    int ID;

    InfoReader infoReader;

    private void Start()
    {
        GameObject playerObj = transform.parent.parent.gameObject;
        PlayerID playerID = playerObj.GetComponent<PlayerID>();

        infoReader = playerObj.GetComponent<InfoReader>();

        ID = playerID.getID();

        
    }
    public void isLooking(GameObject target)
    {
        look = target;
        SpawnID spawnID = target.GetComponent<SpawnID>();
        Base_Info baseInfo = infoReader.GetInfo(target);
        if(baseInfo.relation == "Own")
        {
            relationText.text = "Own";
            relationText.color = Color.cyan;
        }
        else
        {
            relationText.text = "Hostile";
            relationText.color = Color.red;
        }
        if(baseInfo.Name.Readable == true) { baseID.text = Convert.ToString(baseInfo.Name.Data); }
        else { baseID.text = "Unknow"; }
        if (baseInfo.SoldierAmount.Readable == true) { soldierAmount.text = Convert.ToString(baseInfo.SoldierAmount.Data); }
        else { soldierAmount.text = "Unknow"; }
        if(baseInfo.Army.Readable == true) { army.text = Convert.ToString(baseInfo.Army.Data); }
        else { army.text = "Unknow"; }
    }
}
