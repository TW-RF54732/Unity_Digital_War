using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayID : MonoBehaviour
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
}
