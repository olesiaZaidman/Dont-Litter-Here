using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController
    //: MonoBehaviour
{
    private Animator m_animator;
    public AnimationController(Animator myAnimator)
    {
        this.m_animator = myAnimator;
    }
    public void PlayAnimationIfNeeded(string _animName, bool _isPlaying)
    {
      // YES Debug.Log("PlayAnimationIfNeeded");
        m_animator.SetBool(_animName, _isPlaying);
    }

    public void WalkForward()
    {
        PlayAnimationIfNeeded("isWalkingForward", true);
    }

    public void StopWalking()
    {
        PlayAnimationIfNeeded("isWalkingForward", false);
    }

    public void WalkForwardIfNeeded(bool _isPlaying)
    {
        PlayAnimationIfNeeded("isWalkingForward", _isPlaying);
    }

}
