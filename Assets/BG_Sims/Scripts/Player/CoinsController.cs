using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    public Action<int> CoinsChanged;

    private int coins;

    public int Coins
    {
        get { return coins; }
        private set
        {
            coins = value;
            CoinsChanged?.Invoke(coins);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            AddCoins();
    }

    public void AddCoins()
    {
        Coins++;
    }

    public void RestartCoins()
    {
        Coins = 0;
    }
}
