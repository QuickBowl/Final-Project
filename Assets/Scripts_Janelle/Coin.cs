using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Value of each coin
    [SerializeField] private int coinValue = 1; 

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        CoinManager coinManager = FindObjectOfType<CoinManager>();

        if (!other.CompareTag("Player"))
        {
            Debug.LogWarning("The object colliding is NOT tagged as 'Player'. Current tag: " + other.tag);
        }
        if (coinManager == null)
        {
            Debug.LogError("CoinManager is NULL! Make sure CoinManager is in the scene and active.");
        }

        if (other.CompareTag("Player") && coinManager != null)
        {
            Debug.Log("Player collected the coin! Destroying coin...");
            coinManager.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}

