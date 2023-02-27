using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] IncreaseValueOverTime accelerator;
    // bool isSpeedDown = false;
    


     [SerializeField] float speed = 2f;
    float verticalInput;

    private Animator myAnimator;
    PlayerAnimationController myAnimationController;
    AudioManager audioManager;

    public static bool IsCleaningState { get; private set; }
    float timeForCleaningAnimation = 1.5f;
    float cleaningSpeed = 4f;

    public static bool IsTiredState { get; private set; }
    float timeForSittingTiredAnimation = 5f;
    FatigueIndicatorUI fatigueIndicator;
    bool isResting = false;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myAnimationController = new PlayerAnimationController(myAnimator);
        fatigueIndicator = FindObjectOfType<FatigueIndicatorUI>();
        audioManager = FindObjectOfType<AudioManager>();

        IsCleaningState = false;
    }

    void Update() //FixedUpdate?
    {       
        if (IsCleaningState || IsTiredState)
        { return;  }

        MoveForwardBackward();
        Clean();
        SetTimeForCleaningAnimation(Fatigue.Instance.GetFatiguePoints());

        if (isResting)
        {
            Fatigue.Instance.GraduallyDecreaseFill(timeForSittingTiredAnimation);
        }
    }

    #region Clean
    void Clean()
    {
        if ((Input.GetKey(KeyCode.Space)))
        {          
            StartCoroutine(StartCleaningRoutine(timeForCleaningAnimation));
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
            isResting = true;
            StartCoroutine(StartSeatAndRestRoutine(timeForSittingTiredAnimation));

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

       // Fatigue.Instance.GraduallyDecreaseFill(_delay);
         yield return new WaitForSeconds(_delay);
        isResting = false;
        Fatigue.Instance.ZeroDownFatigue();
        IsTiredState = false;
        myAnimationController.SitAndRestIfNeeded(IsTiredState); //       PlayAnimationIfNeeded("isCleaning", false);
    }

    #endregion

    #region Move
    void MoveForwardBackward()
    {
        float customEpsilon = 0.001f;
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (verticalInput > customEpsilon) //or verticalInput !=0
        {
            myAnimationController.WalkForward();
        }

        else if (verticalInput < -customEpsilon)
        {
            myAnimationController.WalkBackward();
        }
        else if(verticalInput == 0)
        {
            myAnimationController.Idle();
        }
     //   Debug.Log(verticalInput);

        //if (verticalInput != 0)
        //{
        //    PlayAnimationIfNeeded("isWalkingBackward", true);
        //    PlayAnimationIfNeeded("isCleaning", false);
        //    Debug.Log(verticalInput);

        //}

        //else
        //{
        //    PlayAnimationIfNeeded("isWalkingBackward", false);
        //}

    }
    #endregion
}
