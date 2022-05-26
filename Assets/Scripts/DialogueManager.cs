using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject text;

    public Text name;
    public Text dText;
    public GameObject spaceText;
    public GameObject image;
    public Image dBox;
    public Animator anim;

    public bool dialogueActive;
    public bool dismissedThisFrame;

    public string[] dialogLines;
    public string[] names;
    public Image[] dBoxImages;

    public int currentLine;
    public float typingSpeed;

    private PlayerController thePlayer;
    public GameObject minimap;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        //menuAppear = FindObjectOfType<MenuAppearScript>();

        //dBoxImages = GetComponentsInChildren<Image>();
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
            //dBoxImages.GetComponent<Image>().enabled = false;
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
        name.text = names[currentLine];
        if (names[currentLine] == "Mum")
        {
            for (int i = 0; i < dBoxImages.Length; i++)
            {
                if (i == 0)
                {
                    dBoxImages[i].enabled = true;
                }
                else
                {
                    dBoxImages[i].enabled = false;
                }
            }
        }
        else if (names[currentLine] == "Player")
        {
            for (int i = 0; i < dBoxImages.Length; i++)
            {
                if (i == 1)
                {
                    dBoxImages[i].enabled = true;
                }
                else
                {
                    dBoxImages[i].enabled = false;
                }
            }
        }
        else if (names[currentLine] == "Player confused")
        {
            for (int i = 0; i < dBoxImages.Length; i++)
            {
                if (i == 2)
                {
                    dBoxImages[i].enabled = true;
                }
                else
                {
                    dBoxImages[i].enabled = false;
                }
            }
        }
        else if (names[currentLine] == "Player worried")
        {
            for (int i = 0; i < dBoxImages.Length; i++)
            {
                if (i == 3)
                {
                    dBoxImages[i].enabled = true;
                }
                else
                {
                    dBoxImages[i].enabled = false;
                }
            }
        }
        else if (names[currentLine] == "Player sad")
        {
            for (int i = 0; i < dBoxImages.Length; i++)
            {
                if (i == 4)
                {
                    dBoxImages[i].enabled = true;
                }
                else
                {
                    dBoxImages[i].enabled = false;
                }
            }
        }

        foreach (char letter in sentence.ToCharArray())
        {
            dText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void TurnOffDBox()
    {
        dBox.enabled = false;
        name.gameObject.SetActive(false);
        text.SetActive(false);
        spaceText.SetActive(false);
        for (int i = 0; i < dBoxImages.Length; i++)
        {
            dBoxImages[i].enabled = false;
        }
        minimap.SetActive(true);
    }

    void TurnOnDBox()
    {
        //menuAppear.isShowing = false;
        dBox.enabled = true;
        text.SetActive(true);
        name.gameObject.SetActive(true);
        spaceText.SetActive(true);
        for (int i = 0; i < dBoxImages.Length; i++)
        {
            dBoxImages[i].enabled = true;
        }
        minimap.SetActive(false);
    }
}
