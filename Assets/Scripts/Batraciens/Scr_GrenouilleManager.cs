using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GrenouilleManager : Scr_P_Batracien,IRemoveFromTower
{
    private Scr_FeedbacksManager fbManager;

    private void Awake()
    {
        fbManager = FindObjectOfType<Scr_FeedbacksManager>();
    }

    public bool RemoveFromTower(ActionTypes actionTypes)
    {
        switch (actionTypes)
        {
            case ActionTypes.Click:
                Debug.Log("Remove");
                fbManager.FrogCollect(gameObject);
                StartCoroutine(CheckToDestroy());
                return true;
            case ActionTypes.SwipeLeft:
                return false;
            case ActionTypes.SwipeRight:
                return false;
            case ActionTypes.Unknow:
                return false;
        }

        return false;
    }

    //Pas très propre, trouver un moyen d'amléiorer (event quand le tweening à finit?)
    IEnumerator CheckToDestroy()
    {
        for (;;)
        {
            if (transform.localScale == Vector3.zero)
            {
                Destroy(gameObject);
                RemovedFromTower();
            }
            yield return new WaitForFixedUpdate();
        }
    }

    void Finish()
    {
        /*
        int id = //La fonction easing + .id à la fin
        LTDescr d = LeanTween.descr( id );

        if(d!=null){ // if the tween has already finished it will return null
            // change some parameters
            d.setOnComplete( Fonction à appeler );
        }
        */
    }
}
