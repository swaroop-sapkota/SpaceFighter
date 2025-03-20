using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    public Transform PatrolRoute;
    public Transform Player;

    public List<Transform> Locations;

    private int locationIndex = 0;

    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        Player = GameObject.Find("PlayerArmature").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }


    void InitializePatrolRoute()
    {
        // no changes needed
    }

    private void Update()
    {
        if(agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
            return;
        agent.destination = Locations[locationIndex].position;

        locationIndex = (locationIndex + 1) % Locations.Count;
    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.name == "PlayerArmature")
        {
            agent.destination = Player.position;
            Debug.Log("Enemy Detected!");
        }
        // No changes needed
    }

    private void OnTriggerExit(Collider other)
    {
        // No changes needed.
    }
}
