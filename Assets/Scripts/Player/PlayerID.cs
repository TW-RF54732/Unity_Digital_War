using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerID : MonoBehaviour
{
    [SerializeField]
    int ID;
    bool isIdGet = false;
    public GameObject playerManagerObj;

    PlayerManager playerManager;
    private void Start()
    {
        if(isIdGet == false)
        {
            playerManager = playerManagerObj.GetComponent<PlayerManager>();
            ID = playerManager.getID();
            isIdGet = true;
        }
    }
    public int getID()
    {
        if (isIdGet == false)
        {
            playerManager = playerManagerObj.GetComponent<PlayerManager>();
            ID = playerManager.getID();
            isIdGet = true;
            return ID;
        }
        else return ID;
    }
}
