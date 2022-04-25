using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject towerManager;

    private void Awake()
    {
        //towerManager.SetActive(false);
    }

    public void DoNothing()
    {
        print("Do nothing");
    }
}
