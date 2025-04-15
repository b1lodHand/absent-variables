using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace com.absence.variablesystem.banksystembase.editor
{
    [CustomPropertyDrawer(typeof(VariableEntryContainer), true)]
    public class VariableEntryContainerPropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty nextEntry = property.Copy();
            bool lastEntry = !nextEntry.NextVisible(false);

            ValidateBefore(lastEntry, nextEntry);

            bool change;
            using (var scope = new EditorGUI.ChangeCheckScope())
            {
                property.isExpanded = EditorGUI.PropertyField(position, property, label, property.isExpanded);
                change = scope.changed;
            }

            ValidateAfterwards(lastEntry, nextEntry, change);

            return;

            void ValidateBefore(bool lastEntry, SerializedProperty nextProperty)
            {
                
            }

            void ValidateAfterwards(bool lastEntry, SerializedProperty nextProperty, bool anyChangesInEditor)
            {
                //throw new System.Exception($"[{nameof(VariableEntryContainer)}] can only be used with array types!");

                string guid = GetGuid(property);

                if (string.IsNullOrWhiteSpace(guid))
                {
                    guid = System.Guid.NewGuid().ToString();
                    SetGuid(property, guid);
                }

                if (!lastEntry)
                {
                    string nextPropertyGuid = GetGuid(nextProperty);

                    if (guid == nextPropertyGuid)
                    {
                        guid = System.Guid.NewGuid().ToString();
                        SetGuid(nextProperty, guid);
                    }
                }
            }

            string GetGuid(SerializedProperty entryProperty)
            {
                SerializedProperty guidProp = GetGuidProperty(entryProperty);
                return guidProp.stringValue;
            }

            void SetGuid(SerializedProperty entryProperty, string value)
            {
                SerializedProperty guidProp = GetGuidProperty(entryProperty);
                guidProp.stringValue = value;
            }

            SerializedProperty GetGuidProperty(SerializedProperty entryProperty)
            {
                SerializedProperty guidProp = entryProperty.FindPropertyRelative("Guid");

                if (guidProp == null)
                    throw new System.Exception("Container entries must have the string field: 'Guid'!");

                return guidProp;
            }
        }
    }
}
