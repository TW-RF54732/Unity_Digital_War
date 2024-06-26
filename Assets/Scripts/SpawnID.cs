using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnID : MonoBehaviour
{
    [SerializeField]GameObject playerObj;
    PlayerID playerID;

    [SerializeField] int itemID;
    private void Start()
    {
        playerObj = transform.parent.parent.gameObject;
        playerID = playerObj.GetComponent<PlayerID>();
        itemID = playerID.getID();
    }
    public void setID(int inID)
    {
        itemID = inID;
    }
    public void setPlayer(GameObject player)
    {
        playerObj = player;
    }
    public int GetID()
    {
        return itemID;
    }
    public GameObject getPlayerObj()
    {
        return playerObj;
    }
}
