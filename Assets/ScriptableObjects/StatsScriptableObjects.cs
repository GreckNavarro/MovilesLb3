using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/StatsPlayer", order = 1)]

public class StatsScriptableObjects : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private int speedY;
    [SerializeField] private int speedX;
    [SerializeField] private float timeInterval;
    [SerializeField] private Sprite shipSprite;
    [SerializeField] private float velocityParallax;
    [SerializeField] private float scoreIncrement;



    public int Health => health;
    public int SpeedY => speedY;
    public int SpeedX => speedX;
    public float TimeInterval => timeInterval;
    public Sprite ShipSprite => shipSprite;
    public float VelocityParallax => velocityParallax;
    public float ScoreIncrement => scoreIncrement;
    public void ChangeStats(StatsScriptableObjects so)
    {
        health = so.health;
        speedY = so.speedY;
        speedX = so.speedX;
        timeInterval = so.timeInterval;
        shipSprite = so.shipSprite;
        velocityParallax = so.velocityParallax;
        scoreIncrement = so.scoreIncrement;
    }

}
