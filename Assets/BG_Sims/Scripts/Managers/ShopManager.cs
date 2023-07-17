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

    /// <summary>
    /// Get all items in the shop
    /// </summary>
    /// <param name="_itemLibrary"></param>
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

    /// <summary>
    /// Show item price
    /// </summary>
    /// <param name="itemPrice"></param>
    /// <param name="parent"></param>
    private void OnGetPrice(int itemPrice, Transform parent)
    {
        UIPrice.SetActive(true);
        priceTxt.text = itemPrice.ToString();
        UIPrice.transform.parent = parent;
        UIPrice.transform.localPosition = new Vector3(0, .5f, 0);
    }

    /// <summary>
    /// Hide item price
    /// </summary>
    private void OnHidePrice()
    {
        UIPrice.SetActive(false);
    }
}