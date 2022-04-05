using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Scr_CameraManager : MonoBehaviour
{
    public static event Action cameraIntroFinished;

    //Final location: la location en bas de la tour
    private Vector3 finalLocation;

    //Start location: la location en haut de la tour(avec le batracien tout en haut visisble)
    private Vector3 startLocation;

    [SerializeField] private Scr_TowerManager towerManger;
    [SerializeField] private float timeForPlan = 2;
    [SerializeField] private LeanTweenType easeType;

    private void Awake()
    {
        finalLocation = transform.position;
        startLocation = towerManger.batraciensInTower[towerManger.batraciensInTower.Count-1].transform.position;

        //Bouge la caméra ensuite 
        transform.position = new Vector3(transform.position.x,startLocation.y,transform.position.z);
        IntroductionCameraPlan();
    }

    void IntroductionCameraPlan()
    {
        int id = LeanTween.moveY(gameObject, finalLocation.y, timeForPlan).setEase(easeType).setDelay(0).id;
        LTDescr d = LeanTween.descr( id );

        if(d!=null){ // if the tween has already finished it will return null
            // change some parameters
            d.setOnComplete( Finish );
        }
        
    }

    void Finish()
    {
        Debug.Log("FINISH");
        if (cameraIntroFinished != null) cameraIntroFinished();
        Destroy(this);

    }

}
