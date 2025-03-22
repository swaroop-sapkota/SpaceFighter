using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : StateMachineBehaviour
{
    float timer;
    float chaseRange = 8;
    Transform player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;

        // Use FindWithTag to get the first player object
        player = GameObject.FindWithTag("Player").transform;  // Corrected this line
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            animator.SetBool("isPatrolling", true);
        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}

