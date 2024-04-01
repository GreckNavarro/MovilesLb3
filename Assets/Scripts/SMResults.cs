using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SMResults : MonoBehaviour
{
    [SerializeField] Result resultSO;
    [SerializeField] Text currentScore;
    [SerializeField] Text highScore;
    void Start()
    {
        currentScore.text = resultSO.CurrentScore.ToString();
        highScore.text = resultSO.HighScore.ToString();

    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("CharacterSelection");
    }


}
