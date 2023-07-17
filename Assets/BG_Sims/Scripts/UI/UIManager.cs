using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Action<int, ItemsType> ItemSelled;
    public Action<int, ItemsType> ItemEquiped;

    [SerializeField] private HUDUI HUDUI;
    [SerializeField] private DialogUI dialogUI;
    [SerializeField] private MinigameUI minigameUI;
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private InteractionUI interactionUI;

    private void Awake()
    {
        HUDUI.OpenInventoryUI += OnOpenInventory;
        HUDUI.CloseInventoryUI += OnCloseInventory;
        interactionUI.ItemSelled += OnItemSelled;
        interactionUI.ItemEquiped += OnItemEquiped;
    }

    public void SetUI(UIType currentType)
    {
        switch (currentType)
        {
            case UIType.Minigame:
                minigameUI.Show(true);
                break;
            case UIType.Coins:
                HUDUI.Show(true);
                break;
            case UIType.Dialog:
                dialogUI.Show(true);
                break;
            case UIType.Inventory:
                inventoryUI.Show(true);
                break;
            case UIType.Interaciton:
                interactionUI.Show(true);
                break;
            default:
                break;
        }
    }

    public void SetDialogUI(string dialog, UserType userType)
    {
        LeanTween.cancelAll();
        dialogUI.SetDialog(dialog, userType);
        SetUI(UIType.Dialog);
    }

    public void SetCoinsToUI(float score)
    {
        HUDUI.SetCoinsUI(score);
    }

    public void SetMinigameResultUI(string dialog, int number)
    {
        minigameUI.ShowMessages(dialog, number);
        SetUI(UIType.Dialog);
    }

    public void ShowInteractionUI(int value, int _itemID, ItemsType itemsType)
    {
        interactionUI.ShowItemInteracion(value, _itemID, itemsType);
        SetUI(UIType.Interaciton);
    }

    private void OnOpenInventory()
    {
        SetUI(UIType.Inventory);
    }

    private void OnCloseInventory()
    {
        inventoryUI.Show(false);
    }

    private void OnItemSelled(int value,ItemsType itemsType)
    {
        ItemSelled?.Invoke(value, itemsType);
    }    
    
    private void OnItemEquiped(int value, ItemsType itemsType)
    {
        ItemEquiped?.Invoke(value, itemsType);
    }
}