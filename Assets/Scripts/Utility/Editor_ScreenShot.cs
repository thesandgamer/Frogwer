using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR

[CustomEditor(typeof(ScreenShot))]
public class Editor_ScreenShot : Editor
{
    private ScreenShot script;

    private void OnEnable()
    {
        script = (ScreenShot) target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("ScreenShot"))
        { 
            //EditorUtility.DisplayDialog("Take ScreenShot","Take ScreenShot"," Yes ", "No");
           script.Shot();
            
        }

        // Draw default inspector after button...
        base.OnInspectorGUI();
    }
}
#endif