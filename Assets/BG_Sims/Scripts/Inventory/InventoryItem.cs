using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsInventory", menuName = "ScriptableObjects/ItemsInventory", order = 3)]
public class InventoryItem : ScriptableObject
{
    public string objectName;
    public bool equippable;
    public bool stackable;
    public Sprite icon;
    public int id;
    public ItemsType itemsType;
}