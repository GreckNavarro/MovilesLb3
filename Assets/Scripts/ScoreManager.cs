using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] float currentScore;
    [SerializeField] float scoreIncreaseRate;
    [SerializeField] Result resultSO;
    [SerializeField] Text scoreText;
    [SerializeField] Text currentHealth;
    private bool died;

    void Start()
    {
        died = false;
        currentScore = 0;
        scoreIncreaseRate = GameStats.Instance.GetSO().ScoreIncrement;
        currentHealth.text = GameStats.Instance.GetSO().Health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore(died);
    }
    public void UpdateScore(bool active)
    {
        if (active == false)
        {
            currentScore += Time.deltaTime * scoreIncreaseRate;
            scoreText.text = Mathf.FloorToInt(currentScore).ToString(); 
        }
            
        else
            ChangeScore();
    }

    public void ChangeTextHealth(int health)
    {
        currentHealth.text = health.ToString();
    }
    void ChangeScore()
    {
        resultSO.ChangeCurrentScore(currentScore);
        SceneManager.LoadScene("Results");
    }
}
