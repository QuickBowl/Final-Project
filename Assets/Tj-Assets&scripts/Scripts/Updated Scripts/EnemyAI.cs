using UnityEngine;
using System; // Required for event handling

public class EnemyAI : MonoBehaviour
{
    public static event Action<GameObject> OnEnemyKilled; // Event to notify when an enemy dies

    public Transform player;
    private UnityEngine.AI.NavMeshAgent agent;
    public int health = 3;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnEnemyKilled?.Invoke(gameObject); // Notify EnemyManager if subscribed
            Destroy(gameObject);
        }
    }
}
