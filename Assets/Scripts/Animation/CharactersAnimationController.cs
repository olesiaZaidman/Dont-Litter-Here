using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersAnimationController : AnimationController
{
    public CharactersAnimationController(Animator myAnimator) : base(myAnimator)
    {
        //15/24/40
    }

    public void Swim()
    {
        PlayAnimationIfNeeded("isSwimming", true);
    }

    public void StopSwim()
    {
        PlayAnimationIfNeeded("isSwimming", false);
    }

    public void SitIfNeeded(bool _isPlaying)
    {
        PlayAnimationIfNeeded("isSitting", _isPlaying);
    }

    //public void LayAndSunbath()
    //{
    //    PlayAnimationIfNeeded("isSwimming", true);
    //}

}
