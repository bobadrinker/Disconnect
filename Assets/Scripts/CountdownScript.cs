using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownScript : MonoBehaviour
{
    public Slider slider;
    public float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    private void Update()
    {
        if(timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            slider.value = timer;
        }

        else if(timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            slider.value = 0.0f;
            timer = 0.0f;
            GameOver();
        }
    }

    public void Reset()
    {
        timer = mainTimer;
        canCount = true;
        doOnce = false;
    }

    void GameOver()
    {
        SceneManager.LoadScene("KitchenAfter");
    }
}
