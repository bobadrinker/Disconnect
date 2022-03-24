using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public string levelToLoad;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            StartCoroutine(LoadLevel(levelToLoad));
        }
    }

    IEnumerator LoadLevel(string levelToLoad)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelToLoad);
    }
}
