using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogueActive;
    public bool dismissedThisFrame;

    public string[] dialogLines;
    public int currentLine;
    public float typingSpeed;

    private PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueActive && Input.GetKeyUp(KeyCode.Space))
        {
            currentLine++;
        }

        if(currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogueActive = false;

            dismissedThisFrame = true;

            currentLine = 0;
            thePlayer.canMove = true;
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogLines[currentLine]));
    }

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        //StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogue));
    }

    public void ShowDialogue()
    {
        if (!dismissedThisFrame)
        {

            dialogueActive = true;
            dBox.SetActive(true);
            thePlayer.canMove = false;
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        dText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
