using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemBase : MonoBehaviour
{
    public ItemType itemType;

    [SerializeField] private int itemId;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowPrice();
        }
    }

    private void ShowPrice()
    {

    }
}
