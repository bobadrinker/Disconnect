using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    private SceneHistory history;

    // Start is called before the first frame update
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (gm != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public Transform playerPrefab;
    public GameObject spawnPoint;
    public int spawnDelay = 2;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        /*Debug.Log("ahbfhabfg");

        if (spawnPoint == null)
        {
            spawnPoint = FindObjectOfType<PlayerStartPoint>().gameObject;
        }*/
    }

    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);
        Transform test = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    public void KillPlayer (PlayerHealthManager player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }

    public int GetSceneNumber()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "house_inside")
        {
            return 0;
        }
        if (scene.name == "Bathroom")
        {
            return 1;
        }
        else if (scene.name == "Kitchen" || scene.name == "Kitchen After")
        {
            return 2;
        }
        else if (scene.name == "Attic")
        {
            return 3;
        }

        return -1;
    }
}
