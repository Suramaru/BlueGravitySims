using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public Action InteractWithKeeper;

    private CoinsController coinsController;

    private void Awake()
    {
        coinsController = GetComponent<CoinsController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShopKeeper"))
            Speak();
        if (collision.CompareTag("Item"))        
            TryToBuy(collision.GetComponent<ItemBase>().Price);
    }

    public void TryToBuy(int price)
    {
        if (coinsController.Coins >= price)
            Debug.Log("Comprado");
        else
            Debug.Log("No hay plata");
    }

    public void Speak()
    {
        InteractWithKeeper?.Invoke();
    }
}
