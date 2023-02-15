using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGarbageDestroyer : GarbageDestroyer
{
    void OnTriggerStay(Collider other) //OnTriggerEnter
    {
        DestroyGarbageOnCleaningAnimationState(other);
    }
    void DestroyGarbageOnCleaningAnimationState(Collider other)
    {
        if (PlayerController.IsCleaningState)
        {
            DestroyGarbageOnTriggerStay(other);
        }
    }
}
