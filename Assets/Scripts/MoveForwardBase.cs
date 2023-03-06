using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardBase : MonoBehaviour
{
    [SerializeField] protected float speedMin = 1.0f;
    [SerializeField] protected float speedMax = 6.0f;

    protected float speed;

    //protected virtual float SpeedMin { get { return 1f; } }
    //   protected virtual float SpeedMax { get { return 6f; } }

    void Start()
    {
        SetRandomSpeed();
    }

    void Update() //our prefab will alway move forward:
    {
        Move();
    }

    public float SetRandomSpeed()
    {
        speed = Random.Range(speedMin, speedMax);
        return speed;
    }


    public virtual void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
