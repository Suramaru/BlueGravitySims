using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    public Action<int> CoinsChanged;

    private int coins;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            AddCoins();
    }

    public void AddCoins()
    {
        coins++;
        CoinsChanged?.Invoke(coins);
    }

    public void RestartCoins()
    {
        coins = 0;
        CoinsChanged?.Invoke(coins);
    }
}
