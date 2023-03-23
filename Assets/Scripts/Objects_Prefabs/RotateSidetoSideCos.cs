using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSidetoSideCos : MonoBehaviour
{
   float speed = 2f;
    float distance = 0.8f;

    private void Start()
    {
        speed = Random.Range(0.5f,3f);
    }

    void MoveSidetoSideCos()
    {
        float newZ = Mathf.Cos(Time.time * speed) * distance;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Pow(newZ, 2));
    }
    void Update()
    {
        MoveSidetoSideCos();

    }
}
