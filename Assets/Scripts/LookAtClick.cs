using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LookAtClick : MonoBehaviour
{
    [SerializeField]GameObject target;
    Camera cam;
    bool follow = false;

    Vector3 _offset, _curr = Vector3.zero;

    [SerializeField]float smoothTime = 0.25f;

    private void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }
    public void setCamTarget(GameObject _target)
    {
        target = _target;
        _offset = transform.position - target.transform.position;
        follow = true;
    }
    private void LateUpdate()
    {
        if(follow)
        {
            Vector3 targetPos = target.transform.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _curr, smoothTime);
            if(Input.GetButtonDown("esc") == true )
            {
                follow = false;
            }
        }

    }
}
