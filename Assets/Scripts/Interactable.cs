using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Dialogue _dialogue;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(_dialogue);
    }

    public void ShowNextDialogue()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}