using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardWithAnimationController : MoveForwardBase, IWalkSit
//MoveForwardWithAnimation
{
    [SerializeField]  protected Animator myAnimator;
    protected CharactersAnimationController myAnimationController;

    [SerializeField] protected bool isSitting = false;
    [SerializeField] protected bool isWalking = true;
    [SerializeField] protected bool isSwimming = false;
    [SerializeField] protected float timerValue;
    protected float timeToSit;
    protected float timeToWalk;

    protected int litterRate;

    public virtual int GetLitterRate()
      //   _spawnInterval in Basespawner = litterRate
    {
        if (isSitting)
        { return litterRate = Random.Range(1, 5); }
        else
        { return litterRate = Random.Range(10, 20); }
    }

    public virtual bool GetIsSitting() //HOW TO SUNBATH???
    {
        return isSitting;
    }

    public bool GetIsWalking()
    {
        return isWalking;
    }
    public bool GetIsSwimming()
    {
        return isSwimming;
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
        SetTimeActionStates();
        timerValue = timeToWalk;
    }

    private void Update()
    {
        UpdateTimer();
        Animate();
        Move();
    }

    public virtual void SetTimeActionStates()
    {
        timeToSit = Random.Range(3f, 20f);
        timeToWalk = Random.Range(3f, 20f);
    }


    public virtual void UpdateTimer()
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
                SetRandomSpeed();
                SetTimeActionStates();
            }
        }
        timerValue -= Time.deltaTime;
    }


    public override void Move()
    {
        // Debug.Log(gameObject.name + "is moving");
        if (isWalking)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        //else  
        //{
        //    transform.Translate(Vector3.forward * 0 * Time.deltaTime);
        //    return;
        //}
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sea"))
        {
            myAnimationController.Swim();
            isSwimming = true;
        }

        if (other.gameObject.CompareTag("SeaBeachBorder"))
        {
            isSwimming = false;
            isWalking = true;
            isSitting = false;
            timerValue = timeToWalk;
       }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Sea"))
        {
            myAnimationController.StopSwim();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crowd"))
        {
            isWalking = true;
            isSitting = false;
            timerValue = timeToWalk;
        }
    }

    public virtual void Animate()
    {
      myAnimationController.WalkForwardIfNeeded(isWalking);
      myAnimationController.SitIfNeeded(isSitting);
    }
}
