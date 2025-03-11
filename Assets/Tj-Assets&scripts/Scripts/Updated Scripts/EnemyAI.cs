using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Required for event handling

public class EnemyAI : MonoBehaviour
{
    public static event Action<GameObject> OnEnemyKilled; // Event to notify when an enemy dies

    public Transform player;
    //private UnityEngine.AI.NavMeshAgent agent;
    public int health = 3;
    private Rigidbody rb;
    public float moveSpeed = 3.0f;
    public float detectionRadius = 10.0f;

    void Start() {
        player = GameObject.FindWithTag("Player")?.transform;
        rb = GetComponent<Rigidbody>();

    }

    void Update() {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRadius) {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            OnEnemyKilled?.Invoke(gameObject); // Notify EnemyManager if subscribed
            Destroy(gameObject);
        }
    }
}
