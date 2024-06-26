 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFight : MonoBehaviour
{
    public int soldierAmount;
    public float def = 0.5f,Atk = 1f;

    public int goFightSoldierAmount = 10;
    
    GameObject armyObj;

    FindLibObject findLibObject;
    private void Start()
    {
        findLibObject = GameObject.FindAnyObjectByType<FindLibObject>();
        armyObj = findLibObject.getObjectFromLib(2);
    }
    public int BaseGotAtk(int hostileArmyDmg,GameObject Atker)
    {
        int kill = Mathf.RoundToInt(soldierAmount * Atk);
        soldierAmount -= Mathf.RoundToInt(hostileArmyDmg * def);
        if (soldierAmount <= 0)//如果士兵足夠供打下此堡壘，則此堡壘加入該玩家
        {
            PlayerBaseManager playerBaseManager = Atker.transform.parent.parent.gameObject.GetComponent<PlayerBaseManager>();
            playerBaseManager.CheckInBase(gameObject);
        }
        return kill;
    }
    public void SendArmy(GameObject sandToObj)
    {
        if(soldierAmount >= goFightSoldierAmount)
        {
            GameObject copyArmy = Instantiate(armyObj, gameObject.transform);
            SoldierMovement soldierMovement = copyArmy.GetComponent<SoldierMovement>();
            soldierMovement.armyAmount = goFightSoldierAmount;
            soldierAmount -= goFightSoldierAmount;
            soldierMovement.SetTarget(sandToObj);
        }
    }
    public void ArmyEnter(int soldierEnterAmount)
    {
        soldierAmount += soldierEnterAmount;
    }



    IEnumerator waiter(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
