using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_MainMenuManager : MonoBehaviour
{
    
    [SerializeField] public Animator transition;
    private float transitionTime = 1f;

    [SerializeField] private GameObject button;
    public void GoToLevel(string level)
    {
        FindObjectOfType<Scr_FeedbacksManager>().GetComponent<Scr_FeedbacksManager>().DePopUpUi(button);
        transition.SetTrigger("Start");
        //SceneManager.LoadScene(level);
    }
    
}
