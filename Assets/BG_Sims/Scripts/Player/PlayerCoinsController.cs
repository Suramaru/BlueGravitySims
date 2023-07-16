using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinsController : MonoBehaviour
{
    public Action<int> CoinsChanged;

    private int coins;

    public int Coins
    {
        get { return coins; }
        private set
        {
            if(coins <= 0)
                coins = 0;

            coins = value;
            CoinsChanged?.Invoke(coins);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            AddCoins();
    }

    public void SubtractCoins(int value)
    {
        Coins -= value;
    }

    public void SubtractCoins()
    {
        Coins--;
    }

    public void AddCoins(int value)
    {
        Coins += value;
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
