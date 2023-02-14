using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float topBound = 15f;
    [SerializeField] float bottomBound = -15f;
    [SerializeField] float rightBound = 30f;
    [SerializeField] float leftBound = -15f;
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < bottomBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
