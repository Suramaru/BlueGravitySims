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
    [SerializeField] private MinigameManager minigameManager;

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
        playerInteractor.WithOutMoney += OnWithOutMoney;
        playerInteractor.InteractWithNPC += OnInteractWithNPC;
        playerInteractor.OpenMinigame += OnOpenMinigame;
        minigameManager.OptionSelected += OnOptionSelected;

        shopManager.Initialice(itemLibrary);
        playerCoinsController.RestartCoins();
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

    private void OnSetDialog(string dialog, UserType userType)
    {
        uIManager.SetDialogUI(dialog, userType);
    }

    private void OnBuyItem(int itemID, ItemsType itemsType)
    {
        playerVisualController.SetSpriteLibrary(itemsType, itemLibrary.GetItemSpriteLibraryById(itemID).libraryAsset);

        if (itemsType == ItemsType.Underwear)
        {
            progressManager.ActualiceMaxProgress(7);
            uIManager.SetUI(UIType.Coins);
            minigameManager.EnableMinigame();
        }
    }

    private void OnWithOutMoney()
    {
        uIManager.SetDialogUI("I don't have enough money", UserType.Player);
    }

    private void OnInteractWithNPC()
    {
        progressManager.ActualiceProgress();
    }

    private void OnOptionSelected(bool isTrue, string message, int number)
    {
        if (!isTrue)
            playerCoinsController.SubtractCoins();

        uIManager.SetMinigameResultUI(message, number);
    }

    private void OnOpenMinigame()
    {
        minigameManager.StartMinigame();
        uIManager.SetUI(UIType.Minigame);
    }
}
