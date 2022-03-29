using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;

    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void KillPlayer (PlayerHealthManager player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }
}
