using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BlueEnemyAI : MonoBehaviour
{
    [Header("References")]
    public Animator animator;
    public NavMeshAgent agent;
    private Transform player;

    [Header("State Management")]
    public EnemyState currentState = EnemyState.Idle;

    [Header("Idle Settings")]
    public float idleDuration = 5f;
    private float idleTimer = 0f;

    [Header("Detection Ranges")]
    public float chaseRange = 8f;
    public float attackRange = 2.5f;
    public float maxChaseDistance = 15f;

    [Header("Patrol Settings")]
    public List<Transform> patrolPoints;
    private Transform currentDestination;

    void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;

        // Find all objects with the "WayPoints" tag
        GameObject go = GameObject.FindWithTag("MaterialThree");
        // Add the transforms of the wayPoint objects to the wayPoints list
        if (go != null && patrolPoints.Count == 0)
        {
            foreach (Transform t in go.transform)
            {
                patrolPoints.Add(t);
            }
        }

        PickRandomPatrolPoint();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case EnemyState.Idle:
                HandleIdleState(distance);
                break;

            case EnemyState.Patrol:
                HandlePatrolState(distance);
                break;

            case EnemyState.Chase:
                HandleChaseState(distance);
                break;

            case EnemyState.Attack:
                HandleAttackState(distance);
                break;
        }
    }

    void HandleIdleState(float distance)
    {
        idleTimer += Time.deltaTime;
        animator.SetBool("isPatrolling", false);
        animator.SetBool("isChasing", false);
        animator.SetBool("isAttacking", false);

        if (distance < chaseRange)
        {
            ChangeState(EnemyState.Chase);
        }
        else if (idleTimer >= idleDuration)
        {
            idleTimer = 0f;
            ChangeState(EnemyState.Patrol);
        }
    }

    void HandlePatrolState(float distance)
    {
        animator.SetBool("isPatrolling", true);

        if (patrolPoints.Count == 0) return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            PickRandomPatrolPoint();
        }

        if (distance < chaseRange)
        {
            ChangeState(EnemyState.Chase);
        }
    }

    void HandleChaseState(float distance)
    {
        animator.SetBool("isChasing", true);
        agent.SetDestination(player.position);

        if (distance > maxChaseDistance)
        {
            ChangeState(EnemyState.Idle);
        }
        else if (distance <= attackRange)
        {
            ChangeState(EnemyState.Attack);
        }
    }

    void HandleAttackState(float distance)
    {
        agent.SetDestination(transform.position);  // stop movement
        transform.LookAt(player);
        animator.SetBool("isAttacking", true);

        // Optional: play sound
        // AudioManager.instance.Play("DragonAttack");

        if (distance > attackRange)
        {
            ChangeState(EnemyState.Chase);
        }
    }

    void PickRandomPatrolPoint()
    {
        if (patrolPoints.Count == 0) return;

        currentDestination = patrolPoints[Random.Range(0, patrolPoints.Count)];
        agent.SetDestination(currentDestination.position);
    }

    void ChangeState(EnemyState newState)
    {
        currentState = newState;
    }

}
