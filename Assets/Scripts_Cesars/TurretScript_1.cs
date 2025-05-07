using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript_1 : MonoBehaviour {

    [SerializeField] private AudioClip cannonShot;
    [SerializeField] GameObject cannonballPrefab;
    [SerializeField] private int enemyPoints = 100;
    public Transform player;
    public float detectionRadius;
    public int health = 1;
    public float moveSpeed = 15;
    private GameScore gameScore;
    private Rigidbody rb;
    private GameObject cannonBall;
    public GameObject gameOverUI;
    public AudioSource BackgroundMusic;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag("Player")?.transform;
        rb = GetComponent<Rigidbody>();
        gameScore = FindObjectOfType<GameScore>();
        StartCoroutine(ShootAtPlayer());
    }

    // Update is called once per frame
    void FixedUpdate() {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= detectionRadius) { 
            Vector3 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
            transform.LookAt(player);
        }
    }


    public void TakeDamage(int damage) {
        health -= damage;
        Debug.Log("HITT");
        if (health <= 0) {
            KillEnemy();
        }
    }

    IEnumerator ShootAtPlayer() {
        while (true) { 
            yield return new WaitForSeconds(3.5f);
            if (player && Vector3.Distance(transform.position, player.position) <= detectionRadius) {
                cannonBall = Instantiate(cannonballPrefab) as GameObject;
                cannonBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                cannonBall.transform.rotation = transform.rotation;
                AudioSource.PlayClipAtPoint(cannonShot, transform.position);
                CannonBallBehavior behavior = cannonBall.GetComponent<CannonBallBehavior>();
                if (behavior != null) {
                    behavior.gameOver = gameOverUI;
                    behavior.music = BackgroundMusic;
                }
            }
        }
    }

    public void KillEnemy() {
        gameScore.hudScore(enemyPoints);
        Destroy(gameObject);
    }
}
