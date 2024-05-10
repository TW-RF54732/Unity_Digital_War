using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuidingSystem : MonoBehaviour
{
    [SerializeField]GameObject buildPreview, whoBuild,baseSpawner;
    bool previewStart = false;
    [SerializeField]Camera cam;

    UIControl _UIControl;
    FindLibObject findLibObject;
    private void Start()
    {
        findLibObject = GameObject.FindFirstObjectByType<FindLibObject>();
        _UIControl = gameObject.GetComponent<UIControl>();
    }
    public void startPreview()
    {
        previewStart = true;
        buildPreview = Instantiate(buildPreview, baseSpawner.transform);
        buildPreview.SetActive(true);
    }
    private void Update()
    {
        if (previewStart)
        {
            if(Input.GetMouseButtonDown(0)) 
            { 
                previewStart = false; 

            }
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = cam.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                buildPreview.transform.position = new Vector3(hit.point.x, 0.5f, hit.point.z);
            }
        }
    }
    public void setBuilder(GameObject builder)
    {
        whoBuild = builder;
    }
    public void startBuild()
    {
        //®ø¯Ó¸ê·½
        GameObject copySolder = Instantiate(findLibObject.getObject(2), whoBuild.transform);

    }
}
