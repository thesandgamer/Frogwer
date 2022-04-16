using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{

    public string screenShotName;
    public string folderPath;
    private void OnEnable()
    {
        folderPath = Application.dataPath + "/screenshots/"; 

    }

    
    public void Shot()
    {
        if(!System.IO.Directory.Exists(folderPath)) System.IO.Directory.CreateDirectory(folderPath);

        ScreenCapture.CaptureScreenshot(folderPath + screenShotName + ".png");
        print("ScreenShot taken : " + folderPath + screenShotName + ".png" );
    }
}
