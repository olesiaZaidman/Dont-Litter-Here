using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
   [SerializeField] float speedMin = 1.0f;
   [SerializeField] float speedMax = 6.0f;
    private Animator myAnimator;
    AnimationController myAnimationController;
    float speed;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myAnimationController = new AnimationController(myAnimator);
    }
    void Start()
    {
        speed = Random.Range(speedMin, speedMax);
    }


    void Update() //our prefab will alway move forward:
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        myAnimationController.WalkForward();
    }
}
