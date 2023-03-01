using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGarbageDestroyer : GarbageDestroyer
{
    AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void OnTriggerStay(Collider other) 
    {
        DestroyGarbageOnCleaningAnimationState(other);
    }

    void DrinkWater(int points)
    {
        Fatigue.Instance.DecreaseFatiguePoints(points);
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
                audioManager.PlayGulp();
            }
            if (other.gameObject.GetComponent<Litter>())
            { 
                audioManager.PlaySighOnce(delay);
               // Cleanliness.Instance.RecalculateCleanRatingPoints();                //Cleanliness.Instance.IncreaseCleanRatingPoints(Cleanliness.Points);
            }

            DestroyGarbageOnTriggerStay(other);
           
        }
    }
}
