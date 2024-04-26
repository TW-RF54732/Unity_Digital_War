using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    int ID = 1;
    public int getID()
    {
        int id = ID;
        ID++;
        return id;
    }

    public int playerAmount;
    public GameObject playerObj;

    private void Start()
    {
        for (int i = 0; i < playerAmount; i++)
        {
            GameObject CopyPlayerObj = Instantiate(playerObj, this.transform);
            CopyPlayerObj.name = $"Player{i + 1}";
            PlayerID playerID = CopyPlayerObj.GetComponent<PlayerID>();
            playerID.playerManagerObj = this.gameObject;
        }
    }
}
