using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HalfWayPatrol: StateMachineBehaviour
{
    float timer;
    float chaseRange = 15;

    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Use GameObject.FindWithTag() or access the first player in the array
        player = GameObject.FindWithTag("Player").transform;

        agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;
        agent.speed = 1.5f;

        // Ensure the agent is not stopped and setup speed
        if (agent.isStopped)
        {
            agent.isStopped = false;
        }

        // Disable root motion in case it's controlling the movement
        animator.applyRootMotion = false;

        // Find all objects with the "WayPoints" tag
        GameObject go = GameObject.FindWithTag("HalfPoints");


        // Add the transforms of the wayPoint objects to the wayPoints list
        foreach (Transform t in go.transform)
        {
            wayPoints.Add(t);
        }

        // Set the initial destination
        agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Make sure the agent has reached the destination, then set a new one
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }

        timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool("isPatrolling", false);
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
        // Stop movement when exiting the patrol state
        agent.SetDestination(agent.transform.position);
    }
}
