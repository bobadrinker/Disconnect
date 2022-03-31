using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{

    public Button Play_Button;
    public Button Quit_Button;
    public Button Options_Button;
    public Button Menu_Scene;

    public void Play_Game()
    {

        SceneManager.LoadScene(1);
    }

    public void Options_Menu()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit_Game()
    {
        Debug.Log("Quitting rn bro");
        Application.Quit();
    }

    public void Main_Menu()
    {
        SceneManager.LoadScene(0);
    }
}
