using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum ActionTypes{
    Click,
    SwipeLeft,
    SwipeRight,
    Unknow,
}

public interface IRemoveFromTower
{
    /// <summary>
    /// Retourne si on à réussit à enlever le batracien de la tour
    /// </summary>
    /// <param name="actionType"></param>
    /// <returns></returns>
    bool RemoveFromTower(ActionTypes actionType);
}
