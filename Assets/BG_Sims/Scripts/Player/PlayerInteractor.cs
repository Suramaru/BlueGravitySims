using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public Action WithOutMoney;
    public Action OpenMinigame;
    public Action InteractWithNPC;
    public Action<int, ItemsType> BuyItem;

    private CoroutineHandle interactionCoroutine;
    private PlayerCoinsController coinsController;

    private bool onInteractionRange;

    private void Awake()
    {
        coinsController = GetComponent<PlayerCoinsController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShopKeeper") || collision.CompareTag("Item") || collision.CompareTag("Minigame"))
        {
            onInteractionRange = true;            
            interactionCoroutine = Timing.RunCoroutine(WaitingForInteraction(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ShopKeeper") || collision.CompareTag("Item") || collision.CompareTag("Minigame"))
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
                switch (collision.GetComponent<InteractorType>().interactorType)
                {
                    case InteractorsType.NPC:
                        Speak();
                        break;
                    case InteractorsType.Item:
                        ItemBase currentItem = collision.GetComponent<ItemBase>();
                        TryToBuy(currentItem.Price, currentItem.ItemID, currentItem.itemType);
                        break;
                    case InteractorsType.Minigame:
                        OpenMinigame?.Invoke();
                        break;
                    default:
                        break;
                }
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
            WithOutMoney?.Invoke();
    }

    private void Speak()
    {
        InteractWithNPC?.Invoke();
    }
}
