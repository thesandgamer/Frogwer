using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Batraciens Propretys", order = 1)]
public class VariablesPropretys : ScriptableObject
{
    [Header("   Tower")] 
    public float fallingTime = 0.2f;
    
    [Header("   Toad")]
    public float toadDeplacementSpeed = 8.0f;
    
    [Header("   Frog")]
    public float frogDisaperingTime = 0.2f;
    

}
