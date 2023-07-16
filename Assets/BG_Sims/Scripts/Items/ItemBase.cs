using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemBase : MonoBehaviour
{
    public ItemType itemType;
    public Action<int, Transform> GetPrice;
    public Action HidePrice;

    [SerializeField] private int itemId;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            GetPrice?.Invoke(itemId, gameObject.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            HidePrice?.Invoke();
    }
}