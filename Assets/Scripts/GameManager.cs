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
        if (gm != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public Transform[] spawnPoints;
    public int spawnDelay = 2;

    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "Hallway")
        {
            Transform test = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            if (history.sceneHistory[history.sceneHistory.Count - 1] == "Bathroom")
            {
                Transform test = Instantiate(playerPrefab, spawnPoints[1].position, spawnPoints[1].rotation);
                Debug.Log(history.sceneHistory[history.sceneHistory.Count - 1]);
            }
            else if (history.sceneHistory[history.sceneHistory.Count - 1] == "Kitchen")
            {
                Transform test = Instantiate(playerPrefab, spawnPoints[2].position, spawnPoints[2].rotation);
                Debug.Log(history.sceneHistory[history.sceneHistory.Count - 1]);
            }
            else if (history.sceneHistory[history.sceneHistory.Count - 1] == "Attic")
            {
                Transform test = Instantiate(playerPrefab, spawnPoints[3].position, spawnPoints[3].rotation);
                Debug.Log(history.sceneHistory[history.sceneHistory.Count - 1]);
            }
            else
            {
                Transform test = Instantiate(playerPrefab, spawnPoints[0].position, spawnPoints[0].rotation);
            }
        }
    }

    public void KillPlayer (PlayerHealthManager player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }
}
