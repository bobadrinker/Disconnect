using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
  
 public class MenuAppearScript : MonoBehaviour {
    
    public GameObject menu; // Assign in inspector
    public bool isShowing = true;
    bool shown = true;
    public GameObject tabForInventory;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update() {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "DragAndDrop" || scene.name != "MainMenu")
        {
            if (Input.GetKeyDown("tab"))
            {
                shown = false;
                isShowing = !isShowing;
                menu.SetActive(isShowing);
            }
        }
        else if (scene.name == "DragAndDrop" || scene.name == "MainMenu") {
            menu.SetActive(false);
        }

        if (!shown)
        {
            tabForInventory.SetActive(false);
        }
     }
 }