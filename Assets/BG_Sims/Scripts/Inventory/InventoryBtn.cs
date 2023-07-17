using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBtn : MonoBehaviour
{
    public Action<int, int, ItemsType> InteractWithItem;

    public int ValueToSell
    {
        get { return valueToSell; }
        private set { valueToSell = value; }
    }

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button itemBtn;

    private int valueToSell;
    private bool inRangeToSell;
    private int iD;
    private ItemsType itemsType;

    private void Awake()
    {
        itemBtn = GetComponent<Button>();
        itemBtn.onClick.AddListener(Interaction);
    }

    /// <summary>
    /// Enable possibiliy to interact
    /// </summary>
    /// <param name="isTrue"></param>
    public void SetItemInteractive(bool isTrue)
    {
        inRangeToSell = isTrue;
    }

    /// <summary>
    /// Add a item to the inventory 
    /// </summary>
    /// <param name="itemSlot"></param>
    public void SetItem(ItemSlot itemSlot)
    {
        itemBtn.interactable = true;

        iD = itemSlot.Id;
        itemsType = itemSlot.itemsType;
        icon.gameObject.SetActive(true);
        icon.sprite = itemSlot.inventoryItem.icon;
        valueToSell = itemSlot.count + 1;

        if (itemSlot.inventoryItem.stackable)
        {
            text.gameObject.SetActive(true);
            text.text = itemSlot.count.ToString();
        }
        else
            text.gameObject.SetActive(false);
    }

    /// <summary>
    /// Remove object from the inventory
    /// </summary>
    public void Clean()
    {
        itemBtn.interactable = false;

        icon.sprite = null;
        icon.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    /// <summary>
    /// Interact
    /// </summary>
    private void Interaction()
    {
        if (inRangeToSell)
            InteractWithItem?.Invoke(iD, valueToSell, itemsType);
    }
}