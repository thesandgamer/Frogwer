using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GrenouilleManager : Scr_P_Batracien,IRemoveFromTower
{
    public bool RemoveFromTower(ActionTypes actionTypes)
    {
        switch (actionTypes)
        {
            case ActionTypes.Click:
                Debug.Log("Remove");
                FindObjectOfType<Scr_FeedbacksManager>().FrogCollect(gameObject);
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
            yield return null;
        }
    }
}
