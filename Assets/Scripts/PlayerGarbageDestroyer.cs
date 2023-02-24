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

    //WaterBottle

     void DrinkWater(int points)
    {
            Debug.Log("Water!");
            fatigueIndicator.DecreaseFillOnWater(points);
    }


    void DestroyGarbageOnCleaningAnimationState(Collider other)
    {
        int recoveryPoints = 20;
        float delay = 3f; 

        if (PlayerController.IsCleaningState)
        {
            if (other.gameObject.GetComponent<WaterBottle>())
            {
                DrinkWater(recoveryPoints);
            }

            DestroyGarbageOnTriggerStay(other);
            audioManager.PlaySighOnce(delay);       
        }
    }
}
