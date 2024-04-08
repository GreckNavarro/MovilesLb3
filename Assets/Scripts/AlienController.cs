using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : Enemy
{

   
    [SerializeField] float lifeTime;
    [SerializeField] float currentTime;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int velocidad;


    void Start()
    {

    }
    public override void InitVariables()
    {
        Vector3 spawnPosition = new Vector3(7.0f, Random.Range(-4f, 4f), 0);
        transform.position = spawnPosition;
        velocidad = GameStats.Instance.GetSO().SpeedX;
        rb.velocity = Vector2.left * velocidad;
        currentTime = lifeTime;

    }

    
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            ReturnPool();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ReturnPool();

        }
    }
    private void ReturnPool()
    {
        rb.velocity = Vector2.zero;
        ObjectPoolStatic.SetObject(this.gameObject);

    }

}
