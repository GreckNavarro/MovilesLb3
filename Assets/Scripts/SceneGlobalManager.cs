using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneGlobalManager : MonoBehaviourSingletonPersistent<SceneGlobalManager>
{
    public static Action StartPlay;
    public static Action EndGame;
    public static Action returnMenu;

    public void StartMenu()
    {
    
        SceneManager.LoadScene("Menu");
    }

    

    

    public void LoadGame()
    {
        StartPlay?.Invoke();
        LoadScenesGame();
        SceneManager.UnloadSceneAsync("CharacterSelection");

    }


    public void GoMenu()
    {
       
        returnMenu?.Invoke();
        UnloadGame();
    }

    public void GoToSelectionCharacter()
    {
        SceneManager.LoadSceneAsync("CharacterSelection", LoadSceneMode.Additive);
        UnloadGame();

    }

    public void Reload()
    {
        UnloadGame();
        LoadScenesGame();

    }

    private void LoadScenesGame()
    {
        SceneManager.LoadSceneAsync("MainGame", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Results", LoadSceneMode.Additive);
    }
    private void UnloadGame()
    {
        SceneManager.UnloadSceneAsync("MainGame");
        SceneManager.UnloadSceneAsync("Results");
    }


    public void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }
    public void UnloadScene(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
