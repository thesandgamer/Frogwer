using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_P_Batracien : MonoBehaviour
{
    [HideInInspector]public float meshHauteur { get; set; }
    
    public  delegate void RemoveFromTower();
    public static event RemoveFromTower OnRemoveFromTower;
    private void Start()
    {
        meshHauteur = GetComponent<MeshFilter>().sharedMesh.bounds.size.y;
    }





    protected void RemovedFromTower()
    {
        if (OnRemoveFromTower != null) OnRemoveFromTower();
    }
    
    
    
    
    
    
}
