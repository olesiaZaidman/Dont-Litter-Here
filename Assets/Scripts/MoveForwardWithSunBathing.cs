using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardWithSunBathing : MoveForwardWithAnimationController
{
    //TODO:
    //COLLIDERS
    //ROtation&Pos
    [SerializeField] bool isSunBathing = false;
    float timeToSunBath;

    [SerializeField] Vector3 positionSunBedOffset;
    [SerializeField] Vector3 currentPos;
    private void Start()
    {
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
        timeToSunBath = Random.Range(15f, 70f);
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
                    Debug.Log("isSitting = true");
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
                    Debug.Log("isWalking = true");
                }
            }
            timerValue -= Time.deltaTime;
        }

        else if (isSunBathing)
        {
            Debug.Log("isSunBathing = true");
            if (timerValue <= 0)
            {
                Debug.Log("isSunBathing = false");
                isSitting = false;
                isWalking = false;
                isSunBathing = false;
                timerValue = timeToSunBath;
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


    void OnCollisionEnter(Collision other) //OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SunBed"))
        {
            Sunbed sunbed = other.gameObject.GetComponent<Sunbed>();
            if (sunbed.isInteractable)
            {
                Debug.Log("Bumped into a sunbed");
                sunbed.ChangeUnbrellaState();
                StartCoroutine(SitStartSunBathingRoutine(other, timeToSunBath));
            }
            //else if (!isInteractable)
            //{
            //    isSunBathing = false;
            //    isWalking = true;
            //    isSitting = false;
            //    timerValue = timeToWalk;
            //    //Rotate a little?
            //}

        }
    }

    public IEnumerator SitStartSunBathingRoutine(Collision other, float _delay)
    {
        isSitting = false;
        isWalking = false;
        isSunBathing = true;
        StopMoving();
        myAnimationController.Sunbath(true);
        currentPos = transform.position;
        PositionOnSunbed(other.gameObject, positionSunBedOffset);
        Debug.Log("SpeedEnter" + speed);

        yield return new WaitForSeconds(_delay);

        isSunBathing = false;
        isWalking = true;
        PositionBehindSunbed();
        StartMoving();
        isSitting = false;
        SetTimeActionStates();
        timerValue = timeToWalk;
    }

    void OnCollisionExit(Collision other) //OnTriggerExit(Collider other)//
    {
        if (other.gameObject.CompareTag("SunBed"))
        {
            Sunbed sunbed = other.gameObject.GetComponent<Sunbed>();
            StartCoroutine(sunbed.MakeSunbedAvailableRoutine());
            sunbed.ChangeUnbrellaState();
            Debug.Log("SpeedExit" + speed);
        }
    }

    void PositionOnSunbed(GameObject other, Vector3 _offset)
    {
        transform.position = other.gameObject.transform.position + _offset;
    }

    void PositionBehindSunbed()
    {
        Vector3 _offset = new Vector3(0.6f, 0, 0);
        transform.position = currentPos + _offset;
    }


    public override void Animate()
    {
        base.Animate();
        myAnimationController.Sunbath(isSunBathing);
    }
}
