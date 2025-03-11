using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int damage = 1;
    public float attackRange = 2f;
    public LayerMask enemyLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left Mouse Click
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.GetComponent<EnemyAI>())
            {
                enemy.GetComponent<EnemyAI>().TakeDamage(damage);
            }
            if (enemy.GetComponent<BossAI>())
            {
                enemy.GetComponent<BossAI>().TakeDamage(damage);
            }
        }
    }
}
