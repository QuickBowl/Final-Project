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
        // Implement Win condition, like once player makes it into one place/grabs somthing, win screen pops up
    }
    public void Restart() {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame() {
        Application.Quit();
    }
}
