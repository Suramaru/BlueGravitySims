using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI priceTxt;
    [SerializeField] private GameObject UIPrice;

    private ItemBase[] items;
    private ItemLibraryManager itemLibrary;

    private void Awake()
    {
        items = GetComponentsInChildren<ItemBase>();
    }

    public void Initialice(ItemLibraryManager _itemLibrary)
    {
        itemLibrary = _itemLibrary;

        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetPrice += OnGetPrice;
            items[i].HidePrice += OnHidePrice;
            items[i].SetPrice(itemLibrary.GetItemSpriteLibraryById(items[i].ItemID).itemPrice);
        }
    }

    private void OnGetPrice(int itemPrice, Transform parent)
    {
        UIPrice.SetActive(true);
        priceTxt.text = itemPrice.ToString();
        UIPrice.transform.parent = parent;
        UIPrice.transform.localPosition = new Vector3(0, .5f, 0);
    }

    private void OnHidePrice()
    {
        UIPrice.SetActive(false);
    }
}