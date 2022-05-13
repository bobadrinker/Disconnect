using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector3 playerPos = FindObjectOfType<PlayerController>().playerItemDrop.transform.position;
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
