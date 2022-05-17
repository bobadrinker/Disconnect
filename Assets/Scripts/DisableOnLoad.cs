using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableOnLoad : MonoBehaviour
{
    public GameObject[] gameObjects;
    private static bool gameObjectExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!gameObjectExists)
        {
            gameObjectExists = true;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MainMenu" || scene.name == "DragAndDrop")
        {
            foreach (GameObject game in gameObjects)
            {
                game.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject game in gameObjects)
            {
                game.SetActive(true);
            }
        }
    }
}
