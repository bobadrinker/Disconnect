using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MinigameManagaer : MonoBehaviour
{
    public List<GameObject> symbols;
    GameObject symbol;
    public List<GameObject> foods;
    public Bowl bowl;
    public GameObject cross;
    public GameObject TimerController;
    public CountdownScript countdownScript;

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
            GameObject food = bowl.food.gameObject;
            int index = symbols.IndexOf(symbol);
            int index1 = foods.IndexOf(food);
            if (index == index1)
            {
                foods.Remove(food);
                Destroy(food.gameObject);
                symbol.SetActive(false);
                symbols.Remove(symbol);
                TimerController.SetActive(true);
                countdownScript.Reset();
                --countdownScript.mainTimer;
                NewFood();
            }
            else
            {
                DragAndDrop dragAndDrop = food.GetComponent<DragAndDrop>();
                dragAndDrop.selectable = true;
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
        int index = UnityEngine.Random.Range(0, symbols.Count);
        if (symbols.Count == 0)
        {
            index = 0;
        }

        symbols[index].SetActive(true);
        symbol = symbols[index];
    }
}
