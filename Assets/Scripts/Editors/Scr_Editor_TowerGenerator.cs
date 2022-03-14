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

        if (GUILayout.Button("CreateTower"))
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

        if (GUILayout.Button("Clean Tower"))
        {
            towerManager.CleanTower();

        }
        



    }
}
#endif
// Runtime code here