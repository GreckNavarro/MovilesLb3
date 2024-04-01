using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float velocidadRotacion = 50f;
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }
    void Update()
    {
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);
    }




}
