using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoredBehavior : StateMachineBehaviour
{
    [SerializeField]  float timeUntilBored = 3f;
    [SerializeField]  float numberOfBoredAnimations = 3f;

    bool isBored;
    float idleTime;
    int boredAnimation;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetIdle();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!isBored)
        {
            idleTime += Time.deltaTime;

            if (idleTime > timeUntilBored && stateInfo.normalizedTime % 1 < 0.02f) //we are at the beginig of one of animation loops
            {
                isBored = true;
                boredAnimation = Random.Range(1, (int)numberOfBoredAnimations + 1);
            }
        }
        else if (stateInfo.normalizedTime % 1 > 0.98) //we are at the end of one of animation loops
        {
            //  If yes, We reset to defaul idle animation
            ResetIdle();
        }
        animator.SetFloat("BoredAnimation", boredAnimation, 0.2f, Time.deltaTime);
    }

    void ResetIdle() //Animator animator
    {
        isBored = false;
        idleTime = 0;
        boredAnimation = 0;
       // animator.SetFloat("BoredAnimation", 0); //default animation
    }
}
