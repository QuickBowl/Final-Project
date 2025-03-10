using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameScore : MonoBehaviour {
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private GameTimer timeLeft;
    //[SerializeField] private coinPoints;
    //[SerializeField] private enemyPoints;
    private int score;
    private int finalScore;

    public void Start() {
        score = 0;
        UpdateScore();
    }

    public void ScoreKeeper() {
        // this is where the amount of coins and time will multiply
        float time = timeLeft.timer;
        finalScore = (int)time;
    }
    public void hudScore() {
        //score = coinPoints + enemyPoints;
        //UpdateScore();
    }

    public void WinScore() {
        ScoreKeeper();
        finalScoreText.text = "Final Score: " + finalScore.ToString();
    }

    public void UpdateScore() {
        scoreText.text = "Score: " + score.ToString();
    }
}
