using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
   [SerializeField] float speedMin = 1.0f;
   [SerializeField] float speedMax = 6.0f;
    private Animator myAnimator;
    CharactersAnimationController myAnimationController;
    float speed;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myAnimationController = new CharactersAnimationController(myAnimator);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sea"))
        {
            myAnimationController.Swim();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Sea"))
        {
            myAnimationController.StopSwim();
        }
    }
}
