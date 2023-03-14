using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceFromSunbed : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SunBed"))
        {
            Vector3 pos = transform.position;
            Vector3 offset = new Vector3(transform.position.x, transform.position.y, 0.5f);
            transform.position = pos + offset;

        //    Debug.Log(gameObject.name+ " has collided with Bouncer SunBed");
        }
    }

}
