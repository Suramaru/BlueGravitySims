using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor.Search;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private ItemContainer itemContainer;
    [SerializeField] private InventoryBtn[] buttons;

    private void Awake()
    {
        buttons = GetComponentsInChildren<InventoryBtn>();

        Show();
    }

    private void OnEnable()
    {
        Show();
    }

    public void CanSell(bool isTrue)
    {
        for (int i = 0; i < itemContainer.slots.Count; i++)
            buttons[i].SetItemToSell(isTrue);
    }

    private void Show()
    {
        for (int i = 0; i < itemContainer.slots.Count; i++)
        {
            if (itemContainer.slots[i].inventoryItem == null)
                buttons[i].Clean();
            else
                buttons[i].SetItem(itemContainer.slots[i]);
        }
    }
}
