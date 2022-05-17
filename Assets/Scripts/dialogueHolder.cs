using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueHolder : MonoBehaviour
{
    public string dialogue;
    private DialogueManager dMAn;

    public string[] dialogueLines;
    bool inRange;
    public GameObject image;
    public GameObject icon;

    // Start is called before the first frame update
    void Start()
    {
        dMAn = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyUp(KeyCode.Space))
        {
            if (!dMAn.dialogueActive && !dMAn.dismissedThisFrame)
            {
                dMAn.image = image;
                dMAn.dialogLines = dialogueLines;
                dMAn.currentLine = 0;
                dMAn.ShowDialogue();
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            inRange = true;
            icon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inRange = false;
            dMAn.dismissedThisFrame = false;
            icon.SetActive(false);
        }
    }
}
