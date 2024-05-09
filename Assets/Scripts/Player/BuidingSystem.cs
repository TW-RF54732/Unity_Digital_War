using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuidingSystem : MonoBehaviour
{
    [SerializeField]GameObject buildPreview;
    bool buildisStart = false;
    [SerializeField]Camera cam;
    public void startBuild()
    {
        buildisStart = true;
    }
    private void Update()
    {
        if (buildisStart)
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = cam.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                buildPreview.transform.position = new Vector3(hit.point.x, 0.5f, hit.point.z);
            }
        }
    }
}
