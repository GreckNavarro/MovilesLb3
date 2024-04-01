using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionCharacter : MonoBehaviour
{
    public StatsScriptableObjects currentPlayer;
    public StatsScriptableObjects[] statsPlayer;



    private void Start()
    {
        Debug.Log("Inicio");
    }


    public void ChangePlayer1()
    {
        currentPlayer.ChangeStats(statsPlayer[0]);
    }

    public void ChangePlayer2()
    {
        currentPlayer.ChangeStats(statsPlayer[1]);
    }

    public void ChangePlayer3()
    {
        currentPlayer.ChangeStats(statsPlayer[2]);
    }


    public void GoToMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }



    private void Update()
    {
        
    }
}
