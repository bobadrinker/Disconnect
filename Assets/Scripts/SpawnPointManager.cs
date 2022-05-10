using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    private SceneHistory history;
    public GameObject[] spawnPoints;

    private void Awake()
    {
        if (history == null)
        {
            history = GameObject.FindGameObjectWithTag("SceneHistory").GetComponent<SceneHistory>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (history.sceneHistory[history.sceneHistory.Count - 1] == "Bathroom")
        {
            spawnPoints[1].SetActive(true);
        }
        else if (history.sceneHistory[history.sceneHistory.Count - 1] == "Kitchen")
        {
            spawnPoints[2].SetActive(true);
        }
        else if (history.sceneHistory[history.sceneHistory.Count - 1] == "Attic")
        {
            spawnPoints[3].SetActive(true);
        }
        else
        {
            spawnPoints[0].SetActive(true);
            Debug.Log(history.sceneHistory[history.sceneHistory.Count - 1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
