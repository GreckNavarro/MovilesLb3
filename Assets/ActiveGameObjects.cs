using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGameObjects : MonoBehaviour
{
    public GameObject canvas;

    private void OnEnable()
    {
        SceneGlobalManager.EndGame += ActiveObjects;

    }
    private void OnDisable()
    {
        SceneGlobalManager.EndGame -= ActiveObjects;
    }

    public void ActiveObjects()
    {
        canvas.SetActive(true);    
    }
    
}
