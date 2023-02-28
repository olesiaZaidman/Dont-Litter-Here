using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float walkingSpeed = 2f;
    float runningSpeed = 4f;
    float maxTimeOfRunning = 5f; //the longer the time the longer we can run around map
    float verticalInput;

    private Animator myAnimator;
    PlayerAnimationController myAnimationController;
    AudioManager audioManager;

    public static bool IsCleaningState { get; private set; }
    float timeForCleaningAnimation = 1.5f;
    float cleaningSpeed = 4f;

    public static bool IsTiredState { get; private set; }
    public static bool IsResting { get; private set; }
    public static float TimeSittingTiredAnimation { get { return 5f; } }


    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myAnimationController = new PlayerAnimationController(myAnimator);
        audioManager = FindObjectOfType<AudioManager>();

        IsCleaningState = false;
    }

    void Update() //FixedUpdate?
    {
        if (IsCleaningState || IsTiredState) //|| IsResting
        { return; }

        MoveForwardBackward();
        CleanOnIput();
        SitOnIput();
        SetTimeForCleaningAnimation(Fatigue.Instance.GetFatiguePoints());
    }

    #region Clean
    void CleanOnIput()
    {
        if ((Input.GetKey(KeyCode.Space)))
        {
            StartCoroutine(StartCleaningRoutine(timeForCleaningAnimation));
        }
    }

    void SitOnIput()
    {
        if (Input.GetKey(KeyCode.Z) && Fatigue.Instance.GetFatiguePoints() < Fatigue.Instance.MaxEnergyLevelPoints && Fatigue.Instance.GetFatiguePoints() > 0)
        {
           // IsResting = true;
            audioManager.PlaySighOnce(TimeSittingTiredAnimation);
            myAnimationController.SitAndRestIfNeeded(true);
            Fatigue.Instance.GraduallyDecreaseFill(TimeSittingTiredAnimation);
        }
        else
        {
            myAnimationController.SitAndRestIfNeeded(false);
         //   IsResting = false;
           // Debug.Log("NOT RESTING");
        }
    }


    void SetTimeForCleaningAnimation(float fatigue)
    {
        if (fatigue < 30) //Input.GetKey(KeyCode.I)
        {
            timeForCleaningAnimation = 1.5f;
            cleaningSpeed = 4f;
            myAnimator.SetFloat("pickUpSpeed", cleaningSpeed);
        }

        if (fatigue >= 30 && fatigue < 70) //
        {
            timeForCleaningAnimation = 2.5f;
            cleaningSpeed = 2f;
            myAnimator.SetFloat("pickUpSpeed", cleaningSpeed);
        }

        if (fatigue >= 70) // && fatigue < 95
        {
            timeForCleaningAnimation = 4f;
            cleaningSpeed = 1f;
            myAnimator.SetFloat("pickUpSpeed", cleaningSpeed);
        }
        if (fatigue >= Fatigue.Instance.MaxEnergyLevelPoints)
        {
            StartCoroutine(StartSeatAndRestRoutine(TimeSittingTiredAnimation));
        }

    }

    IEnumerator StartCleaningRoutine(float _delay)
    {
        IsCleaningState = true;
        myAnimationController.CleanPickUpIfNeeded(IsCleaningState);      // PlayAnimationIfNeeded("isCleaning", true);
        yield return new WaitForSeconds(_delay);
        IsCleaningState = false;
        myAnimationController.CleanPickUpIfNeeded(IsCleaningState); //       PlayAnimationIfNeeded("isCleaning", false);
    }
    #endregion

    #region Fatigue
    IEnumerator StartSeatAndRestRoutine(float _delay)
    {
        audioManager.PlaySighOnce(_delay);
        IsTiredState = true;
        myAnimationController.SitAndRestIfNeeded(IsTiredState);      // PlayAnimationIfNeeded("isCleaning", true);
        Debug.Log("IsTiredState"+IsTiredState);
        // Fatigue.Instance.GraduallyDecreaseFill(_delay);
        yield return new WaitForSeconds(_delay);
        // isResting = false;
        Fatigue.Instance.ZeroDownFatigue();
        IsTiredState = false;
        myAnimationController.SitAndRestIfNeeded(IsTiredState); //       PlayAnimationIfNeeded("isCleaning", false);
        Debug.Log("IsTiredState" + IsTiredState);
    }

    #endregion

    #region Move
    void MoveForwardBackward()
    {
        float customEpsilon = 0.001f;
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * walkingSpeed);

        if (verticalInput > customEpsilon) 
        {
            myAnimationController.WalkForward();
            myAnimator.SetFloat("moveSpeed", walkingSpeed);              

            if (Input.GetKey(KeyCode.LeftShift) && Fatigue.Instance.GetFatiguePoints()< Fatigue.Instance.MaxEnergyLevelPoints)
            {
                myAnimationController.WalkForward();
                myAnimator.SetFloat("moveSpeed", runningSpeed); 
               Fatigue.Instance.GraduallyIncreaseFill(maxTimeOfRunning);
            }       
        }

        else if (verticalInput < -customEpsilon)
        {
            myAnimationController.WalkBackward();
            myAnimator.SetFloat("moveSpeed", walkingSpeed);
        }


        else if (verticalInput == 0)
        {
            myAnimationController.Idle();
        }
    }

    //void Run()
    //{
    //    if (Input.GetKey(KeyCode.LeftShift) && Fatigue.Instance.GetFatiguePoints() < Fatigue.Instance.MaxEnergyLevelPoints)
    //    {
    //        myAnimationController.WalkForward();
    //        myAnimator.SetFloat("moveSpeed", runningSpeed); // float runningSpeed = 4f;}
    //        Fatigue.Instance.GraduallyIncreaseFill(5);
    //    }
    //}

    #endregion
}
