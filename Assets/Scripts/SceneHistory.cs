using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHistory : MonoBehaviour
{
    public List<string> sceneHistory = new List<string>();

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
