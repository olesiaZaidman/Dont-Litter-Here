using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towel : MonoBehaviour
{
    [SerializeField] GameObject towel;
    MoveForwardWithAnimationController moveController;
    void Start()
    {
        towel.SetActive(false);
        moveController = GetComponent<MoveForwardWithAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveController != null)
        {
            if (moveController.GetIsWalking())
            {
                towel.SetActive(false);
            }

            if (moveController.GetIsSitting())
            {
                towel.SetActive(true);
            }
        }
    }
}
