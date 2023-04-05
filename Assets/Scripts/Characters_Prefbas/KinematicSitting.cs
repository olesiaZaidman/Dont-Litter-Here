using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSitting : MonoBehaviour
{
    Rigidbody rb;
    MoveForwardWithAnimationController moveController;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveController = GetComponent<MoveForwardWithAnimationController>();
    }

    void Update()
    {
        if (moveController != null)
        {
            if (moveController.GetIsWalking())
            {
                rb.isKinematic = false;
            }

            if (moveController.GetIsSitting() || moveController.GetIsSwimming())
            {
                rb.isKinematic = true;
            }
        }


    }
}
