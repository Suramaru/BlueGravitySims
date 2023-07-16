using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogs", order = 2)]
public class Dialogs : ScriptableObject
{
    [SerializeField] private DialogEntry[] dialogs;

    public string GetDialogById(int id)
    {
        DialogEntry entry = FindDialogEntry(id);
        return entry != null ? entry.dialog : string.Empty;
    }

    private DialogEntry FindDialogEntry(int id)
    {
        foreach (DialogEntry entry in dialogs)
        {
            if (entry.id == id)
                return entry;
        }
        return null;
    }
}

[System.Serializable]
public class DialogEntry
{
    public int id;
    public string dialog;
}