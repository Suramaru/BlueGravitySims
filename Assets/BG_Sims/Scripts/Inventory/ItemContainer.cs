using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsContainer", menuName = "ScriptableObjects/ItemsContainer", order = 4)]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots = new();

    public void AddItemToInventory(InventoryItem inventoryItem, int count = 1)
    {
        if (inventoryItem.stackable)
        {
            ItemSlot itemSlot = slots.Find(x => x.inventoryItem == inventoryItem);
            if (itemSlot != null)
                itemSlot.count += count;
            else
            {
                itemSlot = slots.Find(x => x.inventoryItem == null);
                if (itemSlot != null)
                {
                    itemSlot.inventoryItem = inventoryItem;
                    itemSlot.count = count;
                }
            }
            itemSlot.Id = inventoryItem.id;
        }
        else
        {
            ItemSlot itemSlot = slots.Find(x => x.inventoryItem == null);
            if (itemSlot != null)
                itemSlot.inventoryItem = inventoryItem;

            itemSlot.Id = inventoryItem.id;
            itemSlot.itemsType = inventoryItem.itemsType;
        }
    }
}

[Serializable]
public class ItemSlot
{
    public InventoryItem inventoryItem;
    public int count;
    public int Id;
    public ItemsType itemsType;
}
