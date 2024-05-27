using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class UIControl : MonoBehaviour
{
    GameObject reciveClickedObject;

    [SerializeField] GameObject allView, baseView, previewBase, lookWho;

    SpawnID spawnID;
    PlayerID playerID;
    AttackSystem attackSystem;
    BuidingSystem buidingSystem;

    BaseView CbaseView;

    private void Start()
    {
        playerID = gameObject.GetComponent<PlayerID>();
        attackSystem = gameObject.GetComponent<AttackSystem>();
        buidingSystem = gameObject.GetComponent <BuidingSystem>();
        PlayerSpawnBase spawnBase = gameObject.GetComponent<PlayerSpawnBase>();
        CbaseView = baseView.GetComponent<BaseView>();
        lookWho = spawnBase.startBase;
        _BaseView();
    }
    public void getClickObj(GameObject obj)
    {
        if(obj.tag != "Floor" || obj != null)
        {
            lookWho = obj;
            if (obj.tag == "Base")
            {
                _BaseView();
            }
            if(obj.tag == "Base Preview")
            {
                _PreviewBaseView();
            }
        }
    }
    public void _AllView()
    {
        baseView.SetActive(false);
        previewBase.SetActive(false);
        allView.SetActive(true);
        lookWho = null;
    }
    public void _BaseView()
    {
        allView.SetActive(false);
        previewBase.SetActive(false);
        baseView.SetActive(true);
        CbaseView.isLooking(lookWho);
    }
    public void _PreviewBaseView()
    {
        allView.SetActive(false);
        baseView.SetActive(false);
        previewBase.SetActive(true);
    }

}
    