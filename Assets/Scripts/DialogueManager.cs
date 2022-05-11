using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject text;
    public Text dText;
    public GameObject image;
    public Animator anim;

    public bool dialogueActive;
    public bool dismissedThisFrame;

    public string[] dialogLines;
    public int currentLine;
    public float typingSpeed;

    private PlayerController thePlayer;

    Image[] dBoxImages;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

        dBoxImages = GetComponentsInChildren<Image>();
        TurnOffDBox();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueActive && Input.GetKeyUp(KeyCode.Space))
        {
            currentLine++;
            dText.text = "";
            StopAllCoroutines();
            StartCoroutine(TypeSentence(dialogLines[currentLine]));
        }

        if(currentLine >= dialogLines.Length)
        {
            anim.SetBool("inDialogue", false);
            image.GetComponent<Image>().enabled = false;
            //dBox.SetActive(false);
            TurnOffDBox();

            dialogueActive = false;

            dismissedThisFrame = true;

            currentLine = 0;
            thePlayer.canMove = true;
        }
    }

    public void ShowBox(string dialogue)
    {
        anim.SetBool("inDialogue", true);
        /*image.GetComponent<Image>().enabled = true;
        dialogueActive = true;
        dBox.SetActive(true);*/
        dialogueActive = true;
        TurnOnDBox();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogue));
    }

    public void ShowDialogue()
    {
        if (!dismissedThisFrame)
        {
            if (image != null)
            {
                anim.SetBool("inDialogue", true);
                /*image.GetComponent<Image>().enabled = true;
                dialogueActive = true;
                dBox.SetActive(true);*/;
                dialogueActive = true;
                TurnOnDBox();
                thePlayer.canMove = false;
                StartCoroutine(TypeSentence(dialogLines[currentLine]));
            } else
            {
                image = GameObject.Find("Image");
                ShowDialogue();
            }
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

    void TurnOffDBox()
    {
        text.SetActive(false);
        for (int i = 0; i < dBoxImages.Length; i++)
        {
            dBoxImages[i].enabled = false;
        }
    }

    void TurnOnDBox()
    {
        text.SetActive(true);
        for (int i = 0; i < dBoxImages.Length; i++)
        {
            dBoxImages[i].enabled = true;
        }
    }
}
