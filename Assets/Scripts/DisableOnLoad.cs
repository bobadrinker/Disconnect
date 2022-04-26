using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableOnLoad : MonoBehaviour
{
    public string[] levels;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        foreach (string level in levels)
        {
            if (level == scene.name)
            {
                gameObject.SetActive(false);
                //Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                gameObject.SetActive(true);
                //Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
