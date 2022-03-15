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

    #region Events

    public static event Action towerCleared;
    
    private SwipeDetection _swipeDetection;
    private InputsManager _inputsManager;
    private void OnEnable()
    {
        _swipeDetection.Swipping += Swipe;
        _inputsManager.OnTapTouch += Swipe;

        Scr_P_Batracien.OnRemoveFromTower += FallingTower;
        
        
    }

    private void OnDisable()
    {
        _swipeDetection.Swipping -= Swipe;
        _inputsManager.OnTapTouch -= Swipe;
        
        Scr_P_Batracien.OnRemoveFromTower -= FallingTower;


    }

    #endregion
    
    
    
    void Awake()
    {
        //batraciensInTower = gameObject.GetComponent<Scr_TowerCreator>().batraciensInTower;
        feedbacksManager = FindObjectOfType<Scr_FeedbacksManager>().gameObject;
        _swipeDetection = FindObjectOfType<SwipeDetection>();
        _inputsManager  = FindObjectOfType<InputsManager>();
         variables = Resources.Load("CurrentData") as VariablesPropretys;
    }

    void Swipe(ActionTypes swipeType)
    {
        bool batracienRemoved = batraciensInTower[0].GetComponent<IRemoveFromTower>().RemoveFromTower(swipeType);
        
        if (batracienRemoved)
        {
            batraciensInTower.RemoveAt(0);
        }

        if (batraciensInTower.Count == 0)
        {
            if (towerCleared != null) towerCleared();
        }
    }
        
    void FallingTower()
    {
        //Faire en sorte que la tour ne tombe pas desuite
        foreach (GameObject batracien in batraciensInTower)
        {
            LeanTween.moveY(batracien, batracien.transform.position.y-batracien.GetComponent<Scr_P_Batracien>().meshHauteur - offset, variables.fallingTime).setEase(LeanTweenType.easeOutCirc);

            // batracien.transform.Translate(new Vector3(0,-batracien.GetComponent<Scr_P_Batracien>().meshHauteur - offset ,0));
        }

        
    }
    
    

}
