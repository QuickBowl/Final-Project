using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int coinCount = 0;
    
    // Assign a UI text element to display coin count
    public TextMeshProUGUI coinText; 

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (coinText != null)
            coinText.text = "Coins: " + coinCount;
    }
}

