using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFight : MonoBehaviour
{
    public int soldierAmount = 100;
    public float def = 0.5f,Atk = 1f;
    int killed, dead;

    public int baseFight(int hostileArmyAmount,float hostileArmyDef = 0f,float hostileArmyAtk = 1f)
    {
        
        waiter(2);
        return hostileArmyAmount;
    }
    IEnumerator waiter(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
