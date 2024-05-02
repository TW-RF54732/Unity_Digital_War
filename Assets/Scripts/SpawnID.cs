using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnID : MonoBehaviour
{
    [SerializeField]GameObject playerObj;
    PlayerID playerID;

    [SerializeField] int soldierID;
    private void Start()
    {
        playerObj = transform.parent.parent.gameObject;
        playerID = playerObj.GetComponent<PlayerID>();
        soldierID = playerID.getID();
    }
}
