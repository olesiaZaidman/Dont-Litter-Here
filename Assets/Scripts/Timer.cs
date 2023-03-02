using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] bool isSitting = false;
    [SerializeField] bool isWalking = true;

    [SerializeField] float timerValue;
    float timeToSit;
    float timeToWalk;


    private void Start()
    {
        SetTimeToSitAndWalk();
        timerValue = timeToWalk;
    }

    private void Update()
    {
        UpdateTimer();

        //  Sit();
    }
    private void SetTimeToSitAndWalk()
    {
        timeToSit = Random.Range(1f, 10f);
        timeToWalk = Random.Range(5f, 30f);
    }

    //private void CancelTimer()
    //{
    //    timerValue = 0;
    //}

    private void UpdateTimer()
    {

        if (isWalking)
        {
            if (timerValue > 0)
            {
                //   timerValue -= Time.deltaTime;
            }

            else  //(timerValue <= 0)
            {
                isWalking = false;
                isSitting = true;
                timerValue = timeToSit;
            }
        }
        else //if  isSitting = true;
        {
            if (timerValue > 0)
            {
                // timerValue -= Time.deltaTime;
            }

            else
            {
                isSitting = false;
                isWalking = true;
                timerValue = timeToWalk;
                SetTimeToSitAndWalk();
            }
        }
        Debug.Log("timerValue: " + timerValue);
        Debug.Log("isWalking: " + isWalking);
        Debug.Log("isSitting: " + isSitting);

        timerValue -= Time.deltaTime;
    }
}
