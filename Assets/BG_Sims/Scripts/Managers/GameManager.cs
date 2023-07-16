using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController characterMovement;
    [SerializeField] private CoinsController coinsController;
    [SerializeField] private UIManager uIManager;

    private bool onGameplay;

    private void Start()
    {
        characterMovement.Initialice();
        coinsController.CoinsChanged += OnCoinsChanged;

        coinsController.RestartCoins();
        uIManager.SetUi(UIType.Coins);
    }

    private void OnCoinsChanged(int coins)
    {
        uIManager.SetCoinsToUI(coins);
    }
}
