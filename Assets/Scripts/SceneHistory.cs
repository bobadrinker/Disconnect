using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHistory : MonoBehaviour
{
    public int lastScene = -1;
    public List<string> sceneHistory = new List<string>();

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
