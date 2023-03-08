using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreSunbed : MonoBehaviour
{
    //Sits on Player to walk through sunbed
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SunBed"))
        {
            rb.isKinematic = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("SunBed"))
        {
            rb.isKinematic = false;
        }
    }
}
