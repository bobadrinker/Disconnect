using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    public GameObject food;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        food = collision.gameObject;
    }
}
