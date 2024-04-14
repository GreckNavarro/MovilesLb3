using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{

    [SerializeField] GameObject canvas;
    [SerializeField] bool active;


    private void OnEnable()
    {
        SceneGlobalManager.StartPlay += SetCanvas;
        SceneGlobalManager.returnMenu += ActiveCanvas;
    }
    private void OnDisable()
    {
        SceneGlobalManager.StartPlay -= SetCanvas;
        SceneGlobalManager.returnMenu -= ActiveCanvas;
    }

    private void Start()
    {
        active = true;
    }
    public void SetCanvas()
    {
        canvas.SetActive(false);
    }
    public void ActiveCanvas()
    {
        canvas.SetActive(true);
    }

    public void ClickButton()
    {
        Debug.Log("GoToCS");
        SceneGlobalManager.Instance.LoadScene("CharacterSelection");
    }
    public void ExitGame()
    {
        SceneGlobalManager.Instance.ExitGame();
    }
}
