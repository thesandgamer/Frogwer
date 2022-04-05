using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Scr_LevelManager : MonoBehaviour
{
    public static event Action ev_LevelBegin;
    private void Awake()
    {
        if (ev_LevelBegin != null) ev_LevelBegin();
    }
}
