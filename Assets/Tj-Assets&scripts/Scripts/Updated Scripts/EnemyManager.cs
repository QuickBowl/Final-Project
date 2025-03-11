using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    //public Transform[] spawnPoints;
    private List<GameObject> activeEnemies = new List<GameObject>();
    public GameObject door;

    void Start()
    {
        activeEnemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        EnemyAI.OnEnemyKilled += RemoveEnemy; // Subscribe to enemy death event
        //SpawnEnemies();
    }

    void OnDestroy()
    {
        EnemyAI.OnEnemyKilled -= RemoveEnemy; // Unsubscribe to prevent memory leaks
    }

    void SpawnEnemies()
    {
        //foreach (Transform spawnPoint in spawnPoints)
        //{
          //  GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            //activeEnemies.Add(enemy);
        //}
    }


    void RemoveEnemy(GameObject enemy) {
       if (activeEnemies.Contains(enemy)) {
            activeEnemies.Remove(enemy);
            Debug.Log("Enemy Defeated!");
        }
        if (activeEnemies.Count == 0)
        {
            Debug.Log("Round Over! All enemies defeated.");
            Destroy(door);

        }
    }
}
