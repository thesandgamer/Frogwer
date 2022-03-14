using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ToadManager : Scr_P_Batracien,IRemoveFromTower
{
    private float moveSpeed;
    private VariablesPropretys variables;

    [SerializeField]public BatracienType type = BatracienType.Toad;

    private void OnEnable()
    {
        variables = Resources.Load("CurrentData") as VariablesPropretys;
        moveSpeed = variables.toadDeplacementSpeed;
    }

    public bool RemoveFromTower(ActionTypes actionTypes)
    {
        switch (actionTypes)
        {
            case ActionTypes.Click:
                return false;
            case ActionTypes.SwipeLeft:
                if (type == BatracienType.ToadShieldLeft || type == BatracienType.Toad)
                {
                    FindObjectOfType<Scr_FeedbacksManager>().ToadDefetead(gameObject,true);
                    StartCoroutine(MoveToad(new Vector3(-1, 0, 0)));
                    return true;
                }

                if (type == BatracienType.ToadShieldRight)
                {
                    FindObjectOfType<Scr_FeedbacksManager>().ToadBlock(gameObject,false);
                }

                return false;

            case ActionTypes.SwipeRight:
                if (type == BatracienType.ToadShieldRight || type == BatracienType.Toad)
                {
                    FindObjectOfType<Scr_FeedbacksManager>().ToadDefetead(gameObject, false);
                    StartCoroutine(MoveToad(new Vector3(1,0,0)));
                    return true;
                }
                if (type == BatracienType.ToadShieldLeft)
                {
                    FindObjectOfType<Scr_FeedbacksManager>().ToadBlock(gameObject,false);
                }
                return false;
            
            case ActionTypes.Unknow:
                return false;
        }
        return false;
    }
    
    IEnumerator MoveToad(Vector3 direction)
    {
        StartCoroutine(WaitToTowerFall());
        float startTime = Time.time;
        while (Time.time < startTime + 2)
        {
            transform.Translate(new Vector3(moveSpeed*Time.deltaTime*direction.x,moveSpeed*Time.deltaTime*direction.y,moveSpeed*Time.deltaTime*direction.z));
            yield return null;

        }
        Destroy(gameObject);

    }

    IEnumerator WaitToTowerFall()
    {
        yield return new WaitForSeconds(0.2f);
        RemovedFromTower();

    }
    
    
}
