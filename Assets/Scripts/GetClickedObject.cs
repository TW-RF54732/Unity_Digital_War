using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClickedObject : MonoBehaviour
{
    [SerializeField]GameObject clickedObject;

    public void clickedObjectReceive(GameObject receive)
    {
        clickedObject = receive;
    }
}
