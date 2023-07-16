using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public Action InteractWithNPC;
    public Action<int, ItemsType> BuyItem;

    private PlayerCoinsController coinsController;
    private CoroutineHandle interactionCoroutine;

    private bool onInteractionRange;

    private void Awake()
    {
        coinsController = GetComponent<PlayerCoinsController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShopKeeper") || collision.CompareTag("Item"))
        {
            onInteractionRange = true;
            interactionCoroutine = Timing.RunCoroutine(WaitingForInteraction(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ShopKeeper") || collision.CompareTag("Item"))
        {
            onInteractionRange = false;
            Timing.KillCoroutines(interactionCoroutine);
        }
    }

    private IEnumerator<float> WaitingForInteraction(Collider2D collision)
    {
        while (onInteractionRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (collision.GetComponent<InteractorType>().interactorType == InteractorsType.Item)
                {
                    ItemBase currentItem = collision.GetComponent<ItemBase>();
                    TryToBuy(currentItem.Price, currentItem.ItemID, currentItem.itemType);
                }
                else
                    Speak();
            }
            yield return 0f;
        }
    }

    private void TryToBuy(int price, int itemID, ItemsType itemsType)
    {
        if (coinsController.Coins >= price)
        {
            BuyItem?.Invoke(itemID, itemsType);
            coinsController.SubtractCoins(price);
        }
        else
            Debug.Log("No hay plata");
    }

    private void Speak()
    {
        InteractWithNPC?.Invoke();
    }
}
