using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    [SerializeField] float currentTime;
    [SerializeField] ObjectPoolDinamic objectPool;
    private Vector3 startPosition;


    public void SetObjectPool(ObjectPoolDinamic obj)
    {
        objectPool = obj;
    }

    public void InitVariables(Transform disparador)
    {
        currentTime = lifeTime;
        startPosition = disparador.position;
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            objectPool.SetObject(this.gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectPool.SetObject(this.gameObject);
    }

}
