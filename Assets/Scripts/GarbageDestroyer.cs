using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageDestroyer : MonoBehaviour
{
    void OnTriggerStay(Collider other) //OnTriggerEnter
    {
        if (other.gameObject.CompareTag("Garbage") && PlayerController.IsCleaningState)       // 
        {
            Destroy(other.gameObject);
            Debug.Log("We destroyed: " + other.gameObject.name);
        }
    }   
}
