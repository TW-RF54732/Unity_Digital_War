using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseManager : MonoBehaviour
{
    int ID,childCount;

    [SerializeField]Material material;
    [SerializeField]GameObject playerObj;

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
    }
    int getID()
    {
        playerID = playerObj.GetComponent<PlayerID>();
        ID = playerID.getID();
        return ID; 
    }
}
