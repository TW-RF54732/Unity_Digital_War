using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerID : MonoBehaviour
{
    [SerializeField]
    int ID;
    public GameObject playerManagerObj;

    PlayerManager playerManager;
    private void Start()
    {
        playerManager = playerManagerObj.GetComponent<PlayerManager>();
        ID = playerManager.getID();
    }
    public int getID()
    {
        return ID;
    }
}
