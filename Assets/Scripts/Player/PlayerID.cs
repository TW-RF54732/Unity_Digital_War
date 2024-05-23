using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerID : MonoBehaviour
{
    [SerializeField]
    int ID;
    bool isIdGet = false;

    PlayerManager playerManager;
    private void Start()
    {
        if(isIdGet == false)
        {
            playerManager = GameObject.FindAnyObjectByType<PlayerManager>();
            ID = playerManager.getID();
            isIdGet = true;
            name();
        }
    }
    public int getID()
    {
        if (isIdGet == false)
        {
            playerManager = GameObject.FindAnyObjectByType<PlayerManager>();
            ID = playerManager.getID();
            isIdGet = true;
            name();
            return ID;
        }
        else return ID;
    }
    void name()
    {
        gameObject.name = $"player{ID}";
    }
}
