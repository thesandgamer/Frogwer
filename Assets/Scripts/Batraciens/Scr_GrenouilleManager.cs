using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GrenouilleManager : Scr_P_Batracien,IRemoveFromTower
{
    [SerializeField]private SpriteRenderer renderer;
    [SerializeField]private SpriteRenderer rendererLeg;
    [SerializeField]private Sprite freeSprite;
    [SerializeField]private Sprite freeSpriteLeg;

    public bool RemoveFromTower(ActionTypes actionTypes)
    {
        switch (actionTypes)
        {
            case ActionTypes.Click:
                Debug.Log("Remove");
                FrogRemoved();
                //StartCoroutine(CheckToDestroy());
                RemovedFromTower();

                return true;
            case ActionTypes.SwipeLeft:
                fbManager.NotGood(gameObject);
                return false;
            case ActionTypes.SwipeRight:
                fbManager.NotGood(gameObject);
                return false;
            case ActionTypes.Unknow:
                return false;
        }

        return false;
    }
    
    public void FrogRemoved()
    {
        renderer.sprite = freeSprite;
        rendererLeg.sprite = freeSpriteLeg;
        fbManager.FrogCollect(gameObject);
    }
    
    //Pas très propre, trouver un moyen d'amléiorer (event quand le tweening à finit?)
    IEnumerator CheckToDestroy()
    {
        
        for (;;)
        {
            if (transform.localScale == Vector3.zero)
            {
                Destroy(gameObject);
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
