using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static InfoReader;

public class BaseView : MonoBehaviour
{
    [SerializeField]GameObject look,showArmy,showUnkowArmy;
    [SerializeField] TextMeshProUGUI relationText,baseID,soldierAmount,army;
    [SerializeField]Scrollbar armyBar;
    int ID;

    GameObject temp;

    InfoReader infoReader;
    BaseFight baseFight;

    private void Start()
    {
        GameObject playerObj = transform.parent.parent.gameObject;
        PlayerID playerID = playerObj.GetComponent<PlayerID>();

        infoReader = playerObj.GetComponent<InfoReader>();

        ID = playerID.getID();

        
    }
    private void Update()
    {
        isLooking(look);
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
        if(baseInfo.Army.Readable == true) 
        { 
            showUnkowArmy.SetActive(false);
            showArmy.SetActive(true);
        }
        else 
        { 
            showUnkowArmy.SetActive(true);
            showArmy.SetActive(false);
        }
    }
    public void scrolBar()
    {

        float value;
        int SoldierInArmy;

        baseFight = look.GetComponent<BaseFight>();

        value = armyBar.value;
        SoldierInArmy = Mathf.RoundToInt(baseFight.soldierAmount * value);
        baseFight.goFightSoldierAmount = SoldierInArmy;
        army.text = SoldierInArmy.ToString();
    }
}
