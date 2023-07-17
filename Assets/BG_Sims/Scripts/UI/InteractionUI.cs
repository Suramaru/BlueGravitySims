using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : UIBase
{
    public Action<int, ItemsType> ItemSelled;
    public Action<int, ItemsType> ItemEquiped;

    [SerializeField] private Button sellBtn;
    [SerializeField] private Button equipBtn;

    private int valueToSell;
    private int itemID;
    private ItemsType itemType;

    protected override void Awake()
    {
        sellBtn.onClick.AddListener(SellItem);
        equipBtn.onClick.AddListener(EquipItem);
    }

    public void ShowItemInteracion(int value, int _itemID, ItemsType itemsType)
    {
        valueToSell = value;
        itemID = _itemID;
        itemType = itemsType;
    }

    private void SellItem()
    {
        ItemSelled?.Invoke(valueToSell, itemType);
        Show(false);
    }

    private void EquipItem()
    {
        ItemEquiped?.Invoke(itemID, itemType);
        Show(false);
    }
}
