using System;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public Action<int, Transform> GetPrice;
    public Action HidePrice;

    [SerializeField] private int itemID;
    private int price;

    public int Price
    {
        get { return price; }
        private set { price = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            GetPrice?.Invoke(Price, gameObject.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            HidePrice?.Invoke();
    }

    public void SetPrice(int _price)
    {
        Price = _price;
    }

    public int GetID()
    {
        return itemID;
    }
}