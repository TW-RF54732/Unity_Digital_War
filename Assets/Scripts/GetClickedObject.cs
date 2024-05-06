using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClickedObject : MonoBehaviour
{
    [SerializeField]GameObject clickedObject;
    UIControl uIControl;

    private void Start()
    {
        uIControl = gameObject.GetComponent<UIControl>();
    }
    public void clickedObjectReceive(GameObject receive)
    {
        clickedObject = receive;
        uIControl.setUIposition(clickedObject);
    }
}
