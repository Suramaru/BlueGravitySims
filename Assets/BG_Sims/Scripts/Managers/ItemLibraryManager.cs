using UnityEngine;
using UnityEditor;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpriteLibraryManager", order = 1)]

public class ItemLibraryManager : ScriptableObject
{
    [SerializeField] private ItemLibraryEntry[] spriteHatsLibraries;
    [SerializeField] private ItemLibraryEntry[] spriteHairsLibraries;
    [SerializeField] private ItemLibraryEntry[] spriteClothsLibraries;
    [SerializeField] private ItemLibraryEntry[] spriteUnderwearLibraries;

    public ItemLibraryEntry GetItemSpriteLibraryById(int id)
    {
        ItemLibraryEntry entry = FindLibraryEntry(spriteHatsLibraries, id);
        if (entry != null)
            return entry;

        entry = FindLibraryEntry(spriteHairsLibraries, id);
        if (entry != null)
            return entry;

        entry = FindLibraryEntry(spriteClothsLibraries, id);
        if (entry != null)
            return entry;

        entry = FindLibraryEntry(spriteUnderwearLibraries, id);
        return entry;
    }

    private ItemLibraryEntry FindLibraryEntry(ItemLibraryEntry[] entries, int id)
    {
        foreach (ItemLibraryEntry entry in entries)
        {
            if (entry.id == id)
                return entry;
        }
        return null;
    }


    public void AssignIDsToExistingEntries()
    {
        System.Guid uniqueGuid;
        int uniqueId;

        foreach (ItemLibraryEntry entry in spriteHatsLibraries)
        {
            uniqueGuid = System.Guid.NewGuid();
            uniqueId = uniqueGuid.GetHashCode();

            entry.id = uniqueId;
        }

        foreach (ItemLibraryEntry entry in spriteHairsLibraries)
        {
            uniqueGuid = System.Guid.NewGuid();
            uniqueId = uniqueGuid.GetHashCode();

            entry.id = uniqueId;
        }

        foreach (ItemLibraryEntry entry in spriteClothsLibraries)
        {
            uniqueGuid = System.Guid.NewGuid();
            uniqueId = uniqueGuid.GetHashCode();

            entry.id = uniqueId;
        }

        foreach (ItemLibraryEntry entry in spriteUnderwearLibraries)
        {
            uniqueGuid = System.Guid.NewGuid();
            uniqueId = uniqueGuid.GetHashCode();

            entry.id = uniqueId;
        }
    }
}

[System.Serializable]
public class ItemLibraryEntry
{
    public int id;
    public int itemPrice;
    public SpriteLibraryAsset libraryAsset;
}