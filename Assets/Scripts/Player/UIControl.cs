using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class UIControl : MonoBehaviour
{
    GameObject reciveClickedObject;

    [SerializeField] GameObject atkButton, defButton;

    SpawnID spawnID;
    PlayerID playerID;

    private void Start()
    {
        playerID = gameObject.GetComponent<PlayerID>();
    }
    public void setUIposition(GameObject uiposition)
    {
        if(uiposition.tag == "Base")
        {
            spawnID = uiposition.GetComponent<SpawnID>();
            if (spawnID.GetID() == playerID.getID())
            {
                atkButton.SetActive(true);
                atkButton.transform.position = Input.mousePosition + new Vector3(100, 0, 0) + new Vector3(0, -50, 0);
            }
            if(spawnID.GetID() != playerID.getID())
            {
                defButton.SetActive(true);
                defButton.transform.position = Input.mousePosition + new Vector3(100,0,0) + new Vector3(0,-50,0);
            }
        }
        else
        {
            atkButton.SetActive(false);
            defButton.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            atkButton.SetActive(false);
            defButton.SetActive(false );
        }
    }
}
