using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SMResults : MonoBehaviour
{
    [SerializeField] Result resultSO;
    [SerializeField] Text currentScore;
    [SerializeField] Text highScore;

    private void OnEnable()
    {
        SceneGlobalManager.EndGame += ChangeCurrentTexts;
      
    }
    private void OnDisable()
    {
        SceneGlobalManager.EndGame -= ChangeCurrentTexts;
       
    }

    private void ChangeCurrentTexts()
    {
        currentScore.text = resultSO.CurrentScore.ToString();
        highScore.text = resultSO.HighScore.ToString();
    }
    public void GoToMenu()
    {
        SceneGlobalManager.Instance.GoMenu();
    }
    public void GoSelection()
    {
        SceneGlobalManager.Instance.GoToSelectionCharacter();
    }
    public void RestarGame()
    {
        SceneGlobalManager.Instance.Reload();   
    }


}
