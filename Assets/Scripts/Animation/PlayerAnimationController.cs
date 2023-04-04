using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AnimationController
{  
    public PlayerAnimationController(Animator myAnimator) : base(myAnimator)
    {
       
    }
    //public void WalkForwardInCertainStyle(bool _isConditionForDifferentWalk)
    //{
    //    if (_isConditionForDifferentWalk)
    //    {
    //        PlayAnimationIfNeeded("isWalkingTired", true);
    //    }
    //    else
    //    PlayAnimationIfNeeded("isWalkingForward", true);
    //}

    //public override void StopWalking()
    //{
    //    PlayAnimationIfNeeded("isWalkingForward", false);
    //    PlayAnimationIfNeeded("isWalkingTired", false);
    //}

    public void CleanPickUpIfNeeded(bool _isPlaying)
    {
        PlayAnimationIfNeeded("isCleaning", _isPlaying);
    }

    public void SitAndRestIfNeeded(bool _isPlaying)
    {
        PlayAnimationIfNeeded("isSitting", _isPlaying);
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

    public void LoseGame()
    {
        PlayAnimationIfNeeded("isLoseGame", true);
    }

    public void WinGameNewRecord()
    {
        PlayAnimationIfNeeded("isWinGame", true);
    }

    //public void Run()
    //{
    //    PlayAnimationIfNeeded("isWalkingForward", true); //isRunning
    //}


}
