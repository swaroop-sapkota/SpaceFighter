using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.Pool;
using Unity.VisualScripting;

public class EnemyBehavior : MonoBehaviour
{

    public Transform PatrolRoute;
    public Transform Player;

    public List<Transform> Locations;

    private int locationIndex = 0;

    private NavMeshAgent agent;


    //public void SetPool(IObjectPool<Enemy> pool)
    //{
    //    enemyPool = pool;
    //}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        Player = GameObject.Find("PlayerArmature").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    public void Die()
    {
        Destroy(gameObject);
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

            //enemyPool.Release(this);
        }
        // No changes needed
    }

    private void OnTriggerExit(Collider other)
    {
        // No changes needed.
    }
}
