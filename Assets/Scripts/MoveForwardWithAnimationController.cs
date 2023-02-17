using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardWithAnimationController : MoveForwardBase
//MoveForwardWithAnimation
{
    private Animator myAnimator;
    CharactersAnimationController myAnimationController;

    void Awake()
    {
        GetAnimatorControler();
    }

    public void GetAnimatorControler()
    {
        myAnimator = GetComponent<Animator>();
        myAnimationController = new CharactersAnimationController(myAnimator);
    }


    public override void Move()
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
