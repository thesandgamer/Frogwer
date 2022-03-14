using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_EndLevelUiManager : MonoBehaviour
{
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

    [SerializeField] private GameObject Ui_EndLevel;

    void LevelSuccess()
    {
        Ui_EndLevel.SetActive(true);
    }

    void LevelFailed()
    {
        Ui_EndLevel.SetActive(true);

    }

    public void RestartLevel()
    {
        print("Scene " + SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
