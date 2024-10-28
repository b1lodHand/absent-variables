using com.absence.variablesystem.internals;
using UnityEditor;
using UnityEngine;

namespace com.absence.variablesystem.editor
{
    [CustomPropertyDrawer(typeof(VariableBase), true)]
    public class VariableEditor : PropertyDrawer
    {
        static readonly float s_verticalPaddingBottom = 1f;
        static readonly float s_horizontalArrayOffset = 15f;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty valueProp = property.FindPropertyRelative("m_value");
            if (property.IsArrayElement()) return EditorGUI.GetPropertyHeight(valueProp, new GUIContent("Value"), true) + EditorGUIUtility.singleLineHeight + (EditorGUIUtility.standardVerticalSpacing * 2);
            else return EditorGUI.GetPropertyHeight(valueProp, new GUIContent("Value"), true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty nameProp = property.FindPropertyRelative("m_name");
            SerializedProperty valueProp = property.FindPropertyRelative("m_value");

            float horizontalSpacing = 15f;
            float sizeX = (position.width - horizontalSpacing) / 2;
            float totalHeight = position.height;

            Rect dynamicPosition = new Rect(position.x, position.y, sizeX, EditorGUIUtility.singleLineHeight);

            if (property.IsArrayElement()) DrawListElementGUI();
            else DrawDefaultGUI();

            EditorGUI.EndProperty();

            return;

            void DrawListElementGUI()
            {
                EditorGUI.LabelField(dynamicPosition, $"Name ({label.text})");
                dynamicPosition.x += sizeX;
                dynamicPosition.x += horizontalSpacing;

                EditorGUI.LabelField(dynamicPosition, "Value");
                dynamicPosition.y += EditorGUIUtility.singleLineHeight;
                dynamicPosition.x -= sizeX;
                dynamicPosition.x -= horizontalSpacing;

                nameProp.stringValue = EditorGUI.TextField(dynamicPosition, nameProp.stringValue);
                dynamicPosition.x += sizeX;
                dynamicPosition.x += (horizontalSpacing - 1) / 2;

                dynamicPosition.width = 1;
                dynamicPosition.height -= 2;
                EditorGUI.DrawRect(dynamicPosition, new Color(1, 1, 1, 0.2f));
                dynamicPosition.width = sizeX;
                dynamicPosition.height += 2;

                dynamicPosition.x += (horizontalSpacing - 1) / 2;

                if (valueProp.propertyType == SerializedPropertyType.Generic)
                {
                    dynamicPosition.x += s_horizontalArrayOffset;
                    dynamicPosition.width -= s_horizontalArrayOffset;
                }

                dynamicPosition.height = totalHeight - s_verticalPaddingBottom - EditorGUIUtility.singleLineHeight - (EditorGUIUtility.standardVerticalSpacing * 2);

                EditorGUI.PropertyField(dynamicPosition, valueProp, new GUIContent() { text = "" }, true);
            }

            void DrawDefaultGUI()
            {
                EditorGUI.PropertyField(position, valueProp, label, true);
            }
        }
    }
}
