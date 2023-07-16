using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerVisualController : MonoBehaviour
{
    [SerializeField] private SpriteLibrary clothSpriteLibrary;
    [SerializeField] private SpriteLibrary HairSpriteLibrary;
    [SerializeField] private SpriteLibrary HatSpriteLibrary;

    private Dictionary<ItemsType, SpriteLibrary> spriteLibraries;

    private void Awake()
    {
        spriteLibraries = new Dictionary<ItemsType, SpriteLibrary>()
        {
            { ItemsType.Underwear, clothSpriteLibrary },
            { ItemsType.Cloth, clothSpriteLibrary },
            { ItemsType.Hair, HairSpriteLibrary },
            { ItemsType.Hat, HatSpriteLibrary }
        };
    }

    public void SetSpriteLibrary(ItemsType currentItemType, SpriteLibraryAsset spriteLibraryAsset)
    {
        if (spriteLibraries.TryGetValue(currentItemType, out SpriteLibrary spriteLibrary))
        {
            spriteLibrary.spriteLibraryAsset = spriteLibraryAsset;
        }
    }
}