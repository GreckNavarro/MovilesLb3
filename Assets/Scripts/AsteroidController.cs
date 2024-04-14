using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : Enemy
{
    public float velocidadRotacion = 50f;
    [SerializeField] ObjectPoolStatic objectPool;
    [SerializeField] float lifeTime;
    [SerializeField] float currentTime;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int velocidad;

    float Health;

    void Start()
    {
       
    }
    public override void InitVariables()
    {
        Vector3 spawnPosition = new Vector3(13.0f, Random.Range(-4f, 4f), 0);
        transform.position = spawnPosition;
        velocidad = GameStats.Instance.GetSO().SpeedX;
        rb.velocity = Vector2.left * velocidad;
        Health = 3;
        currentTime = lifeTime;
       
    }


    void Update()
    {
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            ReturnPool();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ReturnPool();

        }
        if(collision.gameObject.tag == "Bullet")
        {
            Health -= 1;
            if(Health <= 0)
            {
                ScoreManager.IncrementPlayerScore?.Invoke();
                ReturnPool();
            }
        }
    }
    private void ReturnPool()
    {
        rb.velocity = Vector2.zero;
        ObjectPoolStatic.SetObject(this.gameObject);
        
    }





}
