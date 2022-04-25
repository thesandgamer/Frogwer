using System;
using System.Collections;
using UnityEngine;
using TMPro;

[Serializable]
struct Dialogue
{
    public string texte;
}

public class Scr_DialogueDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private Dialogue[] dialogues;

    private int index;

    [SerializeField] private float typingSpeed;
    

    private void Start()
    {
        textDisplay.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in dialogues[index].texte.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        print("Next Phrase");

        if (index < dialogues.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeText());
        }
    }
}