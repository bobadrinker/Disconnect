using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManagaer : MonoBehaviour
{
    public GameObject[] symbols;
    public GameObject[] foods;
    public GameObject bowl;

    bool entered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (foods.Length != 0)
        {
            int index = Random.Range(1, foods.Length);
            symbols[index].SetActive(true);
            if (entered)
            {
                symbols[index].SetActive(false);
                Destroy(foods[index]);
                entered = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        entered = true;
    }
}
