#if UNITY_EDITOR

using Framework.Core.Attributes;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Framework.Core.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(OneLineAttribute))]
    public class OneLinePropertyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();
            
            foreach (var childProperty in property)
            {
                if (!(childProperty is SerializedProperty serializedChildProperty)) continue;
                
                var field = new PropertyField(serializedChildProperty);
                container.Add(field);
            }

            return container;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            
            foreach (var childProperty in property)
            {
                if (!(childProperty is SerializedProperty serializedChildProperty)) continue;
                
                var name = serializedChildProperty.displayName;
                var labelRect = new Rect(position.x, position.y, LabelWidth, position.height);
                GUI.Label(labelRect, name);
                position.xMin += LabelWidth;
                
                if (serializedChildProperty.hasChildren) continue;
                
                var fieldRect = new Rect(position.x, position.y, FieldWidth, position.height);
                EditorGUI.PropertyField(fieldRect, serializedChildProperty, GUIContent.none, false);
                position.xMin += FieldWidth + 15f;
            }
            
            EditorGUI.EndProperty();
        }

        private const float LabelWidth = 50f;
        private const float FieldWidth = 75f;
    }
}

#endif