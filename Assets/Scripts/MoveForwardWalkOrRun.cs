using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardWalkOrRun : MoveForwardWithAnimationController
{

    private void Update()
    {
        Move();
        UpdateTimer();
        Animate();
    }

    //public override void Move()
    //{
    //    // Debug.Log(gameObject.name + "is moving");
    //    if (isWalking)
    //    {
    //        transform.Translate(Vector3.forward * speed * Time.deltaTime);        
    //    }
    //}

    public override void Animate()
    {
        base.Animate();
        if (isWalking)
        {
            myAnimator.SetFloat("moveSpeed", speed);
        }
    }

}
