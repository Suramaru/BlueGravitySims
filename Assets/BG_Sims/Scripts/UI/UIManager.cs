using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Action StartGame;
    public Action CountDownFinish;

    [SerializeField] private HUDUI HUDUI;
    [SerializeField] private MinigameUI minigameUI;
    [SerializeField] private DialogUI dialogUI;
    [SerializeField] private InventoryUI inventoryUI;

    private void Awake()
    {
        HUDUI.OpenInventoryUI += OnOpenInventory;
        HUDUI.CloseInventoryUI += OnCloseInventory;
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

    private void OnOpenInventory()
    {
        SetUI(UIType.Inventory);
    }

    private void OnCloseInventory()
    {
        inventoryUI.Show(false);
    }
}