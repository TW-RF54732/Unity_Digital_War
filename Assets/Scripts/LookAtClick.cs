using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LookAtClick : MonoBehaviour
{
    [SerializeField]GameObject target;//�ؼЪ��A�����Y�ݵ۪�����
    
    public void setCamTarget(GameObject camTarget)
    {
        target = camTarget;
    }
}
