using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Controllers")]
    [SerializeField] private PlayerController characterMovement;
    [SerializeField] private PlayerVisualController playerVisualController;
    [SerializeField] private PlayerInteractor playerInteractor;
    [SerializeField] private PlayerCoinsController playerCoinsController;

    [Header("Managers")]
    [SerializeField] private UIManager uIManager;
    [SerializeField] private ProgressManager progressManager;
    [SerializeField] private ShopManager shopManager;

    [Header("Scriptables")]
    [SerializeField] private ItemLibraryManager itemLibrary;
    [SerializeField] private Dialogs dialogs;

    private bool onGameplay;

    private void Start()
    {
        characterMovement.Initialice();
        progressManager.Initialice(dialogs);


        playerCoinsController.CoinsChanged += OnCoinsChanged;
        progressManager.SetDialog += OnSetDialog;
        playerInteractor.BuyItem += OnBuyItem;

        shopManager.Initialice(itemLibrary);
        playerCoinsController.RestartCoins();
        uIManager.SetUi(UIType.Coins);
        progressManager.DialogToSay();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            progressManager.ActualiceProgress();
    }

    private void OnCoinsChanged(int coins)
    {
        uIManager.SetCoinsToUI(coins);
    }

    private void OnSetDialog(string dialog)
    {
        uIManager.SetDialogUI(dialog);
    }

    private void OnBuyItem(int itemID, ItemsType itemsType)
    {
        playerVisualController.SetSpriteLibrary(itemsType, itemLibrary.GetItemSpriteLibraryById(itemID).libraryAsset);
    }
}
