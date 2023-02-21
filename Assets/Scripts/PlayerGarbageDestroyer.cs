using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGarbageDestroyer : GarbageDestroyer
{
 //   ScoreManager scoreManager;
    CleanIndicator cleanIndicator;
    AudioManager audioManager;
    void Start()
    {
       // scoreManager = FindObjectOfType<ScoreManager>();//ScoreManager.Instance;
        cleanIndicator = FindObjectOfType<CleanIndicator>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    void OnTriggerStay(Collider other) //OnTriggerEnter
    {
        DestroyGarbageOnCleaningAnimationState(other);
    }
    void DestroyGarbageOnCleaningAnimationState(Collider other)
    {
        if (PlayerController.IsCleaningState)
        {
            DestroyGarbageOnTriggerStay(other);
            audioManager.PlaySigh();
           // scoreManager.DecreaseScorePoints(scoreManager.DirtLevelPoints);
            cleanIndicator.IncreaseFill();
        }
    }
}
