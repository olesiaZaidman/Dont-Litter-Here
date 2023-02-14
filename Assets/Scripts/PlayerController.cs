using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    private Animator myAnimator;
    float timeForCleaningAnimation = 3f;
    public static bool IsCleaningState { get; private set; }

    //float xMaxRange = 19f;
    //float xMinRange = -7f;
    //float zMaxRange = 1f;
    //float zMinRange = -10f;

    float verticalInput;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        IsCleaningState = false;
    }

    void Update() //FixedUpdate?
    {
        //   KeepInBoundaries();
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
        PlayAnimationIfNeeded("isCleaning", true);
        yield return new WaitForSeconds(_delay);
        IsCleaningState = false;
        PlayAnimationIfNeeded("isCleaning", false);
    }



    void MoveForwardBackward()
    {
        float customEpsilon = 0.001f;
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (verticalInput > customEpsilon) //or verticalInput !=0
        {
            PlayAnimationIfNeeded("isWalkingForward", true);
        }

        if (verticalInput < -customEpsilon)
        {
            PlayAnimationIfNeeded("isWalkingBackward", true);
        }
        else if(verticalInput == 0)
        {
            PlayAnimationIfNeeded("isWalkingBackward", false);
            PlayAnimationIfNeeded("isWalkingForward", false);
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

    public void PlayAnimationIfNeeded(string _animName, bool _isPlaying)
    {
        myAnimator.SetBool(_animName, _isPlaying);
    }

    //void KeepInBoundaries()
    //{
    //    if (transform.position.x > xMaxRange) //Keeps the player inbounds
    //    {
    //        transform.position = new Vector3(xMaxRange, transform.position.y, transform.position.z);
    //    }

    //    if (transform.position.x < xMinRange)//Keeps the player inbounds
    //    {
    //        transform.position = new Vector3(xMinRange, transform.position.y, transform.position.z);
    //    }

    //    if (transform.position.z > zMaxRange) //Keeps the player inbounds
    //    {
    //        transform.position = new Vector3(transform.position.x, transform.position.y, zMaxRange);
    //    }

    //    if (transform.position.z < zMinRange)//Keeps the player inbounds
    //    {
    //        transform.position = new Vector3(transform.position.x, transform.position.y, zMinRange);
    //    }

    //}

}
