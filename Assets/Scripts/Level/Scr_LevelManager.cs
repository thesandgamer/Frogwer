using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Scr_LevelManager : MonoBehaviour
{
    [SerializeField] private Animator transition;

    public static event Action ev_LevelBegin;
    private void Awake()
    {
        if (ev_LevelBegin != null) ev_LevelBegin();
        if (Scr_GameManager.Instance)
        {
            Scr_GameManager.Instance.transition = transition;
        }
    }
}
