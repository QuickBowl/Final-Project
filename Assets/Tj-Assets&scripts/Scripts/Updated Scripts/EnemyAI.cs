using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Required for event handling

public class EnemyAI : MonoBehaviour
{
    public static event System.Action<GameObject> OnEnemyKilled; // Event to notify when an enemy dies
    public Transform player;
    public int health = 1;
    private Rigidbody rigidBody;
    public float moveSpeed = 3.0f;
    public float detectionRadius = 10.0f;
    [SerializeField] private int enemyPoints = 50;
    private GameScore gameScore;
    [SerializeField] private AudioClip slimeDies;

    void Start() {
        player = GameObject.FindWithTag("Player")?.transform;
        rigidBody = GetComponent<Rigidbody>();
        gameScore = FindObjectOfType<GameScore>();

    }

    void Update() {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRadius) {
            Vector3 direction = (player.position - transform.position).normalized;
            rigidBody.MovePosition(rigidBody.position + direction * moveSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            KillEnemy();
        }
    }
    public void KillEnemy() {
        OnEnemyKilled?.Invoke(gameObject);
        gameScore.hudScore(enemyPoints);
        AudioSource.PlayClipAtPoint(slimeDies, transform.position);
        Destroy(gameObject);
    }
}