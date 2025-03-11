using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    private bool isPaused = false;
    public MonoBehaviour cameraController;
    // Start is called before the first frame update
    void Start() {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Resume();
            } else {
                Paused();
            }
        }
    }

    public void Paused() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (cameraController != null) {
            cameraController.enabled = false;
        }
    } 

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (cameraController != null) {
            cameraController.enabled = true;
        }
    }

    public void Exit() {
        SceneManager.LoadScene("MainMenu");
    }
}
