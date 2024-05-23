using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerClick : MonoBehaviour
{
    [SerializeField]Camera cam;
    public GameObject clickObject;
    [SerializeField]GameObject playerObject;

    CameraController lookAtClick;
    UIControl UICtrl;

    Vector3 camPos = new Vector3(0,20,0);
    Vector3 zero = Vector3.zero;
    Quaternion camLook;

    bool lookback = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickObject = GetClickedObject(out RaycastHit hit);
            if(clickObject != null)
            {
                if(clickObject.tag == "Base")
                {
                    camPos = gameObject.transform.position;
                    camLook = gameObject.transform.rotation;
                    lookAtClick.enabled = true;
                    lookAtClick.CameraTarget = clickObject.transform;
                    lookback = false;
                }
                UICtrl.setUIposition(clickObject);
            }
        }
        if (Input.GetKeyDown("escape"))
        {
            lookAtClick.enabled = false;
            lookback = true;
        }
    }
    private void LateUpdate()
    {
        if(lookback)
        {
            gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPos, ref zero, 25f * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, camLook, 5.0f * Time.deltaTime);
            if(Vector3.Distance(transform.position, camPos) < 0.2f)
            {
                lookback = false;
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
    private void Start()
    {
        UICtrl = playerObject.GetComponent<UIControl>();
        lookAtClick = gameObject.GetComponent<CameraController>();

    }
}
