using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Scr_TutorialManager : MonoBehaviour
{
    [SerializeField] private Scr_TowerManager towerManager;
    [SerializeField] private GameObject dialogueUi;
    [SerializeField] private GameObject buttonNext;
    [SerializeField] private InputsManager inputManager;
    
    [SerializeField] private Scr_DialogueDisplay dialogueDisplay;


    private void OnEnable()
    {
        //Scr_TowerManager.towerCleared += NextDialogue;
        Scr_CameraManager.cameraIntroFinished += ShowDialoguePanel;
        Scr_CameraManager.cameraIntroFinished += DeactivateInputs;
        Scr_TimerManager.ev_GoFinished += DeactivateInputs;
    }

    private void OnDisable()
    {
        //Scr_TowerManager.towerCleared -= NextDialogue;
        Scr_CameraManager.cameraIntroFinished -= ShowDialoguePanel;
        Scr_CameraManager.cameraIntroFinished -= DeactivateInputs;
        Scr_TimerManager.ev_GoFinished -= DeactivateInputs;


    }
    

    private int nb;
    private void Awake()
    {
        //towerManager.SetActive(false);
       nb  = towerManager.batraciensInTower.Count;
       DeactivateInputs();

    }
    private void Update()
    {
        if (towerManager.batraciensInTower.Count < nb)
        {
            nb = towerManager.batraciensInTower.Count;
            DeactivateInputs();
            dialogueDisplay.NextSentence();
        }
    }



    public void DoNothing()
    {
        print("Do nothing");
    }

    public void ActivateInputs()
    {
        inputManager.EnableInput();

    }
    
    public void DeactivateInputs()
    {
        inputManager.DisableInput();
    }

    public void ShowDialoguePanel()
    {
        /*
        dialogueUi.GetComponent<GraphicRaycaster>().enabled = true;
        //dialoguePanel.SetActive(true);
        inputManager.DisableInput();*/
        dialogueUi.SetActive(true);

    }
    public void HideDialoguePanel()
    {/*
        print("HIDE");
        dialogueUi.GetComponent<GraphicRaycaster>().enabled = false;
        inputManager.EnableInput();
        //dialoguePanel.SetActive(false);*/
        dialogueUi.SetActive(false);
        Destroy(dialogueUi);
        Destroy(this);

    }

    public void NextTower()
    {
        print("Next TOWER");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void NextDialogue()
    {
        ShowDialoguePanel();
        dialogueDisplay.NextSentence();
    }
    
    public void ShowButton()
    {
        buttonNext.SetActive(true);
    }
    public void HideButton()
    {
        buttonNext.SetActive(false);
    }
}
