using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    Animator myAnimator;
    void Awake()
    {
        myAnimator = GetComponent<Animator>();
       // IdleAnimation(); it doesn't work
    }

    //isIdle

    public void IdleAnimation()
    {
        myAnimator.SetBool("isIdle", true);
    }
    public void StandUpAnimation()
    {
        myAnimator.SetBool("isStanding", true);
        myAnimator.SetBool("isIdle", false);
        StartCoroutine(IdleUpAnimation(2f));                           
    }

    IEnumerator IdleUpAnimation(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        myAnimator.SetBool("isStanding", false);
    }
}
