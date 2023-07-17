using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerVisualController : MonoBehaviour
{
    [SerializeField] private SpriteLibrary clothSpriteLibrary;
    [SerializeField] private SpriteLibrary HairSpriteLibrary;
    [SerializeField] private SpriteLibrary HatSpriteLibrary;

    [SerializeField] private SpriteLibraryAsset baseLibrary;

    private Dictionary<ItemsType, SpriteLibrary> spriteLibraries;

    private void Awake()
    {
        spriteLibraries = new Dictionary<ItemsType, SpriteLibrary>()
        {
            { ItemsType.None, clothSpriteLibrary },
            { ItemsType.Cloth, clothSpriteLibrary },
            { ItemsType.Hair, HairSpriteLibrary },
            { ItemsType.Hat, HatSpriteLibrary }
        };
    }

    public void SetSpriteLibrary(ItemsType currentItemType, SpriteLibraryAsset spriteLibraryAsset = null)
    {
        if (spriteLibraries.TryGetValue(currentItemType, out SpriteLibrary spriteLibrary))
        {
            spriteLibrary.spriteLibraryAsset = spriteLibraryAsset;

            if (spriteLibraryAsset == null)
                spriteLibrary.GetComponent<SpriteRenderer>().sprite = null;

            if (spriteLibraryAsset == null && currentItemType == ItemsType.Cloth)
                spriteLibrary.spriteLibraryAsset = baseLibrary;
        }
    }
}