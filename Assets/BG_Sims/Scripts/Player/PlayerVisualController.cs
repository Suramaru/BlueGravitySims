using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class PlayerVisualController : MonoBehaviour
{
    [SerializeField] private SpriteLibrary clothSpriteLibrary;
    [SerializeField] private SpriteLibrary HairSpriteLibrary;
    [SerializeField] private SpriteLibrary HatSpriteLibrary;
    [SerializeField] private SpriteLibraryAsset baseLibrary;

    [SerializeField] private Image clothSpriteLibraryUI;
    [SerializeField] private Image HairSpriteLibraryUI;
    [SerializeField] private Image HatSpriteLibraryUI;
    [SerializeField] private Sprite baseImage;

    private Sprite spriteToSet;
    private Dictionary<ItemsType, SpriteLibrary> spriteLibraries;

    private void Awake()
    {
        //Dictionary for actualice the sprite library
        spriteLibraries = new Dictionary<ItemsType, SpriteLibrary>()
        {
            { ItemsType.None, clothSpriteLibrary },
            { ItemsType.Cloth, clothSpriteLibrary },
            { ItemsType.Hair, HairSpriteLibrary },
            { ItemsType.Hat, HatSpriteLibrary }
        };
    }

    /// <summary>
    /// Actualice the sprite library for change the visual of the player and actualice the UI frame
    /// </summary>
    /// <param name="currentItemType"></param>
    /// <param name="spriteLibraryAsset"></param>
    public void SetSpriteLibrary(ItemsType currentItemType, SpriteLibraryAsset spriteLibraryAsset = null)
    {
        if (spriteLibraries.TryGetValue(currentItemType, out SpriteLibrary spriteLibrary))
        {
            spriteLibrary.spriteLibraryAsset = spriteLibraryAsset;

            if (spriteLibraryAsset == null)
            {
                spriteToSet = baseImage;
                spriteLibrary.GetComponent<SpriteRenderer>().sprite = null;
            }
            else
                spriteToSet = spriteLibraryAsset.GetSprite("IdelF", "IdelF");

            if (spriteLibraryAsset == null && currentItemType == ItemsType.Cloth)
                spriteLibrary.spriteLibraryAsset = baseLibrary;

            switch (currentItemType)
            {
                case ItemsType.None:
                    break;
                case ItemsType.Cloth:
                    clothSpriteLibraryUI.sprite = spriteToSet;
                    break;
                case ItemsType.Hair:
                    HairSpriteLibraryUI.sprite = spriteToSet;
                    break;
                case ItemsType.Hat:
                    HatSpriteLibraryUI.sprite = spriteToSet;
                    break;
                default:
                    break;
            }
        }
    }
}