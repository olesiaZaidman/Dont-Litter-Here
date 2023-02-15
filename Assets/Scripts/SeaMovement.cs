using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMovement : MonoBehaviour
{
    //protected const float xCoord = 3.3f;

    //protected float zMinPosRange = 31.8f;
    //protected float zMaxPosRange = 36.4f;

    //protected float yMinPosRange = -2f;
    //protected float yMaxPosRange = 5f;

    protected float initialPosX;
    protected float initialPosY;
    protected float initialPosZ;

    float speed = 1.5f;
    float height = 0.8f;

    void Awake()
    {
        initialPosX = transform.position.x;
        initialPosY = transform.position.y;
        initialPosZ = transform.position.z;
    }
    void Update()
    {
        Move();
    }

    protected void Move()
    {
        // transform.Translate(Vector3.forward * speed * Time.deltaTime);
        float newWave = Mathf.Cos(Time.time * speed) * height;
        transform.position = new Vector3(initialPosX, (initialPosY + Mathf.Pow(newWave, 2)), (initialPosZ + Mathf.Pow(newWave, 2))); // + Mathf.Abs(newY)
                                                                                                //(initialPosY + Mathf.Pow(newWave, 2))
    }

    //protected void CreateRandomVectorMove()
    //{
    //    float zCoord = Random.Range(zMinPosRange, zMaxPosRange);
    //    float yCoord = Random.Range(yMinPosRange, yMaxPosRange);
    //    Vector3 moveTo = new Vector3(xCoord, yCoord, zCoord);
    //}
}
