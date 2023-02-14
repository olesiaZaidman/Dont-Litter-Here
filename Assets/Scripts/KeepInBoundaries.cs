using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInBoundaries : MonoBehaviour
{
    [Header("Boundaries")]

    [SerializeField] float xMaxRange = 19f;
    [SerializeField] float xMinRange = -7f;
    [SerializeField] float zMaxRange = 1f;
    [SerializeField] float zMinRange = -10f;

    void Update()
    {
        StayInGameSpaceBoundaries();
    }

    void StayInGameSpaceBoundaries()
    {
        if (transform.position.x > xMaxRange) //Keeps the player inbounds
        {
            transform.position = new Vector3(xMaxRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x < xMinRange)//Keeps the player inbounds
        {
            transform.position = new Vector3(xMinRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z > zMaxRange) //Keeps the player inbounds
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMaxRange);
        }

        if (transform.position.z < zMinRange)//Keeps the player inbounds
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMinRange);
        }

    }
}
