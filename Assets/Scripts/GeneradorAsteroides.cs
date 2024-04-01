using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorAsteroides : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] int velocidad;
    [SerializeField] float timeInterval;

    void Start()
    {
        velocidad = GameStats.Instance.GetSO().SpeedX;
        timeInterval = GameStats.Instance.GetSO().TimeInterval;
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(7.0f, Random.Range(-4f, 4f), 0);
            GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            Rigidbody2D rb = newAsteroid.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.left * velocidad;

            yield return new WaitForSeconds(timeInterval);
        }
    }
}
