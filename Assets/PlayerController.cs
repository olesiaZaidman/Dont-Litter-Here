using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

 

    [SerializeField] float speed = 2f;
    [SerializeField] float rotationSpeed = 5f;
    private Animator myAnimator;

    //float xMaxRange = 19f;
    //float xMinRange = -7f;
    //float zMaxRange = 1f;
    //float zMinRange = -10f;

    float verticalInput;
    float horizontalInput;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        //   KeepInBoundaries();
        RotateAfterMouseCoursor();
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

    void RotateAfterMouseCoursor() //WORKS BUT NOT 100% like i want
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle , 0f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg; //WORKS BUT NOT 100% like i want
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

}
