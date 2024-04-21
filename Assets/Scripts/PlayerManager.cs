using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    int ID = 1;
    public int getID()
    {
        int id = ID;
        ID++;
        return id;
    }
}
