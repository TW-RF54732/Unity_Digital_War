using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    [SerializeField]GameObject target;
    public float speed = 5f;
    public int armyAmount = 10, dead = 0;
    float atk = 1f;
    bool move = true;

    BaseFight baseFight;
    private void Start()
    {
        baseFight = target.GetComponent<BaseFight>();
    }
    public void SetTarget(GameObject targetIn)
    {
        target = targetIn;
    }
    private void FixedUpdate()
    {
        if(move)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }
    }
    private void OnCollisionEnter(Collision collision)//attack
    {
        if(collision.gameObject == target)
        {
            if (checkID())//ID相同，已成我方堡壘
            {
                baseFight.ArmyEnter(armyAmount);
                Destroy(gameObject);
            }
            else//ID不同，攻擊堡壘
            {
                move = false;
                dead = baseFight.BaseGotAtk(Mathf.RoundToInt(armyAmount * atk), gameObject);
                armyAmount -= dead;
                if(armyAmount > 0)
                {
                    Debug.Log(armyAmount);  
                    baseFight.ArmyEnter(armyAmount);
                }
                Destroy(gameObject);
            }
        }
    }
    bool checkID()
    {
        int checkID;
        SpawnID spawnID;
        spawnID = target.GetComponent<SpawnID>();
        checkID = spawnID.GetID();
        spawnID = gameObject.GetComponent<SpawnID>();
        if(checkID == spawnID.GetID())
        {
            return true;//我方堡壘
        }
        else { return false; }//敵方
    }
}
