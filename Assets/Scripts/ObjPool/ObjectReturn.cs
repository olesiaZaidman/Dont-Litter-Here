using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReturn : MonoBehaviour
{
    ObjectPoolDictionary objectPooler;

    void Start()
    {
        objectPooler = ObjectPoolDictionary.Instance;
    }

    void OnDisable()
    {
       // transform.position = new Vector3(0,0,0);
        if (objectPooler != null)
        {
            objectPooler.ReturnDeactivatedObjectToPoolDictionary(this.gameObject);
        }
    }
}
