using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using TMPro;

[Serializable]
struct Dialogue
{
    public string texte;
    public UnityEvent toTrigger;
}

public class Scr_DialogueDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private Dialogue[] dialogues;

    private int index;

    [SerializeField] private float typingSpeed;

    private IEnumerator typeTextCouroutine;
    

    private void Start()
    {
        textDisplay.text = "";
        typeTextCouroutine = TypeText();

        StartCoroutine(typeTextCouroutine);
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
        StopAllCoroutines();

        if (index < dialogues.Length - 1)
        {
            print("Next Phrase");
            index++;
            textDisplay.text = "";
            if (dialogues[index].toTrigger != null)
            {
                dialogues[index].toTrigger.Invoke();
            }
            
            StartCoroutine(TypeText());
        }
    }
}