using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{

    [SerializeField] GameObject canvas;


    private void OnEnable()
    {
        SceneGlobalManager.StartPlay += DesactiveCanvas;
        SceneGlobalManager.returnMenu += ActiveCanvas;
    }
    private void OnDisable()
    {
        SceneGlobalManager.StartPlay -= DesactiveCanvas;
        SceneGlobalManager.returnMenu -= ActiveCanvas;
    }

    public void DesactiveCanvas()
    {
        canvas.SetActive(false);
    }
    public void ActiveCanvas()
    {
        canvas.SetActive(true);
    }

    public void ClickButton()
    {
        SceneGlobalManager.Instance.LoadScene("CharacterSelection");
    }
    public void ExitGame()
    {
        SceneGlobalManager.Instance.ExitGame();
    }
}
