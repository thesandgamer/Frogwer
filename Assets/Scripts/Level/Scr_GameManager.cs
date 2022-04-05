using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GameManager : MonoBehaviour
{
    //On récupère le data du level (liste des batraciens, décors environnant, temps du timer,WIP)
    [SerializeField] private List<BatracienTower> levels;
    [SerializeField] private Scr_TowerCreator towerCreator;

    [SerializeField]public int actualLevel = 0;

    public static Scr_GameManager Instance;


    private void OnEnable()
    {
        Scr_LevelManager.ev_LevelBegin += SwitchLevel;
    }
    void Awake ()   
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    }

    public void SwitchLevel()
    {
        if (actualLevel <= levels.Count)
        {
            print("LevelStart");
            towerCreator = FindObjectOfType<Scr_TowerCreator>();
            towerCreator.towerData = levels[actualLevel];
            actualLevel++;
        }
        else
        {
            print("Finish All levels");
            actualLevel = 0;
        }

    }

    private void OnDisable()
    {
        Scr_LevelManager.ev_LevelBegin -= SwitchLevel;

    }
}
