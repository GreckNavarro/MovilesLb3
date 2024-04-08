using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class ScoreManager : MonoBehaviour
{

    public static Action IncrementPlayerScore;

    [SerializeField] float currentScore;
    [SerializeField] float scoreIncreaseRate;
    [SerializeField] Result resultSO;
    [SerializeField] Text scoreText;
    [SerializeField] Text currentHealth;
    private bool died;

 

    private void OnEnable()
    {
        IncrementPlayerScore += IncrementScore;
    }
    private void OnDisable()
    {
        IncrementPlayerScore -= IncrementScore;
    }
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

    public void IncrementScore()
    {
        currentScore += 10;
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
