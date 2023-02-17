using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReturn : MonoBehaviour, IPooledObject
{
    ObjectPoolDictionary objectPooler;
    [SerializeField] string objtag; //we set it in SetObjTag()

    void Start()
    {
        objectPooler = ObjectPoolDictionary.Instance;      
    }
    public void SetObjTag()
    {
        objtag = this.gameObject.name;
    }

    public string GetObjTag()
    {
        if (string.IsNullOrEmpty(objtag))
        {
            Debug.LogWarning(this.gameObject + " requires the tag"); //LogWarning
            return null;
        }
          return objtag;
    }

    void OnDisable()
    {
        if (objectPooler != null)
        {
            objectPooler.ReturnDeactivatedObjectToPoolDictionary(this.gameObject, GetObjTag()); //this.gameObject.tag
        }
    }
}
