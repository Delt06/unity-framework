#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace Core.Values.Assets.References.Editor
{
    [CustomPropertyDrawer(typeof(ReferenceBase), true)]
    public class ReferencePropertyDrawer : PropertyDrawer
    {
        private readonly string[] _popupOptions = { "Use Constant", "Use Variable" };
        private GUIStyle _popupStyle;

        private SerializedProperty _useConstant;
        private SerializedProperty _constantValue;
        private SerializedProperty _provider;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            InitializeFields(property);

            return EditorGUI.GetPropertyHeight(_useConstant.boolValue ? _constantValue : _provider) + 3;
        }

        private void InitializeFields(SerializedProperty property)
        {
            _useConstant = property.FindPropertyRelative("UseConstant");
            _constantValue = property.FindPropertyRelative("_constant");
            _provider = property.FindPropertyRelative("_provider");
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (_popupStyle == null)
            {
                _popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                _popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            InitializeFields(property);

            using(new EditorGUI.PropertyScope(position, label, property))
            {
                position = EditorGUI.PrefixLabel(position, label);

                using(var check = new EditorGUI.ChangeCheckScope())
                {
                    Rect buttonRect = new Rect(position);
                    buttonRect.yMin += _popupStyle.margin.top;
                    buttonRect.width = _popupStyle.fixedWidth + _popupStyle.margin.right + 10;
                    buttonRect.xMin = position.xMin;
                    position.xMin = buttonRect.xMax;

                    int result = EditorGUI.Popup(buttonRect, _useConstant.boolValue ? 0 : 1, _popupOptions, _popupStyle);

                    _useConstant.boolValue = result == 0;

                    EditorGUI.PropertyField(position, _useConstant.boolValue ? _constantValue : _provider, GUIContent.none, true);

                    if (check.changed)
                    {
                        property.serializedObject.ApplyModifiedProperties();
                    }
                }
            }
        }
    }
}

#endif