using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int maxEnemies = 5;
    public static int enemiesKilled = 0;
    public int enemiesToSpawnForBoss = 10;

    private int currentEnemies = 0;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 3f);
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("Spawn Points array is empty! Assign spawn points in the Inspector.");
            return;
        }

        if (currentEnemies >= maxEnemies)
        {
            Debug.Log("Max enemies reached!");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform chosenSpawnPoint = spawnPoints[randomIndex];

        Instantiate(enemyPrefab, chosenSpawnPoint.position, Quaternion.identity);
        currentEnemies++;  // Track the number of spawned enemies
    }
}


