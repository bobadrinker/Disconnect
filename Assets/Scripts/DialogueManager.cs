using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogueActive;

    bool dismissedThisFrame;
    int currentLine;
    PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            dBox.SetActive(false);
            dialogueActive = false;
            dismissedThisFrame = true;

            currentLine = 0;
            thePlayer.canMove = true;

        }
    }

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);

        dText.text = dialogue;

        thePlayer.canMove = false;
    }

    private void LateUpdate()
    {
        dismissedThisFrame = false;

    }
}
