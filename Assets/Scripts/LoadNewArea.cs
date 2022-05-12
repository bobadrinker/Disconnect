using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public string levelToLoad;

    private SceneHistory history;

    public PlayerController player;

    private void Start()
    {
        if (history == null)
        {
            history = GameObject.FindGameObjectWithTag("SceneHistory").GetComponent<SceneHistory>();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            player.lastScene = GameManager.gm.GetSceneNumber();
            StartCoroutine(LoadLevel(levelToLoad));
        }
    }

    IEnumerator LoadLevel(string levelToLoad)
    {
        transition.SetTrigger("Start");
        //GameManager.gm.GetSceneNumber();

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelToLoad);
        Debug.Log(levelToLoad);
    }
}
