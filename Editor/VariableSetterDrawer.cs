using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEditor.UIElements;

namespace com.absence.variablesystem.Editor
{
    [CustomPropertyDrawer(typeof(VariableSetter), true)]
    public class VariableSetterDrawer : PropertyDrawer
    {
        protected static readonly string StyleSheetPath = "Packages/com.absence.variablesystem/Editor/uss/VariableSetter.uss";
        static List<VariableBank> m_banks = new List<VariableBank>();

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = new VisualElement();
            root.style.flexShrink = 1;
            root.style.alignSelf = Align.Stretch;

            VisualElement container = new VisualElement();
            container.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(StyleSheetPath));
            container.AddToClassList("container");

            DrawGUI(container, property);

            root.Add(container);
            return root;
        }

        private VisualElement DrawGUI(VisualElement container, SerializedProperty property)
        {
            // get serialized object.
            var serializedObject = property.serializedObject;

            var setTypeProp = property.FindPropertyRelative("m_setType");
            var bankProp = property.FindPropertyRelative("m_targetBank");
            var targetVarNameProp = property.FindPropertyRelative("m_targetVariableName");

            var intValueProp = property.FindPropertyRelative("m_intValue");
            var floatValueProp = property.FindPropertyRelative("m_floatValue");
            var stringValueProp = property.FindPropertyRelative("m_stringValue");
            var boolValueProp = property.FindPropertyRelative("m_boolValue");

            // declare needed variables.
            VariableBank targetBank = null;

            // refresh banks.
            RefreshBanks();

            if (m_banks.Count == 0)
            {
                HelpBox noBanksHelpBox = new HelpBox("There are no VariableBanks in your project. Create at least one to continue.", HelpBoxMessageType.Error);
                container.Clear();
                container.Add(noBanksHelpBox);
                return container;
            }

            // instantiate selector for bank.
            DropdownField bankSelector = new DropdownField(m_banks.ConvertAll(b => b.name), 0);
            bankSelector.name = "bank";
            bankSelector.AddToClassList("bankSelector");
            if (bankProp.objectReferenceValue != null) bankSelector.SetValueWithoutNotify(bankProp.objectReferenceValue.name);

            // instantiate selector for variable.
            DropdownField variableSelector = new DropdownField(new List<string>() { VariableBank.Null }, 0);
            variableSelector.name = "variable";
            variableSelector.AddToClassList("varSelector");
            variableSelector.BindProperty(targetVarNameProp);

            // instantiate selector for set type.
            EnumField setTypeSelector = new EnumField();
            setTypeSelector.name = "settype";
            setTypeSelector.AddToClassList("setTypeSelector");
            setTypeSelector.BindProperty(setTypeProp);

            // instantiate fields for actual values to check.
            #region Value Fields
            var intField = new IntegerField();
            intField.name = "value_int";
            intField.BindProperty(intValueProp);
            intField.AddToClassList("valueField");

            var floatField = new FloatField();
            floatField.name = "value_float";
            floatField.BindProperty(floatValueProp);
            floatField.AddToClassList("valueField");

            var stringField = new TextField();
            stringField.name = "value_str";
            stringField.BindProperty(stringValueProp);
            stringField.AddToClassList("valueField");

            var boolToggle = new Toggle();
            boolToggle.name = "value_bool";
            boolToggle.BindProperty(boolValueProp);
            boolToggle.AddToClassList("valueField");
            #endregion

            bankSelector.RegisterValueChangedCallback(evt =>
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Variable Setter (Edited)");

                targetBank = m_banks.Where(b => b.name.Equals(bankSelector.value)).FirstOrDefault();
                bankProp.objectReferenceValue = targetBank;
                RefreshVarSelector();

                serializedObject.ApplyModifiedProperties();
            });

            // register var selector on change.
            variableSelector.RegisterValueChangedCallback(evt =>
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Variable Setter (Edited)");

                RefreshSetTypeSelector();
                RefreshValueFields();

                serializedObject.ApplyModifiedProperties();
            });

            container.Add(bankSelector);
            container.Add(variableSelector);
            container.Add(setTypeSelector);

            // refresh all of them.
            targetBank = m_banks.Where(b => b.name.Equals(bankSelector.value)).FirstOrDefault();
            bankProp.objectReferenceValue = targetBank;
            RefreshVarSelector();
            RefreshSetTypeSelector();
            RefreshValueFields();

            return container;

            void RefreshVarSelector()
            {
                var targetVarNameProp = property.FindPropertyRelative("m_targetVariableName");
                var variableSelector = container.Q<DropdownField>("variable");

                if (targetBank == null)
                {
                    variableSelector.choices = new List<string>() { VariableBank.Null };
                    variableSelector.value = VariableBank.Null;
                    return;
                }

                var variableNamesWithTypes = targetBank.GetAllVariableNamesWithTypes();
                variableNamesWithTypes.Insert(0, VariableBank.Null);

                variableSelector.choices = variableNamesWithTypes;

                var currentVarName = targetVarNameProp.stringValue;
                if (targetBank.HasAny(currentVarName)) variableSelector.SetValueWithoutNotify(currentVarName);
                else variableSelector.value = VariableBank.Null;
            }

            void RefreshValueFields()
            {
                var variableSelector = container.Q<DropdownField>("variable");
                var selectedVarName = variableSelector.value;

                if (container.Contains(intField)) container.Remove(intField);
                if (container.Contains(floatField)) container.Remove(floatField);
                if (container.Contains(stringField)) container.Remove(stringField);
                if (container.Contains(boolToggle)) container.Remove(boolToggle);

                if (selectedVarName == VariableBank.Null)
                {
                    targetVarNameProp.stringValue = VariableBank.Null;
                    return;
                }

                targetVarNameProp.stringValue = selectedVarName;

                if (targetBank == null) return;

                var targetVariableName = targetVarNameProp.stringValue;
                if (targetBank.HasInt(targetVariableName))
                    container.Add(intField);
                else if (targetBank.HasFloat(targetVariableName))
                    container.Add(floatField);
                else if (targetBank.HasString(targetVariableName))
                    container.Add(stringField);
                else if (targetBank.HasBoolean(targetVariableName))
                    container.Add(boolToggle);
            }

            void RefreshSetTypeSelector()
            {
                var comparisonSelector = container.Q<EnumField>("settype");

                comparisonSelector.SetEnabled(true);
                if (targetBank == null) return;

                var currVarName = targetVarNameProp.stringValue;
                if (currVarName != VariableBank.Null && !(targetBank.HasString(currVarName)) &&
                    !(targetBank.HasBoolean(currVarName))) return;

                comparisonSelector.value = VariableSetter.SetType.SetTo;
                comparisonSelector.SetEnabled(false);
            }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // needed stuff.
            label.text = "";
            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // holding default indent level and setting our own.
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // undo redo stuff.
            EditorGUI.BeginChangeCheck();
            Undo.RecordObject(property.serializedObject.targetObject, "Variable Setter (Edited)");

            DrawIMGUI(position, property);

            // setting indent back default.
            EditorGUI.indentLevel = indent;

            // finishing undo and marking target object as dirty.
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            // simply ending the property.
            EditorGUI.EndProperty();
        }

        void DrawIMGUI(Rect position, SerializedProperty property)
        {
            // get serialized object.
            var serializedObject = property.serializedObject;

            var setTypeProp = property.FindPropertyRelative("m_setType");
            var bankProp = property.FindPropertyRelative("m_targetBank");
            var targetVarNameProp = property.FindPropertyRelative("m_targetVariableName");

            var intValueProp = property.FindPropertyRelative("m_intValue");
            var floatValueProp = property.FindPropertyRelative("m_floatValue");
            var stringValueProp = property.FindPropertyRelative("m_stringValue");
            var boolValueProp = property.FindPropertyRelative("m_boolValue");

            #region rect stuff.
            // rect variables.
            var horizontalPointer = position.x;
            var horizontalSpace = 5f;
            var bankSelectorWidth = 80f;
            var variableSelectorWidth = 100f;
            var setTypeSelectorWidth = 30f;
            var actualValueWidth = 50f;

            var bankSelectorRect = new Rect(horizontalPointer, position.y, bankSelectorWidth, position.height);

            horizontalPointer += bankSelectorWidth;
            horizontalPointer += horizontalSpace;

            var variableSelectorRect = new Rect(horizontalPointer, position.y, variableSelectorWidth, position.height);

            horizontalPointer += variableSelectorWidth;
            horizontalPointer += horizontalSpace;

            var setTypeSelectorRect = new Rect(horizontalPointer, position.y, setTypeSelectorWidth, position.height);

            horizontalPointer += setTypeSelectorWidth;
            horizontalPointer += horizontalSpace;

            // some calcs to expand the area of actual value field.
            var rest = position.width - horizontalPointer;
            actualValueWidth = rest > 0f ? rest : actualValueWidth;

            var actualValueRect = new Rect(horizontalPointer, position.y, actualValueWidth, position.height);
            #endregion

            // declare needed variables.
            VariableBank targetBank = null;

            if (Event.current.type != EventType.Repaint)
            {
                RefreshBanks();
            }

            if (m_banks.Count == 0)
            {
                EditorGUILayout.HelpBox("There are no VariableBanks in your project. Create at least one to continue.", MessageType.Error);
                return;
            }

            var selectedBankIndex = EditorGUI.Popup(bankSelectorRect, bankProp.objectReferenceValue != null ? m_banks.IndexOf(bankProp.objectReferenceValue as VariableBank) : 0, m_banks.ConvertAll(b => b.name).ToArray());
            targetBank = m_banks[selectedBankIndex];
            bankProp.objectReferenceValue = targetBank;

            List<string> allNamesWithTypes = new List<string> { VariableBank.Null };

            // getting all variables from bank.
            if (targetBank != null) allNamesWithTypes.AddRange(targetBank.GetAllVariableNamesWithTypes());

            // drawing variable selection.
            targetVarNameProp.stringValue = allNamesWithTypes[EditorGUI.Popup(variableSelectorRect,
                            allNamesWithTypes.Contains(targetVarNameProp.stringValue) ? allNamesWithTypes.IndexOf(targetVarNameProp.stringValue) : 0, allNamesWithTypes.ToArray())];

            // borrowing needed info from property to draw the rest.
            var targetVariableName = targetVarNameProp.stringValue;

            // drawing set type selectionç
            if (targetBank != null && (targetBank.HasBoolean(targetVariableName) ||
                                       targetBank.HasString(targetVariableName) ||
                                       targetVariableName == VariableBank.Null))
            {
                GUI.enabled = false;
                setTypeProp.enumValueIndex = (int)(VariableSetter.SetType.SetTo);
            }

            EditorGUI.EnumPopup(setTypeSelectorRect, (VariableSetter.SetType)setTypeProp.enumValueIndex);

            // re-enabling the editor.
            GUI.enabled = true;

            if (targetBank != null)
            {
                // drawing the actual value depending on it's type.
                if (targetBank.HasInt(targetVariableName))
                    intValueProp.intValue = EditorGUI.IntField(actualValueRect, intValueProp.intValue);
                else if (targetBank.HasFloat(targetVariableName))
                    floatValueProp.floatValue = EditorGUI.FloatField(actualValueRect, floatValueProp.floatValue);
                else if (targetBank.HasString(targetVariableName))
                    stringValueProp.stringValue = EditorGUI.TextField(actualValueRect, stringValueProp.stringValue);
                else if (targetBank.HasBoolean(targetVariableName))
                    boolValueProp.boolValue = EditorGUI.Toggle(actualValueRect, boolValueProp.boolValue);
            }
        }

        public static void RefreshBanks()
        {
            m_banks = AssetDatabase.FindAssets("t:VariableBank").ToList().ConvertAll(foundGuid =>
            {
                return AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(foundGuid), typeof(VariableBank)) as VariableBank;
            });
        }
    }

}
