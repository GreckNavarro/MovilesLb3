using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorAsteroides : MonoBehaviour
{

    [SerializeField] float timeInterval;
    [SerializeField] ObjectPoolStatic objectPoolEnemy;

    void Start()
    {
        timeInterval = GameStats.Instance.GetSO().TimeInterval;
        objectPoolEnemy.InstantiateObjects();
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            objectPoolEnemy.GetObject();
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
