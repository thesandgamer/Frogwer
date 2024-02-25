using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_P_Batracien : MonoBehaviour
{
    [HideInInspector]public float meshHauteur { get; set; }
    
    protected Scr_FeedbacksManager fbManager;

    private void Awake()
    {
        fbManager = FindObjectOfType<Scr_FeedbacksManager>();
    }
    
    public  delegate void RemoveFromTower();
    public static event RemoveFromTower OnRemoveFromTower;
    private void Start()
    {
        meshHauteur = GetComponentInChildren<SpriteRenderer>().bounds.size.y;
    }





    protected void RemovedFromTower()
    {
        if (OnRemoveFromTower != null) OnRemoveFromTower();
    }
    
    
    
    
    
    
}
