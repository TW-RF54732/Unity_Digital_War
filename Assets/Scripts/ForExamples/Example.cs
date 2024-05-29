using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    public GameObject DragObjectHere;
    [SerializeField] GameObject DragObjectHere2;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject SomeThingTouch;//物件
        SomeThingTouch = collision.gameObject;//被觸碰物件碰撞相的gameobject屬性
    }
}
