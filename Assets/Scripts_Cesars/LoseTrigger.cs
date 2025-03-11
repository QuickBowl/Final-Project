using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour {
    public GameObject player;
    public GameObject gameOver;
    public AudioSource music;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            gameOver.SetActive(gameOver);
            Time.timeScale = 0f;
            music.Stop();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if(other.CompareTag("Enemy")) {
            EnemyAI enemyAI = other.GetComponent<EnemyAI>();
            if (enemyAI != null) {
                enemyAI.KillEnemy();
            }
        }    
    }
}
