using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameScore : MonoBehaviour {
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private GameTimer timeLeft;
    private int score;
    private int finalScore;
    private int coinPoints;

    public void Start() {
        score = 0;
        coinPoints = 0;
        UpdateScore();
    }
    public void hudScore(int amount) {
        score += amount;
        coinPoints += amount;
        UpdateScore();
    }

    public void ScoreKeeper() {
        float time = timeLeft.timer;
        finalScore = (int)time * coinPoints;
    }

    public void WinScore() {
        ScoreKeeper();
        finalScoreText.text = "Final Score: " + finalScore.ToString();
    }

    public void UpdateScore() {
        scoreText.text = "Score: " + score.ToString();
    }
}
