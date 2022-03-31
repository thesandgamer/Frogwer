using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_FeedbacksManager : MonoBehaviour
{
    private Scr_Tweener_Feedbacks tweener;

    private VariablesPropretys variables;

    [Header("   Frog")] 
    [SerializeField] private GameObject fx_ToadCollected_Prefab;
    [Header("   Toad")] 
    [SerializeField] private GameObject fx_FrogEjected_Prefab;

    private void OnEnable()
    {
        variables = Resources.Load("CurrentData") as VariablesPropretys;

    }

    private void Awake()
    {
        tweener = GetComponent<Scr_Tweener_Feedbacks>();
    }


    public void ToadDefetead(GameObject toad,bool projectionLeft)
    {
        //On étire la grenouille
        int direction = 0;
        if (projectionLeft) direction = 180;
        GameObject fx = Instantiate(fx_FrogEjected_Prefab, toad.transform);
        fx.transform.Rotate(direction, 0.0f, 0.0f, Space.Self);

        tweener.Stretch(toad,new Vector3(1.2f,0.8f,0.8f),0.5f,0.1f);
        
        //Fait spawn FX: traits de vitesse

        //Joue Son
        
        //Joue animation

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="toad"></param>
    /// <param name="direction: is left?"></param>
    public void ToadBlock(GameObject toad, bool direction)
    {
        //On squach le crapau
        tweener.Squash(toad, new Vector3(0.9f, 1.1f, 1.1f), 0.1f, 0.01f);
        
        //Fait spawn FX: étincelles du coté bouclier + particules bouclier
        
        //Joue animation
        
        //Sons
    }


    public void ToadBlockLeft(GameObject toad)
    {
        //On squach le crapau
        
        //Fait spawn FX: étincelles du coté bouclier + particules bouclier
        
        //Joue animation
        
        //Sons
    }
    
    public void NotGood(GameObject batracien)
    {
        //On squach le crapau
        tweener.NotGood(batracien, new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
        
        //Fait spawn FX: étincelles du coté bouclier + particules bouclier
        
        //Joue animation
        
        //Sons
    }

    public void FrogCollect(GameObject frog)
    {
        //Fait spawn FX: étincelles
        Instantiate(fx_ToadCollected_Prefab, frog.transform.position,frog.transform.rotation);
        
        //Joue Sons
        
        //Joue animation
        
        //Grossit la grenouille et on la fait disparaitre
        tweener.SizeUpAndDispawn(frog,variables.frogDisaperingTime,0f);

        
    }


    public void FallingTowerFB()
    {
        
    }

    public void TouchingGroundTowerFB()
    {
        
    }

    public void PopUpUi(GameObject panel)
    {
        panel.transform.localScale = Vector3.zero;
        tweener.PopUp(panel,Vector3.one, 0.5f,0,LeanTweenType.easeOutBounce);
    }
    
    public void DePopUpUi(GameObject panel)
    {
        panel.transform.localScale = Vector3.one;
        tweener.PopUp(panel,Vector3.zero, 0.5f,0,LeanTweenType.easeOutBounce);
    }
    
    
    public void PopUpTimer(GameObject panel)
    {
        panel.transform.localScale = Vector3.zero;
        tweener.PopUp(panel,Vector3.one, 0.5f,0,LeanTweenType.easeOutBack);
    }
    
    public void DePopGo(GameObject panel)
    {
       // panel.transform.localScale = Vector3.one;
        tweener.PopUp(panel,Vector3.zero, 0.5f,0,LeanTweenType.easeInQuad);
    }
    
    
}
