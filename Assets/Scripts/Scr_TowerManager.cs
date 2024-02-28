using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_TowerManager : MonoBehaviour
{
    public List<GameObject> batraciensInTower;
    
    private GameObject feedbacksManager;
    
   [SerializeField] private VariablesPropretys variables;

   [HideInInspector] public float offset;

   [SerializeField] private float timeToFall = .2f;


    #region Events

    public static event Action towerCleared;
    
    private SwipeDetection _swipeDetection;
    private InputsManager _inputsManager;
    private void OnEnable()
    {
        _swipeDetection.Swipping += BatracienRemoved;
        _inputsManager.OnTapTouch += BatracienRemoved;

       // Scr_P_Batracien.OnRemoveFromTower += FallingTower;
        
        
    }

    private void OnDisable()
    {
        _swipeDetection.Swipping -= BatracienRemoved;
        _inputsManager.OnTapTouch -= BatracienRemoved;
        
        //Scr_P_Batracien.OnRemoveFromTower -= FallingTower;


    }

    #endregion

    private void Awake()
    {
        //batraciensInTower = gameObject.GetComponent<Scr_TowerCreator>().batraciensInTower;
        feedbacksManager = FindObjectOfType<Scr_FeedbacksManager>().gameObject;
        _swipeDetection = FindObjectOfType<SwipeDetection>();
        _inputsManager  = FindObjectOfType<InputsManager>();
        variables = Resources.Load("CurrentData") as VariablesPropretys;
    }

    float posGoTo = 0;

    void BatracienRemoved(ActionTypes swipeType)
    {
        bool batracienRemoved = batraciensInTower[0].GetComponent<IRemoveFromTower>().RemoveFromTower(swipeType);

        if (batracienRemoved)
        {
            if (batraciensInTower.Count > 0)
            {
                posGoTo = batraciensInTower[0].transform.position.y;
                batraciensInTower[0].transform.parent = null;
                batraciensInTower.RemoveAt(0);
                Invoke("FallingTower",timeToFall);
            }
        }
        if (batraciensInTower.Count == 0)
        {
            if (towerCleared != null) towerCleared();
        }
    }


    void FallingTower()
    {
        for (int i = 0; i < batraciensInTower.Count; i++)
        {
            if (i > 0)
            {
                posGoTo += batraciensInTower[i - 1].GetComponent<Scr_P_Batracien>().imageHeight + offset;
                //posGoTo = batraciensInTower[i-1].transform.position.y + batraciensInTower[i-1].GetComponent<Scr_P_Batracien>().imageHeight + offset;
            }
            
            LeanTween.moveY(batraciensInTower[i], posGoTo, variables.fallingTime).setEase(LeanTweenType.easeOutCirc);
        }
        /*
        //Pour chaque élément de la tour, l'élément va se déplacer à une position en dessous
        foreach (GameObject batracien in batraciensInTower)
        {
            LeanTween.moveY(batracien, batracien.transform.position.y-batracien.GetComponent<Scr_P_Batracien>().imageHeight - offset, variables.fallingTime).setEase(LeanTweenType.easeOutCirc);
        }*/

        
    }
    
    

}
