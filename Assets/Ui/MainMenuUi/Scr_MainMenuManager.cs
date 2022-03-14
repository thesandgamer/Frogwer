using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_MainMenuManager : MonoBehaviour
{

    public void GoToLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    
}
