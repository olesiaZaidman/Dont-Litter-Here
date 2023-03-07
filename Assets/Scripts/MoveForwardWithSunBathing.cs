using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardWithSunBathing : MoveForwardWithAnimationController
{
    //TODO: SetRandomCharacterRotationAndPositionRelativetoSunBed
    //Take sunbed size collider and calculate numbers from it:

    [SerializeField] bool isSunBathing = false;
    float timeToSunBath;
    [SerializeField] Vector3 positionSunBedOffset;
    CapsuleCollider capsuleCollider;
    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        SetRandomSpeed();
        SetTimeActionStates();
        timerValue = timeToWalk;
    }

    private void Update()
    {
        Move();
        UpdateTimer();
        Animate();
    }

    public override void SetTimeActionStates()
    {
        timeToSit = Random.Range(3f, 20f);
        timeToWalk = Random.Range(3f, 20f);
        timeToSunBath = Random.Range(3f, 10f); //Random.Range(15f, 70f);
    }
    public bool GetIsSunBathing()
    {
        return isSunBathing;
    }
    public override void UpdateTimer()
    {
        if (!isSunBathing)
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
            else if (isSitting)
            {
                if (timerValue <= 0)
                {
                    isSitting = false;
                    isWalking = true;
                    timerValue = timeToWalk;
                    SetTimeActionStates();
                    
                }
            }
            timerValue -= Time.deltaTime;
        }

        else if (isSunBathing)
        {
         
            if (timerValue <= 0)
            {               
                isSitting = false;
                isWalking = true;
                isSunBathing = false;
                timerValue = timeToWalk;
                SetTimeActionStates();
            }
            timerValue -= Time.deltaTime;
        }
    }

    void StopMoving()
    {
        speed = 0;

    }
    void StartMoving()
    {
        speed = SetRandomSpeed();
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("SunBed"))
        {
            Sunbed sunbed = other.gameObject.GetComponent<Sunbed>();
            if (sunbed.isInteractable)
            {
                sunbed.ChangeUnbrellaState();
                sunbed.isInteractable = false;
                capsuleCollider.enabled = false;
                StartCoroutine(SitStartSunBathingRoutine(other, timeToSunBath));
            }

            else if (!sunbed.isInteractable)
            {
                isSunBathing = false;
                isWalking = true;
                isSitting = false;
                timerValue = timeToWalk;
            }

        }
    }

    public IEnumerator SitStartSunBathingRoutine(Collision other, float _delay)
    {
        isSitting = false;
        isWalking = false;
        isSunBathing = true;
        timerValue = timeToSunBath;
        StopMoving();
        myAnimationController.Sunbath(true);
        PositionOnSunbed(other.gameObject, positionSunBedOffset);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        
        yield return new WaitForSeconds(_delay);

        isSunBathing = false;
        isWalking = true;
        isSitting = false;
        timerValue = timeToWalk;

        capsuleCollider.enabled = true;
        SetRandomCharacterRotationAndPositionRelativetoSunBed(other.gameObject);
        

        StartMoving();
        SetTimeActionStates();
        Sunbed sunbed = other.gameObject.GetComponent<Sunbed>();
        StartCoroutine(sunbed.MakeSunbedAvailableRoutine());
        sunbed.ChangeUnbrellaState();
    }

    Vector3 PositionNextToSunbed(GameObject other, Vector3 _offset)
    {

        Vector3 newPosition = other.gameObject.transform.position + _offset;
        return newPosition;
    }

    //TODO: SetRandomCharacterRotationAndPositionRelativetoSunBed
    //Take sunbed size collider and calculate numbers from it:
    void SetRandomCharacterRotationAndPositionRelativetoSunBed(GameObject _other)
    {

        int random = Random.Range(0, 4);
        Vector3 rightOffset = new Vector3(1f, 0f, 0f);
        Vector3 leftOffset = new Vector3(-1f, 0f, 0f);
        Vector3 frontOffset = new Vector3(0f, 0f, 2f);
        Vector3 backOffset = new Vector3(0f, 0f, -2f);

        if (random == 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            transform.position = PositionNextToSunbed(_other, rightOffset);
        }
        else if (random == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            transform.position = PositionNextToSunbed(_other, leftOffset);
        }

        else if (random == 2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            transform.position = PositionNextToSunbed(_other, backOffset);
        }

        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.position = PositionNextToSunbed(_other, frontOffset);
        }

    }

    void PositionOnSunbed(GameObject other, Vector3 _offset)
    {
        transform.position = other.gameObject.transform.position + _offset;
    }
  
    public override void Animate()
    {
        base.Animate();
        myAnimationController.Sunbath(isSunBathing);
    }
}
