using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGarbageDestroyer : GarbageDestroyer
{
    AudioManager audioManager;
    UIManager uiManager;
    void Start()
    {
     //   playerGoldScanner = FindObjectOfType<GoldScanner>();
        audioManager = FindObjectOfType<AudioManager>();
        uiManager = FindObjectOfType<UIManager>();
    }
    void OnTriggerStay(Collider other) 
    {
        DestroyGarbageOnCleaningAnimationState(other);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Garbage"))
        {
            if (!UIManager.isGarbageMessage)
            {
                UIManager.isGarbageMessage = true;
                uiManager.ShowGarbageMessage();
            }
        }
        DestroyGarbageOnCleaningAnimationState(other);
    }

    void DrinkWater(int points)
    {
        Fatigue.Instance.DecreaseFatiguePoints(points);
    }


    void DestroyGarbageOnCleaningAnimationState(Collider other)
    {
        int recoveryPoints = 30;
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
            }

            if (other.gameObject.GetComponent<Loot>())
            {
                
                audioManager.PlayGulp();
                ScoreManager.Instance.AddMoneyPoint(Loot.points); //Add Money Points
                // audioManager.LootFoundBeepSFX();
               // playerGoldScanner.isTargetFound = false;
            }

            DestroyGarbageOnTriggerStay(other);
           
        }
    }
}
