using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class UIControl : MonoBehaviour
{
    GameObject reciveClickedObject;

    [SerializeField] GameObject atkButton, defButton,fightButton,buildButton,startBuildBtn;
    GameObject tmpPlayerBase, tmpTarget;

    SpawnID spawnID;
    PlayerID playerID;
    AttackSystem attackSystem;
    BuidingSystem buidingSystem;

    private void Start()
    {
        playerID = gameObject.GetComponent<PlayerID>();
        attackSystem = gameObject.GetComponent<AttackSystem>();
        buidingSystem = gameObject.GetComponent <BuidingSystem>();
    }
    public void setUIposition(GameObject uiposition)
    {
        if(uiposition.tag == "Base")
        {
            spawnID = uiposition.GetComponent<SpawnID>();
            if (spawnID.GetID() == playerID.getID())
            {
                atkButton.SetActive(true);
                buildButton.SetActive(true);
                defButton.SetActive(false);
                tmpPlayerBase = uiposition;
                Vector3 mousePos = Input.mousePosition;
                atkButton.transform.position = mousePos + new Vector3(100, 0, 0) + new Vector3(0, -50, 0);
                buildButton.transform.position = mousePos + new Vector3(-100, 0, 0) + new Vector3(0, -50, 0);
            }
            if(spawnID.GetID() != playerID.getID())
            {
                defButton.SetActive(true);
                buildButton.SetActive(false);
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
        if(attackSystem.SetAttack(tmpPlayerBase,tmpTarget) == true)
        {
            showFightButton();
        }
    }
    public void UIbtn_SetTarget()
    {
        if(attackSystem.SetAttack(tmpPlayerBase, tmpTarget) == true)
        {
            showFightButton();
        }
    }

    public void buildBtnPress()
    {
        buildButton.SetActive(false);
        atkButton.SetActive(false);
        buidingSystem.setBuilder(tmpPlayerBase);
    }

    void showFightButton()
    {
        fightButton.SetActive(true);
    }
    public void showStartBuildBtn()
    {
        startBuildBtn.SetActive(true);
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
