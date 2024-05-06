using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] GameObject attacker,target;
    [SerializeField]int atkArmy = 10;

    FindLibObject findLibObject;
    SoldierMovement soldierMovement;
    private void Start()
    {
        findLibObject = GameObject.FindAnyObjectByType<FindLibObject>();
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
        GameObject copySoldier = Instantiate(findLibObject.getObject(2),attacker.transform) ;
        soldierMovement = copySoldier.GetComponent<SoldierMovement>();
        soldierMovement.SetTarget(target);
    }
}