using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemsTool : MonoBehaviour
{
#if UNITY_EDITOR
    [CustomEditor(typeof(ItemLibrary))]
    public class SpriteLibraryEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            ItemLibrary spriteLibrary = (ItemLibrary)target;

            if (GUILayout.Button("Assign IDs to Existing Entries"))
            {
                spriteLibrary.AssignIDsToExistingEntries();

                EditorUtility.SetDirty(spriteLibrary);
            }
        }
    }
#endif
}
