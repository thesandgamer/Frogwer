using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Runtime code here
#if UNITY_EDITOR
// Editor specific code here


[CustomEditor(typeof (Scr_TowerCreator))]
public class Scr_Editor_TowerGenerator : Editor
{
    public override void OnInspectorGUI()
    {
        Scr_TowerCreator towerManager = (Scr_TowerCreator)target;
        if (DrawDefaultInspector())
        {
            towerManager.CleanTower();
            towerManager.CreateTower();
        }
        GUILayout.Space(20);

        
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Spawn Tower"))
        {
            if (towerManager.batraciensInTower.Count <= 0)
            {
                towerManager.CreateTower();
            }
            else
            {
                Debug.LogWarning("Tower already exist");
                EditorUtility.DisplayDialog("Tower construction","Tower already exist"," Ok ");
            }
        }

        if (GUILayout.Button("Destroy Tower"))
        {
            towerManager.CleanTower();

        }
        GUILayout.EndHorizontal();

        
        if (GUILayout.Button("Set Level Data"))
        {
            towerManager.SetLevelData();

        }
    }


}
#endif
// Runtime code here