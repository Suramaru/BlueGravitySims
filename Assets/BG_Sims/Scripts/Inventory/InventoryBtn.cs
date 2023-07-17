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

    public void SetItemToSell(bool isTrue)
    {
        inRangeToSell = isTrue;
    }

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

    public void Clean()
    {
        itemBtn.interactable = false;

        icon.sprite = null;
        icon.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    private void Interaction()
    {
        if (inRangeToSell)
            InteractWithItem?.Invoke(iD, valueToSell, itemsType);
    }
}