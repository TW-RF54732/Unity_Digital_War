using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    public GameObject DragObjectHere;
    [SerializeField] GameObject DragObjectHere2;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject SomeThingTouch;//����
        SomeThingTouch = collision.gameObject;//�QĲ�I����I���۪�gameobject�ݩ�
    }
}
