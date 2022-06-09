using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}

    AudioSource audioSource;

    public AudioClip buttonPress;
    public GameObject backgroundMusic;

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this);
            Destroy(backgroundMusic);
        } else {
            Instance = this;
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(backgroundMusic);
        }
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonPress() {
        audioSource.PlayOneShot(buttonPress, 1f);
    }

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "house_inside")
        {
            Destroy(backgroundMusic);
        }
    }
}
