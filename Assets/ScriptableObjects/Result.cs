using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Result", menuName = "ScriptableObjects/ResultScore", order = 3)]

public class Result : ScriptableObject
{
    [SerializeField] int currentscore;
    [SerializeField] int highScore;

    public int CurrentScore => currentscore;
    public int HighScore => highScore;


    public void ChangeCurrentScore(float score)
    {
        currentscore = Mathf.FloorToInt(score);
        if(highScore < currentscore)
        {
            highScore = currentscore;
        }
    }
}
