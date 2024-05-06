using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class UIControl : MonoBehaviour
{
    GameObject reciveClickedObject;

    [SerializeField] GameObject atkButton, defButton,fightButton;
    GameObject tmpAttacker, tmpTarget;

    SpawnID spawnID;
    PlayerID playerID;
    AttackSystem attackSystem;

    private void Start()
    {
        playerID = gameObject.GetComponent<PlayerID>();
        attackSystem = gameObject.GetComponent<AttackSystem>();
    }
    public void setUIposition(GameObject uiposition)
    {
        if(uiposition.tag == "Base")
        {
            spawnID = uiposition.GetComponent<SpawnID>();
            if (spawnID.GetID() == playerID.getID())
            {
                atkButton.SetActive(true);
                defButton.SetActive(false);
                tmpAttacker = uiposition;
                atkButton.transform.position = Input.mousePosition + new Vector3(100, 0, 0) + new Vector3(0, -50, 0);
            }
            if(spawnID.GetID() != playerID.getID())
            {
                defButton.SetActive(true);
                atkButton.SetActive(false);
                tmpTarget = uiposition;
                defButton.transform.position = Input.mousePosition + new Vector3(100,0,0) + new Vector3(0,-50,0);
            }
        }
        else
        {
            atkButton.SetActive(false);
            defButton.SetActive(false);
        }
    }

    public void UIbtn_SetAttacker()
    {
        if(attackSystem.SetAttack(tmpAttacker,tmpTarget) == true)
        {
            showFightButton();
        }
    }
    public void UIbtn_SetTarget()
    {
        if(attackSystem.SetAttack(tmpAttacker, tmpTarget) == true)
        {
            showFightButton();
        }
    }

    void showFightButton()
    {
        fightButton.SetActive(true);
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
