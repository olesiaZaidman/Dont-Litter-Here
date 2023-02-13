using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
  //  [SerializeField] float rotationSpeed = 5f;
    private Animator myAnimator;

    //float xMaxRange = 19f;
    //float xMinRange = -7f;
    //float zMaxRange = 1f;
    //float zMinRange = -10f;

    float verticalInput;
   // float horizontalInput;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        //   KeepInBoundaries();
        MoveForwardBackward();
        Clean();
    }

    void Clean()
    {
        if ((Input.GetKey(KeyCode.Space)))
        {
            PlayAnimationIfNeeded("isCleaning", true);
        }
    }

  
    void MoveForwardBackward()
    {
        // horizontalInput = Input.GetAxis("Horizontal");
        // transform.Rotate(Vector3.up, Time.deltaTime * horizontalInput * rotationSpeed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        myAnimator.SetBool("isWalking", true);

        if (verticalInput > 0 || verticalInput < 0)
        { PlayAnimationIfNeeded("isWalking", true); }
        //figure how to walk backwards with animation
        else
        { PlayAnimationIfNeeded("isWalking", false); }
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
