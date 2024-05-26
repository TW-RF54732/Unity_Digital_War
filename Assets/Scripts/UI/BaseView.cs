using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseView : MonoBehaviour
{
    [SerializeField]GameObject ownRelationTXT,hostileRelationTXT, look;
    int ID;

    

    private void Start()
    {
        PlayerID playerID = transform.parent.parent.gameObject.GetComponent<PlayerID>();
        ID = playerID.getID();
    }
    public void isLooking(GameObject target)
    {
        look = target;
        SpawnID spawnID = target.GetComponent<SpawnID>();
        if(ID == spawnID.GetID())
        {
            ownRelationTXT.SetActive(true);
            hostileRelationTXT.SetActive(false);
        }
        else
        {
            ownRelationTXT.SetActive(false) ;
            hostileRelationTXT.SetActive(true) ;
        }
    }
}
