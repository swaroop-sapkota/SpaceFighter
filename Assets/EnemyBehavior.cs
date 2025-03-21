using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using System;

public class EnemyBehavior : MonoBehaviour
{
    public Transform PatrolRoute;
    public Transform Player;
    public List<Transform> Locations;

    private int locationIndex = 0;
    private NavMeshAgent agent;

    // ✅ Health properties
    public int maxHealth = 100;

    [SerializeField] private int currentHealth; //  Now visible in Inspector

    //  Event triggered when enemy is killed
    public static event Action OnEnemyKilled;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("PlayerArmature").transform;
        currentHealth = maxHealth; //  Initialize health

        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    void InitializePatrolRoute()
    {
        // No changes needed
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
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
        if (other.name == "PlayerArmature")
        {
            agent.destination = Player.position;
            Debug.Log("Enemy Detected!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // No changes needed.
    }

    // Public method to apply damage to the enemy
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage, health now {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Handles the enemy's death
    void Die()
    {
        Debug.Log($"{gameObject.name} has been killed.");
        OnEnemyKilled?.Invoke(); // Notify UI Manager
        Destroy(gameObject); // 
    }
}
