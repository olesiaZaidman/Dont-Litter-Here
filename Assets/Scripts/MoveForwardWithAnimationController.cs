using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardWithAnimationController : MoveForwardBase
//MoveForwardWithAnimation
{
    private Animator myAnimator;
    CharactersAnimationController myAnimationController;

    private float timerValue;
    float timeToSit;
    float timeToWalk;

    bool isWalking = true;
    void Awake()
    {
        GetAnimatorControler();
    }

    //private void Start()
    //{
    //    SetTimeToSitAndWalk();
    //    timerValue = timeToWalk;
    //}

    //private void Update()
    //{
    //    UpdateTimer();

    //    //  Sit();
    //}
    //private void SetTimeToSitAndWalk()
    //{
    //    timeToSit = Random.Range(1f, 10f);
    //    timeToWalk = Random.Range(5f, 30f);
    //}

    //private void CancelTimer()
    //{
    //    timerValue = 0;
    //}

    //private void UpdateTimer()
    //{

    //    if (isWalking)
    //    {
    //        if (timerValue > 0)
    //        {
    //         //   timerValue -= Time.deltaTime;
    //        }

    //        else  //(timerValue <= 0)
    //        {
    //            isWalking = false;
    //            isSitting = true;
    //            timerValue = timeToSit;
    //        }
    //    }
    //    else //if  isSitting = true;
    //    {
    //        if (timerValue > 0)
    //        {
    //           // timerValue -= Time.deltaTime;
    //        }

    //        else 
    //        {
    //            isSitting = false;
    //            isWalking = true;
    //            timerValue = timeToWalk;
    //            SetTimeToSitAndWalk();
    //        }
    //    }
    //    Debug.Log("timerValue: "+ timerValue);
    //    Debug.Log("isWalking: " + isWalking);
    //    Debug.Log("isSitting: " + isSitting);

    //     timerValue -= Time.deltaTime;
    //}
    //private void Sit()
    //{
    //    SetTimeToSitAndWalk();
    //    timerValue = timeToSit;
    //    isSitting = true;
    //    myAnimationController.Sit();

    //    ///timer
    //    /// isSitting = false;
    //    /// myAnimationController.StopSit();

    //}

    public void GetAnimatorControler()
    {
        myAnimator = GetComponent<Animator>();
        myAnimationController = new CharactersAnimationController(myAnimator);
    }


    public override void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        myAnimationController.WalkForward();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sea"))
        {
            myAnimationController.Swim();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Sea"))
        {
            myAnimationController.StopSwim();
        }
    }
}
