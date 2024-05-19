using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BaseFight : MonoBehaviour
{
    public int soldierAmount;
    public float def = 0.5f,Atk = 1f;

    [SerializeField]int goFightSoldierAmount = 10;

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
        if (soldierAmount <= 0)
        {
            PlayerBaseManager playerBaseManager = Atker.transform.parent.parent.gameObject.GetComponent<PlayerBaseManager>();
            playerBaseManager.CheckInBase(gameObject);
        }
        return kill;
    }
    public void GoFight(GameObject AtkWho)
    {
        if(soldierAmount >= goFightSoldierAmount)
        {
            GameObject copyArmy = Instantiate(armyObj, gameObject.transform);
            SoldierMovement soldierMovement = copyArmy.GetComponent<SoldierMovement>();
            soldierMovement.armyAmount = goFightSoldierAmount;
            soldierAmount -= goFightSoldierAmount;
            soldierMovement.SetTarget(AtkWho);
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
