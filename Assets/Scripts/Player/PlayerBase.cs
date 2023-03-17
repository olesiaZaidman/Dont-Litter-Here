using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    Animator myAnimator;
    void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void StandUpAnimation()
    {
        myAnimator.SetBool("isStanding", true);
        StartCoroutine(IdleUpAnimation(2f));

    }

    IEnumerator IdleUpAnimation(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        myAnimator.SetBool("isStanding", false);
    }
}
