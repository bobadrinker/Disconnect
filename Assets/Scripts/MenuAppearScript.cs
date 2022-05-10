 using UnityEngine;
 using System.Collections;
  
 public class MenuAppearScript : MonoBehaviour {
    
    public GameObject menu; // Assign in inspector
    private bool isShowing;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update() {
         if (Input.GetKeyDown("tab")) {
             isShowing = !isShowing;
             menu.SetActive(isShowing);
         }
     }
 }