using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private ItemBase[] items;

    [SerializeField] private ItemLibraryManager itemLibrary;
    [SerializeField] private TextMeshProUGUI priceTxt;
    [SerializeField] private GameObject UIPrice;

    private void Awake()
    {
        items = GetComponentsInChildren<ItemBase>();

        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetPrice += OnGetPrice;
            items[i].HidePrice += OnHidePrice;
            Debug.Log(items[i].GetID());

            items[i].SetPrice(itemLibrary.GetItemSpriteLibraryById(items[i].GetID()).itemPrice);
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