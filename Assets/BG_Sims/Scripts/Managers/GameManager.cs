using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController characterMovement;
    [SerializeField] private CoinsController coinsController;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private ProgressManager progressManager;

    private bool onGameplay;

    private void Start()
    {
        characterMovement.Initialice();
        coinsController.CoinsChanged += OnCoinsChanged;
        progressManager.SetDialog += OnSetDialog;

        coinsController.RestartCoins();
        uIManager.SetUi(UIType.Coins);
    }

    private void OnCoinsChanged(int coins)
    {
        uIManager.SetCoinsToUI(coins);
    }

    private void OnSetDialog(string dialog)
    {
        uIManager.SetDialogUI(dialog);
    }
}
