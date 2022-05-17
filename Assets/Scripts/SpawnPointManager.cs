using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    private SceneHistory history;
    public GameObject[] spawnPoints;

    private void Awake()
    {
        /*if (history == null)
        {
            history = GameObject.FindGameObjectWithTag("SceneHistory").GetComponent<SceneHistory>();
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        int num = GameManager.gm.GetSceneNumber();
        if (num == 1)
        {
            spawnPoints[1].SetActive(true);
        }
        else if (num == 2)
        {
            spawnPoints[2].SetActive(true);
        }
        else if (num == 3)
        {
            spawnPoints[3].SetActive(true);
        }
        else
        {
            spawnPoints[0].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
