using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    [SerializeField]GameObject target;
    public float speed = 5f;
    public int armyAmount = 10, dead = 0;
    float atk = 1;
    bool move = true;

    BaseFight baseFight;
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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == target)
        {
            Debug.Log("hit");
            move = false;
            baseFight = collision.gameObject.GetComponent<BaseFight>();
            dead = baseFight.baseFight(Mathf.RoundToInt(armyAmount * atk));
            armyAmount -= dead;
            Destroy(gameObject);
        }
    }
}
