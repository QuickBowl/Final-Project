using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour {
    public float timer = 80f;
    public TMP_Text timerText;
    public AudioSource music;
    public GameObject gameOverScreen;
    [SerializeField] private GameScore gameScore;

    // Update is called once per frame
    void Update() {
        if (timer > 0) {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.CeilToInt(timer).ToString() + " s";
            gameScore.ScoreKeeper();
            gameScore.WinScore();
        } else {
            if (!gameOverScreen.activeSelf) {
                gameOverScreen.SetActive(true);
                music.Stop();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
