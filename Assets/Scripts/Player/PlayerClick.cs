using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerClick : MonoBehaviour
{
    [SerializeField]Camera cam;
    public GameObject clickObject;
    [SerializeField]List<GameObject> needClickobj;

    GetClickedObject GCO;
    LookAtClick lookAtClick;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickObject = GetClickedObject(out RaycastHit hit);
            if(clickObject != null)
            {
                if(clickObject.tag == "base")
                {
                    lookAtClick = gameObject.GetComponent<LookAtClick>();
                    lookAtClick.setCamTarget(clickObject);
                }
                for (int i = 0; i < needClickobj.Count; i++)
                {
                    GCO = needClickobj[i].GetComponent<GetClickedObject>();
                    GCO.clickedObjectReceive(clickObject);
                }
            }
        }
    }

    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            if (!isPointerOverUIObject()) { target = hit.collider.gameObject; }
        }
        return target;
    }
    private bool isPointerOverUIObject()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        return results.Count > 0;
    }
}
