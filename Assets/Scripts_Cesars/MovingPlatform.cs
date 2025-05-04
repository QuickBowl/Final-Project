using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public float speed;
    public Transform[] points;
    public GameObject player;
    public GameObject platform;
    private int current = 0;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void FixedUpdate() {
        PlatformMoves();
    }


    void PlatformMoves() {
        Transform target = points[current];
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(platform.transform.position, target.position) < 0.01f) {
            ++current;
            if (current >= points.Length) {
                current = 0;
            }

        }
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            Debug.Log("Player is On");
            other.transform.SetParent(platform.transform);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject == player) {
            Debug.Log("Player is off");
            other.transform.SetParent(null);
        }
    }
}
