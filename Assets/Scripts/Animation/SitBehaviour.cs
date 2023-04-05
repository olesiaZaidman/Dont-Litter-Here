using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitBehaviour : StateMachineBehaviour
{
    [SerializeField] float timeUntilSit = 3f;
    [SerializeField] float numberOfSitAnimations = 3f;

    bool isSitting;
    float sittingTime;
    int sitAnimation;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetDefault();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!isSitting)
        {
            sittingTime += Time.deltaTime;

            if (sittingTime > timeUntilSit && stateInfo.normalizedTime % 1 < 0.02f) //we are at the beginig of one of animation loops
            {
                isSitting = true;
                sitAnimation = Random.Range(1, (int)numberOfSitAnimations + 1);
                sitAnimation = sitAnimation * 2 - 1;
                animator.SetFloat("SitAnimation", sitAnimation - 1); //closest default Idle animation
            }
        }
        else if (stateInfo.normalizedTime % 1 > 0.97) //we are at the end of one of animation loops
        {
            //  If yes, We reset to defaul idle animation
            ResetDefault();
        }

        animator.SetFloat("SitAnimation", sitAnimation, 0.3f, Time.deltaTime);
      //  Debug.Log("stateInfo.normalizedTime: " + stateInfo.normalizedTime);
     //   Debug.Log("stateInfo.length: " + stateInfo.length);
    }

    void ResetDefault() //Animator animator
    {
        if (isSitting)
        {
            sitAnimation--;
        }
        isSitting = false;
        sittingTime = 0;
        sitAnimation = 0;
        // animator.SetFloat("BoredAnimation", 0); //default animation }
    }
}
