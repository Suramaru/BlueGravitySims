using UnityEngine;
using UnityEditor;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpriteLibraryManager", order = 1)]
public class SpriteLibrary : ScriptableObject
{
    [SerializeField] private SpriteLibraryEntry[] spriteHatsLibraries;
    [SerializeField] private SpriteLibraryEntry[] spriteHairsLibraries;
    [SerializeField] private SpriteLibraryEntry[] spriteClothsLibraries;
    [SerializeField] private SpriteLibraryEntry[] spriteUnderwearLibraries;

    public SpriteLibraryAsset ReturnHatsLibrary(int id)
    {
        SpriteLibraryEntry entry = FindLibraryEntry(spriteHatsLibraries, id);
        return entry != null ? entry.libraryAsset : null;
    }

    public SpriteLibraryAsset ReturnHairsLibrary(int id)
    {
        SpriteLibraryEntry entry = FindLibraryEntry(spriteHairsLibraries, id);
        return entry != null ? entry.libraryAsset : null;
    }

    public SpriteLibraryAsset ReturnClothLibrary(int id)
    {
        SpriteLibraryEntry entry = FindLibraryEntry(spriteClothsLibraries, id);
        return entry != null ? entry.libraryAsset : null;
    }

    public SpriteLibraryAsset ReturnUnderWearLibrary(int id)
    {
        SpriteLibraryEntry entry = FindLibraryEntry(spriteUnderwearLibraries, id);
        return entry != null ? entry.libraryAsset : null;
    }

    private SpriteLibraryEntry FindLibraryEntry(SpriteLibraryEntry[] entries, int id)
    {
        foreach (SpriteLibraryEntry entry in entries)
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

        foreach (SpriteLibraryEntry entry in spriteHatsLibraries)
        {
            uniqueGuid = System.Guid.NewGuid();
            uniqueId = uniqueGuid.GetHashCode();

            entry.id = uniqueId;
        }

        foreach (SpriteLibraryEntry entry in spriteHairsLibraries)
        {
            uniqueGuid = System.Guid.NewGuid();
            uniqueId = uniqueGuid.GetHashCode();

            entry.id = uniqueId;
        }

        foreach (SpriteLibraryEntry entry in spriteClothsLibraries)
        {
            uniqueGuid = System.Guid.NewGuid();
            uniqueId = uniqueGuid.GetHashCode();

            entry.id = uniqueId;
        }

        foreach (SpriteLibraryEntry entry in spriteUnderwearLibraries)
        {
            uniqueGuid = System.Guid.NewGuid();
            uniqueId = uniqueGuid.GetHashCode();

            entry.id = uniqueId;
        }
    }
}

[System.Serializable]
public class SpriteLibraryEntry
{
    public int id;
    public SpriteLibraryAsset libraryAsset;
}