using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttakAngy : StateMachineBehaviour
{
    Boss boss;
    Boss script;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        script = boss.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (script.randomattak == 1)
        {
            animator.SetTrigger("SummonEnemies");

            if (script.teleportTime <= 0)
            {
                animator.SetTrigger("Teleport");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("SummonEnemies");
    }
}
