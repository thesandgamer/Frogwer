using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Scr_EndLevelUiManager : MonoBehaviour
{
    public static event Action ev_LevelFinish;
    private void OnEnable()
    {
        Scr_TowerManager.towerCleared += LevelSuccess;
        Scr_TimerManager.timerFinished += LevelFailed;
        
    }
    private void OnDisable()
    {
        Scr_TowerManager.towerCleared -= LevelSuccess;
        Scr_TimerManager.timerFinished -= LevelFailed;
    }
    [Header("UI")]
    [SerializeField] private GameObject Ui_EndLevel;
    private Scr_FeedbacksManager fb;

    [SerializeField] private TMP_Text levelNumberText;

    
    [Header("Timer")]
    [SerializeField] private TMP_Text minText;
    [SerializeField] private TMP_Text secText;

    private Scr_TimerManager _timerManager;

    
    private void Awake()
    {
        fb = FindObjectOfType<Scr_FeedbacksManager>();
        _timerManager = FindObjectOfType<Scr_TimerManager>();

    }

    void LevelSuccess()
    {
        ShowEndUi();
    }

    void LevelFailed()
    {
        ShowEndUi();
    }

    private void ShowEndUi()
    {
        if (ev_LevelFinish != null) ev_LevelFinish();

        float timeOfLevel = _timerManager.TotalTime;
        float timeOfFinish = _timerManager.FinalTime;
        float time = timeOfLevel - timeOfFinish;
        
        int minutes = Mathf.FloorToInt(time / 60);
        int secondes = Mathf.FloorToInt(time % 60);
        
        minText.text = minutes.ToString("00");
        secText.text = secondes.ToString("00");

        if (FindObjectOfType<Scr_GameManager>())
        {
            levelNumberText.text = FindObjectOfType<Scr_GameManager>().actualLevel.ToString();
        }
        else
        {
            levelNumberText.text = "Tutorial";
        }
        
        Ui_EndLevel.SetActive(true);
        fb.PopUpUi(Ui_EndLevel);
        

    }

    public void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //FindObjectOfType<Scr_GameManager>().actualLevel--;
        if (FindObjectOfType<Scr_GameManager>())
        {
            Scr_GameManager.Instance.NextLevel(SceneManager.GetActiveScene().buildIndex);
            Scr_GameManager.Instance.actualLevel--;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }
    
    public void NextLevel()
    {
        if (FindObjectOfType<Scr_GameManager>())
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Scr_GameManager.Instance.NextLevel(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

    }


}
