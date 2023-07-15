using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private ItemBase[] items;

    [SerializeField] private ItemLibrary itemLibrary;
    [SerializeField] private TextMeshProUGUI priceTxt;
    [SerializeField] private GameObject UIPrice;

    private void Awake()
    {
        items = GetComponentsInChildren<ItemBase>();

        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetPrice += OnGetPrice;
        }
    }

    private void OnGetPrice(int itemID, Transform parent)
    {
        priceTxt.text = itemLibrary.GetItemSpriteLibraryById(itemID).itemPrice.ToString();
        UIPrice.transform.parent = parent;
        UIPrice.transform.localPosition = new Vector3(0, .5f, 0);
    }
}