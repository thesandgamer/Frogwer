using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Faire un affichage custom pour le temps: Minutes:Segondes (custom GUI)
[Serializable]
struct TimeFormat
{
   [SerializeField] public float min;
   [SerializeField] [Range(0, 59)]public float seg;
}
public class Scr_TimerManager : MonoBehaviour
{
    public static event Action timerFinished;


    [SerializeField] private TMP_Text minText;
    [SerializeField] private TMP_Text secText;

    [SerializeField] private TimeFormat startTime;
    private float totalTime = 0f; 

    private bool timerIsRunning = false;
    
    private IEnumerator coroutine;


    private void OnEnable()
    {
        Scr_TowerManager.towerCleared += PauseTimer;
    }    
    private void OnDisable()
    {
        Scr_TowerManager.towerCleared -= PauseTimer;
    }


    private void Awake()
    {
        totalTime = startTime.min * 60 + startTime.seg;
        DisplayTimer();
        coroutine = TimerIsRunning();
        StartTimer();
    }


    public void StartTimer()
    {
        StartCoroutine(coroutine);
    }

    IEnumerator TimerIsRunning()
    {
        while (true)
        {
            if (totalTime > 0)
            {
                DisplayTimer();
                totalTime -= Time.deltaTime;
            }
            else
            {
                totalTime = 0;
                PauseTimer();
                if (timerFinished != null) timerFinished();
            }
            yield return null;
        }
    }
    
    private void PauseTimer()
    {
        StopCoroutine(coroutine);
        print("Stopped timer at " + Time.time);
    }


    void DisplayTimer()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60);
        int secondes = Mathf.FloorToInt(totalTime % 60);
        minText.text = minutes.ToString("00");
        secText.text = secondes.ToString("00");
       // secText.text = string.Format("{0:00}:{1:00}",minutes, secondes);
        
    }
    
}
