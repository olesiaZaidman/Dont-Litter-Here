using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardBase : MonoBehaviour
{
    [SerializeField] protected float speedMin = 1.0f;
    [SerializeField] protected float speedMax = 6.0f;
    protected bool isSitting = false;
    //protected virtual float SpeedMin { get { return 1f; } }
    //   protected virtual float SpeedMax { get { return 6f; } }
    protected float speed;

    void Start()
    {
        SetRandomSpeed();
    }

    void Update() //our prefab will alway move forward:
    {
        if (isSitting)
        { return; }
        Move();
    }

    public void SetRandomSpeed()
    {
        speed = Random.Range(speedMin, speedMax);
    }


    public virtual void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
