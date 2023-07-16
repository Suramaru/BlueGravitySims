using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDUI : UIBase
{
    public Action OpenInventoryUI;
    public Action CloseInventoryUI;

    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private Button inventoryBtn;

    protected override void Awake()
    {
        base.Awake();
    }

    public void SetCoinsUI(float currentScore)
    {
        coinsText.text = "x" + currentScore.ToString();
        inventoryBtn.onClick.AddListener(OpenInventory);
    }

    private void OpenInventory()
    {
        OpenInventoryUI?.Invoke();
        inventoryBtn.onClick.RemoveListener(OpenInventory);
        inventoryBtn.onClick.AddListener(CloseInventory);
    }

    private void CloseInventory()
    {
        CloseInventoryUI?.Invoke();
        inventoryBtn.onClick.RemoveListener(CloseInventory);
        inventoryBtn.onClick.AddListener(OpenInventory);
    }
}
