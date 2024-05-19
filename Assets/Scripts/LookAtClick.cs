using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LookAtClick : MonoBehaviour
{
    [SerializeField]GameObject target;//目標物，讓鏡頭看著的物體
    
    public void setCamTarget(GameObject camTarget)
    {
        target = camTarget;
    }
}
