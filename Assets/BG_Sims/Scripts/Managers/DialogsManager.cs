using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogs", order = 2)]

public class Dialogs : ScriptableObject
{
    [SerializeField] private DialogEntry[] dialogs;
}

[System.Serializable]
public class DialogEntry
{
    public int id;
    public string dialog;
}