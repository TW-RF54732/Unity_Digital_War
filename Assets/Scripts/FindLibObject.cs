using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindLibObject : MonoBehaviour
{
    [SerializeField]List<GameObject> LibObjectList = new List<GameObject>();

    public GameObject getObjectFromLib(int object_id)
    {
        return LibObjectList[object_id];
    }

}
