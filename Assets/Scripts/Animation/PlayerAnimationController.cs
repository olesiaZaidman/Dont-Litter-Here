using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AnimationController
{  
    public PlayerAnimationController(Animator myAnimator) : base(myAnimator)
    {
       
    }

    public void CleanPickUpIfNeeded(bool _isPlaying)
    {
        PlayAnimationIfNeeded("isCleaning", _isPlaying);
    }

    public void StartCleanPickUp()
    {
        PlayAnimationIfNeeded("isCleaning", true);
    }

    public void StopCleanPickUp()
    {
        PlayAnimationIfNeeded("isCleaning", false);
    }

    public void Idle()
    {
        PlayAnimationIfNeeded("isWalkingBackward", false);
        PlayAnimationIfNeeded("isWalkingForward", false);
    }

    public void WalkBackward()
    {
        PlayAnimationIfNeeded("isWalkingBackward", true);
    }

    
}
