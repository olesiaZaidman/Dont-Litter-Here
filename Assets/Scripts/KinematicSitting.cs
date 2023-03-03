using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSitting : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] MoveForwardWithAnimationController moveController;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (moveController.GetIsWalking())
        {
            rb.isKinematic = false;
        }

        if (moveController.GetIsSitting())
        {
            rb.isKinematic = true;
        }

    }
}
