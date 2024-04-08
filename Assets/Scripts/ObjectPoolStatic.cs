using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolStatic : MonoBehaviour
{
    public List<GameObject> objectPool;
    public GameObject[] objects;

    public int maxQuantity;

    private void Start()
    {
        
    }
    public void InstantiateObjects()
    {
        GameObject tmp;
        for(int i = 0; i < maxQuantity; ++i)
        {
            int randomindex = Random.Range(0, objects.Length);
            tmp = Instantiate(objects[randomindex], transform.position, transform.rotation);
            tmp.GetComponent<Enemy>().SetObjectPool(this);
            objectPool.Add(tmp);
            tmp.transform.SetParent(this.transform);
            tmp.SetActive(false);
        }
       

    }
    public void GetObject()
    {
        if(objectPool.Count > 0)
        {
            GameObject tmp = objectPool[0];
            objectPool.Remove(tmp);
            tmp.SetActive(true);
            tmp.GetComponent<Enemy>().InitVariables();
            
        }
        else
        {
            print("No hay más objetos en el pool");
        }
    }
    public void SetObject(GameObject obj)
    {
        objectPool.Add(obj);
        obj.SetActive(false);
    }
}
