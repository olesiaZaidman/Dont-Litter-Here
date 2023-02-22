using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageDestroyer : MonoBehaviour
{
    void OnTriggerStay(Collider other) 
    {
        DestroyGarbageOnTriggerStay(other);
    }   

    public void DestroyGarbageOnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Garbage"))      
        {
            other.gameObject.SetActive(false);          // Destroy(other.gameObject);
            //Debug.Log("We destroyed: " + other.gameObject.name);
        }
    }
}
