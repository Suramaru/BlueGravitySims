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
    public Action<bool> CanSellItems;
    public Action<int, ItemsType, InventoryItem> BuyItem;

    [SerializeField] private GameObject interactorGuide;

    private CoroutineHandle interactionCoroutine;
    private PlayerCoinsController coinsController;

    private bool onInteractionRange;

    private void Awake()
    {
        coinsController = GetComponent<PlayerCoinsController>();
        interactorGuide.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShopKeeper") || collision.CompareTag("Item") || collision.CompareTag("Minigame"))
        {
            interactorGuide.SetActive(true);
            onInteractionRange = true;
            interactionCoroutine = Timing.RunCoroutine(WaitingForInteraction(collision));
        }

        if (collision.CompareTag("ShopKeeper"))
            CanSellItems?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ShopKeeper") || collision.CompareTag("Item") || collision.CompareTag("Minigame"))
        {
            onInteractionRange = false;
            CanSellItems?.Invoke(false);
            Timing.KillCoroutines(interactionCoroutine);
            interactorGuide.SetActive(false);
        }
    }

    /// <summary>
    /// Wait for player interactiion
    /// </summary>
    /// <param name="collision"></param>
    /// <returns></returns>
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
                        TryToBuy(currentItem.Price, currentItem.ItemID, currentItem.itemType, currentItem.InventoryItem);
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

    /// <summary>
    /// Try to buy a item
    /// </summary>
    /// <param name="price"></param>
    /// <param name="itemID"></param>
    /// <param name="itemsType"></param>
    /// <param name="inventoryItem"></param>
    private void TryToBuy(int price, int itemID, ItemsType itemsType, InventoryItem inventoryItem)
    {
        if (coinsController.Coins >= price)
        {
            BuyItem?.Invoke(itemID, itemsType, inventoryItem);
            coinsController.SubtractCoins(price);
        }
        else
            WithOutMoney?.Invoke();
    }


    /// <summary>
    /// Interact with npc
    /// </summary>
    private void Speak()
    {
        InteractWithNPC?.Invoke();
    }
}
