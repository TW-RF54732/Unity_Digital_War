using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField]int resourceAmount = 0;

    public void gainResource(int amount)
    {
        resourceAmount += amount;
    }
    public bool costResourceAmount(int amount)
    {
        if (resourceAmount < amount)
        {
            return false;
        }
        else
        {
            resourceAmount -= amount;
            return true;
        }
    }
    public int getResourceAmount()
    {
        return resourceAmount;
    }
    public void setResourceAmount(int amount)
    {
        resourceAmount = amount;
    }
}
