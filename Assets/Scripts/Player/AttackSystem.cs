using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] GameObject attacker,target;
    [SerializeField]int atkArmy = 10;

    private void Start()
    {
    }
    public bool SetAttack(GameObject atk = null,GameObject tar = null)
    {
        attacker = atk;
        target = tar;
        if(attacker != null && target != null)
        {
            return true;
        }
        return false;
    }
    public void startWar()
    {
        BaseFight baseFight = attacker.gameObject.GetComponent<BaseFight>();
        baseFight.SendArmy(target);
    }
}
