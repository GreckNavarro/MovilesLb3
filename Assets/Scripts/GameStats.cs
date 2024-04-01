using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance { get; private set; }
    [SerializeField] private StatsScriptableObjects currentPlayer;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public StatsScriptableObjects GetSO()
    {
        return currentPlayer;
    }
}
