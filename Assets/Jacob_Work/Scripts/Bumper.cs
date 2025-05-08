using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] float bounceAmount = 300f;

    private void OnTriggerEnter(Collider other)
    {
        // if other collider is player then reaction should occur
        if (other.gameObject.CompareTag("Player"))
        {
            //get rigidbody
            Rigidbody playerRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Debug.Log("Entered");

            // if we find it, apply force
            if (playerRigidbody != null)
            {
                Debug.Log("Found player rigidbody");
                // get player velocity
                Vector3 bounceDirection = playerRigidbody.velocity;
                //apply force
                playerRigidbody.AddForce(bounceDirection * bounceAmount);

            }
          
        }
    }
}
