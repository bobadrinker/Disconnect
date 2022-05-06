using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public string levelToLoad;

    private List<string> sceneHistory = new List<string>();

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
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
        sceneHistory.Add(levelToLoad);
        SceneManager.LoadScene(levelToLoad);
        Debug.Log(levelToLoad);
    }
}
