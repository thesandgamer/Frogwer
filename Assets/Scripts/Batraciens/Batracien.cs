using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum BatracienType
{
    Frog,Toad, ToadShieldLeft,ToadShieldRight
}

[Serializable]
public class Batracien
{
    public BatracienType batracien;
    //public GameObject batracienPrefab;
}
