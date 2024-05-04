using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    [SerializeField]GameObject target;
    public float speed = 0.5f;

    public void SetTarget(GameObject targetIn)
    {
        target = targetIn;
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
            if(target.transform.position == transform.position)
            {
                target = null;
            }
        }
    }
}
