using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MinigameManagaer : MonoBehaviour
{
    public GameObject[] symbols;
    GameObject symbol;
    public List<string> foods = new List<string>();
    public Bowl bowl;
    public GameObject cross;

    bool correct = false;

    // Start is called before the first frame update
    void Start()
    {
        NewFood();
    }

    // Update is called once per frame
    void Update()
    {
        if (bowl.food != null)
        {
            string name = bowl.food.gameObject.ToString();
            int index = foods.IndexOf(name);
            if (index == Array.IndexOf(symbols, symbol))
            {
                NewFood();
            }
            else
            {
                cross.SetActive(true);
            }
        }
        else
        {
            cross.SetActive(false);
        }
    }

    void NewFood()
    {
        int index = UnityEngine.Random.Range(1, symbols.Length);

        symbols[index].SetActive(true);
        symbol = symbols[index];
    }
}
