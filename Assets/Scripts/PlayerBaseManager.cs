using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseManager : MonoBehaviour
{
    int ID,childCount;

    [SerializeField]Material material;

    PlayerID playerID;
    SpawnID spawnID;

    private void Start()
    {
        playerID = transform.parent.GetComponent<PlayerID>();
        ID = playerID.getID();
    }

    public void CheckInBase(GameObject theBase)
    {
        theBase.transform.parent = gameObject.transform;
        childCount = transform.childCount;
        theBase.name = $"Base {ID}-{childCount}";
        spawnID = theBase.GetComponent<SpawnID>();
        spawnID.setID(ID);
        theBase
    }
}
