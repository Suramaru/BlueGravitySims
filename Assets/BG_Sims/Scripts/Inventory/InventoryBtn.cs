using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBtn : MonoBehaviour
{
    public Action SellItem;

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI text;

    private Button itemBtn;
    private bool inRangeToSell;

    private void Awake()
    {
        itemBtn.onClick.AddListener(SellCurrentItem);
    }

    public void SetItemToSell(bool isTrue)
    {
        inRangeToSell = isTrue;
    }

    public void SetItem(ItemSlot itemSlot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = itemSlot.inventoryItem.icon;

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
        icon.sprite = null;
        icon.gameObject.SetActive(false);

        text.gameObject.SetActive(false);
    }

    private void SellCurrentItem()
    {
        if(inRangeToSell)
            SellItem?.Invoke();
    }
}
