using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEfect : MonoBehaviour
{
    [SerializeField] private float velocityParallax;

    private void Start()
    {
        velocityParallax = GameStats.Instance.GetSO().VelocityParallax;
    }
    void Update()
    {
        transform.position = new Vector2(transform.position.x - velocityParallax * Time.deltaTime, transform.position.y);
        if(transform.position.x <= -21.50f)
        {
            transform.position = new Vector2(21.88f, transform.position.y);
        }
    }
}
