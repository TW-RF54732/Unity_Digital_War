using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static InfoReader;

public class BaseView : MonoBehaviour
{
    [SerializeField]GameObject look;
    [SerializeField] TextMeshProUGUI relationText;
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
    }
}
