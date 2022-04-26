using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scr_GameManager : MonoBehaviour
{
    //On récupère le data du level (liste des batraciens, décors environnant, temps du timer,WIP)
    public bool testingMode;
    [SerializeField] private BatracienTower levelToTest;

    
    [SerializeField] private List<BatracienTower> levels;
    private Scr_TowerCreator towerCreator;

    [SerializeField]public int actualLevel = 0;

    public static Scr_GameManager Instance;

    [SerializeField] public Animator transition;
    private float transitionTime = 1f;



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

        if (testingMode)
        {
            towerCreator = FindObjectOfType<Scr_TowerCreator>();
            towerCreator.towerData = levelToTest;
            
            FindObjectOfType<Scr_TimerManager>().startTime = levelToTest.time;
            return;

        }
        if (actualLevel <= levels.Count)
        {
            print("LevelStart");
            towerCreator = FindObjectOfType<Scr_TowerCreator>();
            towerCreator.towerData = levels[actualLevel];

            FindObjectOfType<Scr_TimerManager>().startTime = levels[actualLevel].time;
            actualLevel++;
        }
        else
        {
            print("Finish All levels");
            actualLevel = 0;
        }

    }

    public void NextLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        StartCoroutine(LoadLevel((levelIndex)));
    }
    
    
        
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);


    }


    private void OnDisable()
    {
        Scr_LevelManager.ev_LevelBegin -= SwitchLevel;

    }
}
