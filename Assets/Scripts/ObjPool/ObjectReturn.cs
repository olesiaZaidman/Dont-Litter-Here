using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReturn : MonoBehaviour
    //, IPooledObject
{
    ObjectPoolDictionary objectPooler;

    void Start()
    {
        objectPooler = ObjectPoolDictionary.Instance;      
    }

    void OnDisable()
    {
        if (objectPooler != null)
        {
            objectPooler.ReturnDeactivatedObjectToPoolDictionary(this.gameObject); 
        }
    }
}
