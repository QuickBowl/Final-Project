using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

    public GameObject gameOverScreen;
    //private bool isPaused = false;
    // Start is called before the first frame update
    void Start() {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Restart() {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
    public void Exit() {
        Application.Quit();
    }
}
