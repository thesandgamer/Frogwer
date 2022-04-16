using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelX", menuName = "Level data", order = 0)]

public class BatracienTower : ScriptableObject
{
    public List<BatracienType> batraciensForConstruction;
    public TimeFormat time;

}
