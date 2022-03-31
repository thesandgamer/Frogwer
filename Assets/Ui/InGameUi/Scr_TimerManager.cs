using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine.Serialization;
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
    public static event Action ev_GoFinished;


    [Header("Timer")]
    [SerializeField] private GameObject panelTimer;

    [SerializeField] private TMP_Text minText;
    [SerializeField] private TMP_Text secText;

    [SerializeField] private TimeFormat startTime;
    
    [Header("Timer")]
    [SerializeField] private GameObject panelGo;
    [SerializeField] private TMP_Text goText;



    private float totalTime = 0f;
    private float levelTime;
    public float TotalTime{ get { return levelTime;}}

    public float FinalTime{ get { return totalTime;}}


    private bool timerIsRunning = false;
    
    private IEnumerator coroutine;
    private IEnumerator goCoroutine;

    private Scr_FeedbacksManager fb;


    private void OnEnable()
    {
        Scr_TowerManager.towerCleared += PauseTimer;
        Scr_CameraManager.cameraIntroFinished += ThreeTwoOneGo;

        fb = FindObjectOfType<Scr_FeedbacksManager>();
        
        coroutine = TimerIsRunning();
        goCoroutine = UiGo();
        
        totalTime = startTime.min * 60 + startTime.seg;
        levelTime = totalTime;
        panelTimer.SetActive(false);
        panelGo.SetActive(false);

            

        


    }    
    private void OnDisable()
    {
        Scr_TowerManager.towerCleared -= PauseTimer;
        Scr_CameraManager.cameraIntroFinished -= ThreeTwoOneGo;

    }

    void ThreeTwoOneGo()
    {
        panelTimer.SetActive(true);
        DisplayTimer();

        fb.PopUpTimer(panelTimer);

        StartCoroutine(UiGo());

    }


    public void StartTimer()
    {
        StartCoroutine(coroutine);
        enabled = true;
    }


    IEnumerator TimerIsRunning()
    {
        //Peut être éviter de faire ça
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
        yield return null;

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
    
    
    IEnumerator UiGo()
    {
        yield return new WaitForSeconds(0.2f); //Premier wait pour attendre un peut
        
        panelGo.SetActive(true);
        
        panelGo.transform.localScale = Vector3.zero;
/* Trop long
        goText.text = "3";
        
        fb.PopUpTimer(panelGo); //Remplacer par un PopUpGo
        yield return new WaitForSeconds(1.3f);
        fb.DePopGo(panelGo);

        yield return new WaitForSeconds(1f);
        
        goText.text = "2";

        
        fb.PopUpTimer(panelGo); //Remplacer par un PopUpGo
        yield return new WaitForSeconds(1.3f);
        fb.DePopGo(panelGo);

        yield return new WaitForSeconds(1f);
        goText.text = "1";
        
        fb.PopUpTimer(panelGo); //Remplacer par un PopUpGo
        yield return new WaitForSeconds(1.3f);
        fb.DePopGo(panelGo);
*/
        yield return new WaitForSeconds(0.8f);
        goText.text = "Go";
        if (ev_GoFinished != null) ev_GoFinished();

        fb.PopUpTimer(panelGo); //Remplacer par un PopUpGo
        yield return new WaitForSeconds(1f);
        fb.DePopGo(panelGo);
        

        StartTimer();

        yield return new WaitForSeconds(0.1f);

        panelGo.SetActive(false);

        StopCoroutine(UiGo());


    }
    
}
