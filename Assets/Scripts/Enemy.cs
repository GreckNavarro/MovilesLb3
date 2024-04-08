using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected ObjectPoolStatic ObjectPoolStatic;
    public void SetObjectPool(ObjectPoolStatic newOP)
    {
        ObjectPoolStatic = newOP;
    }
    public virtual void InitVariables()
    {
      
    }
}
