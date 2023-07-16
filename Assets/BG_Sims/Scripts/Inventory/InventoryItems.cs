using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsInventory", menuName = "ScriptableObjects/ItemsInventory", order = 3)]
public class InventoryItems : ScriptableObject
{
    [SerializeField] private ItemEntry[] items;
}

[System.Serializable]
public class ItemEntry
{
    [SerializeField] private string objectName;
    [SerializeField] private bool equippable;
    [SerializeField] private bool stackable;
    [SerializeField] private Sprite icon;
}