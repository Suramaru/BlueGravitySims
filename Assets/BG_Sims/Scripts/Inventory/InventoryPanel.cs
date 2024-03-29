using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public Action<int, int, ItemsType> ShowInteractionUI;

    [SerializeField] private ItemContainer itemContainer;
    [SerializeField] private InventoryBtn[] buttons;

    private int currentItem;

    /// <summary>
    /// Get inventory buttons
    /// </summary>
    public void Initialice()
    {
        buttons = GetComponentsInChildren<InventoryBtn>();

        for (int i = 0; i < itemContainer.slots.Count; i++)
            buttons[i].InteractWithItem += OnInteractWithItem;
    }

    /// <summary>
    /// Remove item after sell it
    /// </summary>
    public void RemoveItem()
    {
        for (int i = 0; i < itemContainer.slots.Count; i++)
        {
            if (itemContainer.slots[i].inventoryItem != null)
            {
                if (itemContainer.slots[i].inventoryItem.id == currentItem)
                {
                    itemContainer.slots[i].inventoryItem = null;
                    itemContainer.slots[i].count = 0;
                    itemContainer.slots[i].Id = 0;
                    Show();
                }
            }
        }

    }

    private void OnEnable()
    {
        Show();
    }

    public void CanInteract(bool isTrue)
    {
        for (int i = 0; i < itemContainer.slots.Count; i++)
            buttons[i].SetItemInteractive(isTrue);
    }

    /// <summary>
    /// Show inventory items
    /// </summary>
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

    private void OnInteractWithItem(int currentID, int value, ItemsType itemsType)
    {
        ShowInteractionUI?.Invoke(value, currentID, itemsType);
        currentItem = currentID;
    }
}
