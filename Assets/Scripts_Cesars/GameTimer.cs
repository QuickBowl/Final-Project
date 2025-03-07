using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour {
    public float timer = 60f;
    public TMP_Text timerText;
    public GameObject gameOverScreen;

    // Update is called once per frame
    void Update() {
        if (timer > 0) {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.CeilToInt(timer).ToString() + " s";
        } else {
            if (!gameOverScreen.activeSelf) {
                gameOverScreen.SetActive(true);
            }
        }
    }
}
