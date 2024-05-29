using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseManager : MonoBehaviour
{
    int ID,childCount;
    public bool test;

    [SerializeField]GameObject playerObj;
    Renderer objRender;

    PlayerID playerID;
    SpawnID spawnID;

    private void Start()
    {
        getID();
    }

    public void CheckInBase(GameObject theBase)
    {
        theBase.transform.parent = gameObject.transform;
        childCount = transform.childCount;
        getID();
        theBase.name = $"Base {ID}-{childCount}";
        spawnID = theBase.GetComponent<SpawnID>();
        spawnID.setID(ID);
        spawnID.setPlayer(gameObject.transform.parent.gameObject);
        if(test)
        {
            objRender = theBase.GetComponent<Renderer>();
            objRender.material.color = Color.cyan;
        }
    }
    int getID()
    {
        playerID = playerObj.GetComponent<PlayerID>();
        ID = playerID.getID();
        return ID; 
    }
}
