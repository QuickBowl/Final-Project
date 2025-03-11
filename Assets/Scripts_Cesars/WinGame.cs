using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour {
    public GameObject youWin;
    // Start is called before the first frame update
    void Start() {
        youWin.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }
    public void Restart() {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
    public void ExitGame() {
        SceneManager.LoadScene("MainMenu");
    }
}
