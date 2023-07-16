using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemsTool : MonoBehaviour
{
#if UNITY_EDITOR
    [CustomEditor(typeof(ItemLibraryManager))]
    public class SpriteLibraryEditor : Editor
    {
        /// <summary>
        /// Set a custom id for the items created
        /// </summary>
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            ItemLibraryManager spriteLibrary = (ItemLibraryManager)target;

            if (GUILayout.Button("Assign IDs to Existing Entries"))
            {
                spriteLibrary.AssignIDsToExistingEntries();

                EditorUtility.SetDirty(spriteLibrary);
            }
        }
    }
#endif
}
