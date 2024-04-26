using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindLibObject : MonoBehaviour
{
    [SerializeField]List<GameObject> list = new List<GameObject>();

    public GameObject getObject(int object_id)
    {
        return list[object_id];
    }

}
