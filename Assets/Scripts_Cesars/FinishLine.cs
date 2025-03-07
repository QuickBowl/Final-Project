using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {
    public GameObject player;
    public GameObject YouWin;
    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {

            YouWin.SetActive(YouWin);
            Time.timeScale = 0f;

        }
    }
}
