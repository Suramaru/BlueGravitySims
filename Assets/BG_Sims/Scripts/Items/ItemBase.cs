using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemBase : MonoBehaviour
{
    public ItemType itemType;
    public Action<int, Transform> GetPrice;

    [SerializeField] private int itemId;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("intentando poner precio");
            GetPrice?.Invoke(itemId, gameObject.transform);
        }
    }
}