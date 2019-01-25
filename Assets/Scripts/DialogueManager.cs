using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager: MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    private Queue<string> _dialogues;

    void Start()
    {
        _dialogues = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        _dialogues.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            _dialogues.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(_dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _dialogues.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char c in sentence.ToCharArray())
        {
            dialogueText.text += c;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        nameText.text = "";
        dialogueText.text = "";
    }
}
