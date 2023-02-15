using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    private Animator myAnimator;
    PlayerAnimationController myAnimationController;
    float timeForCleaningAnimation = 3f;
    public static bool IsCleaningState { get; private set; }

    float verticalInput;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myAnimationController = new PlayerAnimationController(myAnimator);
        IsCleaningState = false;
    }

    void Update() //FixedUpdate?
    {
        
        if (!PlayerController.IsCleaningState)
        { MoveForwardBackward(); }

        Clean();
    }

    void Clean()
    {
        if ((Input.GetKey(KeyCode.Space)))
        {          
            StartCoroutine(StartCleaningRoutine(timeForCleaningAnimation));
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
}
