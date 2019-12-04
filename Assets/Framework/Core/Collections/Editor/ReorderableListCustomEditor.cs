

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;

namespace Framework.Core.Collections.Editor
{
    internal class ReorderableListCustomEditor : UnityEditor.Editor
    {
        private ReorderableList _list;

        public void OnEnable()
        {
            _list = new ReorderableList(serializedObject, 
                serializedObject.FindProperty("Items"),
                true, true, true, true);

            _list.drawHeaderCallback += rect => EditorGUI.LabelField(rect, "Items");
            _list.drawElementCallback += (rect, index, active, focused) =>
            {
                var item = _list.serializedProperty.GetArrayElementAtIndex(index);
                var label = new GUIContent($"Item {index.ToString()}");
                EditorGUI.PropertyField(rect, item, label, true);
            };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            _list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(target);
            serializedObject.Update();
        }
    }
}

#endif