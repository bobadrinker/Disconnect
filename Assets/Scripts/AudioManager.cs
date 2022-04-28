using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}

    AudioSource audioSource;

    public AudioClip buttonPress;

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonPress() {
        audioSource.PlayOneShot(buttonPress, 1f);
    }
}
