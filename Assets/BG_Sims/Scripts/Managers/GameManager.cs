using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

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
    [SerializeField] private SpriteLibraryAsset baseAsset;

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
        inventoryPanel.ShowInteractionUI += OnShowInteractionUI;
        uIManager.ItemSelled += OnItemSelled;
        uIManager.ItemEquiped += OnItemEquiped;

        shopManager.Initialice(itemLibrary);
        playerCoinsController.RestartCoins();
    }

    private void OnCoinsChanged(int coins)
    {
        uIManager.SetCoinsToUI(coins);
    }    
    
    private void OnItemSelled(int coins, ItemsType itemsType)
    {
        if(itemsType != ItemsType.None)
            playerVisualController.SetSpriteLibrary(itemsType);

        inventoryPanel.RemoveItem();
        playerCoinsController.AddCoins(coins);
    }    
    
    private void OnItemEquiped(int ItemID, ItemsType itemsType)
    {
        if(itemsType != ItemsType.None)
            playerVisualController.SetSpriteLibrary(itemsType, itemLibrary.GetItemSpriteLibraryById(ItemID).libraryAsset);
    }

    private void OnSetDialog(string dialog, UserType userType)
    {
        uIManager.SetDialogUI(dialog, userType);
    }

    private void OnBuyItem(int itemID, ItemsType itemsType, InventoryItem inventoryItem)
    {
        if (itemsType == ItemsType.None)
        {
            playerVisualController.SetSpriteLibrary(itemsType, itemLibrary.GetItemSpriteLibraryById(itemID).libraryAsset);
            progressManager.ActualiceMaxProgress(8);
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

    private void OnShowInteractionUI(int value, int _itemID, ItemsType itemsType)
    {
        uIManager.ShowInteractionUI(value, _itemID, itemsType);
    }
}
