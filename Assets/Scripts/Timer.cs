using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timerValue;
    float timeToSit;
    float timeToWalk;

    private bool m_isWalking;
    private bool m_isSitting;


    //  [SerializeField] MoveForwardWithAnimationController moveController;
    public Timer(bool isWalking, bool isSitting) 
    {
        //    timer = new Timer(isWalking, isSitting);
        m_isWalking = isWalking;
        m_isSitting = isSitting;
    }
    private void Start()
    {
        SetTimeToSitAndWalk();
        timerValue = timeToWalk;
    }

    private void Update()
    {
        UpdateTimer();
    }
    public void SetTimeToSitAndWalk()
    {
        timeToSit = Random.Range(1f, 10f);
        timeToWalk = Random.Range(5f, 30f);
    }


    public void UpdateTimer()
    {
        if (m_isWalking)
        {
            if (timerValue <= 0)
            {
                m_isWalking = false;
                m_isSitting = true;
                timerValue = timeToSit;
            }

        }
        else //if  isSitting = true;
        {
            if (timerValue <= 0)
            {
                m_isSitting = false;
                m_isWalking = true;
                timerValue = timeToWalk;
                SetTimeToSitAndWalk();
            }
        }
        timerValue -= Time.deltaTime;
    }

    //private void CancelTimer()
    //{
    //    timerValue = 0;
    //}

}
