using UnityEditor;
using UnityEngine;

namespace com.absence.variablesystem.banksystembase.editor
{
    [CustomPropertyDrawer(typeof(VariableEntry), true)]
    public class VariableNamePairPropertyDrawer : PropertyDrawer
    {
        static readonly float s_verticalPaddingBottom = 1f;
        static readonly float s_horizontalArrayOffset = 15f;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty variableProp = property.FindPropertyRelative("Variable");
            return EditorGUI.GetPropertyHeight(variableProp, new GUIContent("Value"), true) + EditorGUIUtility.singleLineHeight + (EditorGUIUtility.standardVerticalSpacing * 2);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty nameProp = property.FindPropertyRelative("Name");
            SerializedProperty variableProp = property.FindPropertyRelative("Variable");
            SerializedProperty valueProp = variableProp.FindPropertyRelative("m_value");

            float horizontalSpacing = 15f;
            float sizeX = (position.width - horizontalSpacing) / 2;
            float totalHeight = position.height;

            Rect dynamicPosition = new Rect(position.x, position.y, sizeX, EditorGUIUtility.singleLineHeight);

            EditorGUI.BeginProperty(position, label, property);

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

            EditorGUI.PropertyField(dynamicPosition, variableProp, new GUIContent() { text = "" }, true);

            EditorGUI.EndProperty();
        }
    }
}
