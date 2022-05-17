using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameStarter : MonoBehaviour
{
    public GameObject icon;
    bool inRange;

    private void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("DragAndDrop");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            icon.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            icon.SetActive(false);
            inRange = false;
        }
    }
}
 