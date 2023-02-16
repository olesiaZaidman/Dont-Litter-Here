using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReturn : MonoBehaviour, IPooledObject
{
    ObjectPoolDictionary objectPooler;
    [SerializeField] string objtag; //we set it in the Inspector
    //  public string ObjTag { get { return objtag; } set { objtag = value; } }
    void Start()
    {
        objectPooler = ObjectPoolDictionary.Instance;      
    }
    void SetObjTag()
    {
        objtag = this.gameObject.name;
        //Instead setting it in the Inspector, we set it when we  need it in GetObjTag()
    }

    public string GetObjTag()
    {
       // SetObjTag();

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
            objectPooler.ReturnDeactivatedObjectToPool(this.gameObject, objtag); //this.gameObject.tag
        }
    }
}
