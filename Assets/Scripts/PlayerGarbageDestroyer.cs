using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGarbageDestroyer : GarbageDestroyer
{
 //   ScoreManager scoreManager;
    CleanIndicatorUI cleanIndicator;
    FatigueIndicatorUI fatigueIndicator;
    AudioManager audioManager;
    void Start()
    {
       // scoreManager = FindObjectOfType<ScoreManager>();//ScoreManager.Instance;
        cleanIndicator = FindObjectOfType<CleanIndicatorUI>();
        fatigueIndicator = FindObjectOfType<FatigueIndicatorUI>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    void OnTriggerStay(Collider other) //OnTriggerEnter
    {
        DestroyGarbageOnCleaningAnimationState(other);


        //if (true)        //if garbage hasIwaterInterface
        //{
        //    fatigueIndicator.DecreaseFill();
        //    Debug.Log("We hadsome water!");
        //}
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
