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
    [SerializeField] private InventoryPanel inventoryPanel;

    [Header("Scriptables")]
    [SerializeField] private ItemLibraryManager itemLibrary;
    [SerializeField] private Dialogs dialogs;
    [SerializeField] private ItemContainer itemContainer;

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
        playerInteractor.CanSellItems += OnCanSellItems;
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

    private void OnBuyItem(int itemID, ItemsType itemsType, InventoryItem inventoryItem)
    {
        if (itemsType == ItemsType.Underwear)
        {
            playerVisualController.SetSpriteLibrary(itemsType, itemLibrary.GetItemSpriteLibraryById(itemID).libraryAsset);
            progressManager.ActualiceMaxProgress(7);
            uIManager.SetUI(UIType.Coins);
            minigameManager.EnableMinigame();
        }
        else
            itemContainer.AddItemToInventory(inventoryItem);
    }

    private void OnWithOutMoney()
    {
        uIManager.SetDialogUI("I don't have enough money", UserType.Player);
    }

    private void OnInteractWithNPC()
    {
        progressManager.ActualiceProgress();
    }

    private void OnOptionSelected(bool isTrue, string message, int number, InventoryItem inventoryItem)
    {
        if (!isTrue)
            playerCoinsController.SubtractCoins();
        else
            itemContainer.AddItemToInventory(inventoryItem, 10);

        uIManager.SetMinigameResultUI(message, number);
    }

    private void OnOpenMinigame()
    {
        minigameManager.StartMinigame();
        uIManager.SetUI(UIType.Minigame);
    }

    private void OnCanSellItems(bool isTrue)
    {
        inventoryPanel.CanSell(isTrue);
    }
}
