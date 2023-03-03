using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardWithAnimationController : MoveForwardBase
//MoveForwardWithAnimation
{
    private Animator myAnimator;
    CharactersAnimationController myAnimationController;

     bool isSitting = false;
     bool isWalking = true;

    [SerializeField] float timerValue;
    float timeToSit;
    float timeToWalk;

    public bool GetIsSitting()
    {
        return isSitting;
    }

    public bool GetIsWalking()
    {
        return isWalking;
    }


    public void GetAnimatorControler()
    {
        // YES Debug.Log("Fetched animator");
        myAnimator = GetComponent<Animator>();
        myAnimationController = new CharactersAnimationController(myAnimator);
    }


    void Awake()
    {
        GetAnimatorControler();
    }

    private void Start()
    {
        SetRandomSpeed();
        SetTimeToSitAndWalk();
        timerValue = timeToWalk;
    }

    private void Update()
    {
        Move();
        UpdateTimer();
        Sit();
    }

    public void SetTimeToSitAndWalk()
    {
        timeToSit = Random.Range(3f, 20f);
        timeToWalk = Random.Range(3f, 20f);
    }


    public void UpdateTimer()
    {
        if (isWalking)
        {
            if (timerValue <= 0)
            {
                isWalking = false;
                isSitting = true;
                timerValue = timeToSit;
            }

        }
        else //if  isSitting = true;
        {
            if (timerValue <= 0)
            {
                isSitting = false;
                isWalking = true;
                timerValue = timeToWalk;
                SetTimeToSitAndWalk();
            }
        }
        timerValue -= Time.deltaTime;
    }

    private void Sit()
    {
        myAnimationController.SitIfNeeded(isSitting);
    }

    public override void Move()
    {
        Debug.Log(gameObject.name + "is moving");
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        myAnimationController.WalkForwardIfNeeded(isWalking);
        myAnimator.SetFloat("moveSpeed", speed);
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
