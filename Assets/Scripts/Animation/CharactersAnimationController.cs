using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersAnimationController : AnimationController
{
    public CharactersAnimationController(Animator myAnimator) : base(myAnimator)
    {

    }

    public void Swim()
    {
        PlayAnimationIfNeeded("isSwimming", true);
    }

    public void StopSwim()
    {
        PlayAnimationIfNeeded("isSwimming", false);
    }

}
