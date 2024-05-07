using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFight : MonoBehaviour
{
    public int soldierAmount = 100;
    public float def = 0.5f,Atk = 1f;

    public int baseFight(int hostileArmyDmg)
    {
        int kill = Mathf.RoundToInt(soldierAmount * Atk);
        soldierAmount -= hostileArmyDmg;
        waiter(2);
        return kill;
    }
    IEnumerator waiter(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
