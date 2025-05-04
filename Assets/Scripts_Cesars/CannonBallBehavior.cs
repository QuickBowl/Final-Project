using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehavior : MonoBehaviour {
    public float speed = 2f;
    public GameObject gameOver;
    public AudioSource music;

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, 3.5f);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
            gameOver.SetActive(true);
            Time.timeScale = 0f;
            music.Stop();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
