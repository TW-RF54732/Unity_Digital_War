using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuidingSystem : MonoBehaviour
{
    [SerializeField]GameObject buildPreview, whoBuild,baseSpawner;
    bool previewStart = false;
    [SerializeField]Camera cam;
    [SerializeField] LayerMask floorLayer;

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
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity,floorLayer))
            {
                buildPreview.transform.position = hit.point + new Vector3(0f,0.5f,0f);
            }
        }
    }
    
}
