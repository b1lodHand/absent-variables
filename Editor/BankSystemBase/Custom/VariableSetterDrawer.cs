using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEditor.UIElements;
using com.absence.variablesystem.imported;

namespace com.absence.variablesystem.banksystembase.editor
{
    /// <summary>
    /// A custom property drawer script for <see cref="VariableSetterBase"/>.
    /// </summary>
    [CustomPropertyDrawer(typeof(VariableSetterBase), true)]
    public class VariableSetterDrawer : PropertyDrawer
    {
        const float k_horizontalPadding = 4f;

        /// <summary>
        /// Path of the uss file.
        /// </summary>
        protected static readonly string s_styleSheetPath = "Packages/com.absence.variablesystem/Editor/uss/VariableSetter.uss";

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            bool isArrayElement = property.propertyPath.Contains("Array");
            int virtualHeight = isArrayElement ? 1 : 2;
            float addition = 0f;

            float spacing = EditorGUIUtility.standardVerticalSpacing;
            float height = EditorGUIUtility.singleLineHeight;

            if (!isArrayElement) 
                addition += spacing;
            else
                addition -= spacing;

            return ((height + spacing) * virtualHeight) + addition;
        }

        //public override VisualElement CreatePropertyGUI(SerializedProperty property)
        //{
        //    VisualElement root = new VisualElement();
        //    root.style.flexShrink = 1;
        //    root.style.alignSelf = Align.Stretch;

        //    VisualElement container = new VisualElement();
        //    container.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(StyleSheetPath));
        //    container.AddToClassList("container");

        //    DrawGUI(container, property);

        //    root.Add(container);
        //    return root;
        //}

        //private VisualElement DrawGUI(VisualElement container, SerializedProperty property)
        //{
        //    // get serialized object.
        //    var serializedObject = property.serializedObject;
        //    VariableSetterBase setter = (VariableSetterBase)property.boxedValue;

        //    var setTypeProp = property.FindPropertyRelative("m_setType");
        //    var bankGuidProp = property.FindPropertyRelative("m_targetBankGuid");
        //    var targetVarNameProp = property.FindPropertyRelative("m_targetVariableName");

        //    var intValueProp = property.FindPropertyRelative("m_intValue");
        //    var floatValueProp = property.FindPropertyRelative("m_floatValue");
        //    var stringValueProp = property.FindPropertyRelative("m_stringValue");
        //    var boolValueProp = property.FindPropertyRelative("m_boolValue");

        //    // declare needed variables.
        //    VariableBank targetBank = null;
        //    string currentBankGuid = bankGuidProp.stringValue;

        //    // refresh banks.
        //    VariableBankDatabase.Refresh();

        //    if (VariableBankDatabase.NoBanks)
        //    {
        //        HelpBox noBanksHelpBox = new HelpBox("There are no VariableBanks in your project. Create at least one to continue.", HelpBoxMessageType.Error);
        //        container.Clear();
        //        container.Add(noBanksHelpBox);
        //        return container;
        //    }

        //    // instantiate selector for bank.
        //    DropdownField bankSelector = new DropdownField(VariableBankDatabase.GetBankNameList(), 0);
        //    bankSelector.name = "bank";
        //    bankSelector.AddToClassList("bankSelector");

        //    targetBank = VariableBankDatabase.GetBankIfExists(currentBankGuid);

        //    if (!setter.HasFixedBank)
        //    {
        //        bankSelector.SetValueWithoutNotify(targetBank.name);
        //    }

        //    // instantiate selector for variable.
        //    DropdownField variableSelector = new DropdownField(new List<string>() { VariableBank.Null }, 0);
        //    variableSelector.name = "variable";
        //    variableSelector.AddToClassList("varSelector");
        //    variableSelector.BindProperty(targetVarNameProp);

        //    // instantiate selector for set type.
        //    EnumField setTypeSelector = new EnumField();
        //    setTypeSelector.name = "settype";
        //    setTypeSelector.AddToClassList("setTypeSelector");
        //    setTypeSelector.BindProperty(setTypeProp);

        //    // instantiate fields for actual values to check.
        //    #region Value Fields
        //    var intField = new IntegerField();
        //    intField.name = "value_int";
        //    intField.BindProperty(intValueProp);
        //    intField.AddToClassList("valueField");

        //    var floatField = new FloatField();
        //    floatField.name = "value_float";
        //    floatField.BindProperty(floatValueProp);
        //    floatField.AddToClassList("valueField");

        //    var stringField = new TextField();
        //    stringField.name = "value_str";
        //    stringField.BindProperty(stringValueProp);
        //    stringField.AddToClassList("valueField");

        //    var boolToggle = new Toggle();
        //    boolToggle.name = "value_bool";
        //    boolToggle.BindProperty(boolValueProp);
        //    boolToggle.AddToClassList("valueField");
        //    #endregion

        //    bankSelector.RegisterValueChangedCallback(evt =>
        //    {
        //        Undo.RecordObject(property.serializedObject.targetObject, "Variable Setter (Edited)");

        //        string targetGuid = VariableBankDatabase.NameToGuid(evt.newValue);
        //        targetBank = VariableBankDatabase.GetBankIfExists(targetGuid);
        //        bankGuidProp.stringValue = targetBank.Guid;
        //        RefreshVarSelector();

        //        serializedObject.ApplyModifiedProperties();
        //    });

        //    // register var selector on change.
        //    variableSelector.RegisterValueChangedCallback(evt =>
        //    {
        //        Undo.RecordObject(property.serializedObject.targetObject, "Variable Setter (Edited)");

        //        RefreshSetTypeSelector();
        //        RefreshValueFields();

        //        serializedObject.ApplyModifiedProperties();
        //    });

        //    if(!setter.HasFixedBank) container.Add(bankSelector);
        //    container.Add(variableSelector);
        //    container.Add(setTypeSelector);

        //    if (targetBank == null)
        //    {
        //        string targetGuid = VariableBankDatabase.NameToGuid(bankSelector.value);
        //        targetBank = VariableBankDatabase.GetBankIfExists(targetGuid);
        //        bankGuidProp.stringValue = targetGuid;
        //    }

        //    RefreshVarSelector();
        //    RefreshSetTypeSelector();
        //    RefreshValueFields();

        //    return container;

        //    void RefreshVarSelector()
        //    {
        //        var targetVarNameProp = property.FindPropertyRelative("m_targetVariableName");
        //        var variableSelector = container.Q<DropdownField>("variable");

        //        if (targetBank == null)
        //        {
        //            variableSelector.choices = new List<string>() { VariableBank.Null };
        //            variableSelector.value = VariableBank.Null;
        //            return;
        //        }

        //        var variableNamesWithTypes = targetBank.GetAllVariableNamesWithTypes();
        //        variableNamesWithTypes.Insert(0, VariableBank.Null);

        //        variableSelector.choices = variableNamesWithTypes;

        //        var currentVarName = targetVarNameProp.stringValue;
        //        if (targetBank.HasAny(currentVarName))
        //        {
        //            variableSelector.SetValueWithoutNotify(currentVarName);
        //        }
        //        else variableSelector.value = VariableBank.Null;

        //        targetVarNameProp.stringValue = currentVarName;
        //    }

        //    void RefreshValueFields()
        //    {
        //        var variableSelector = container.Q<DropdownField>("variable");
        //        var selectedVarName = variableSelector.value;

        //        if (container.Contains(intField)) container.Remove(intField);
        //        if (container.Contains(floatField)) container.Remove(floatField);
        //        if (container.Contains(stringField)) container.Remove(stringField);
        //        if (container.Contains(boolToggle)) container.Remove(boolToggle);

        //        if (selectedVarName == VariableBank.Null)
        //        {
        //            targetVarNameProp.stringValue = VariableBank.Null;
        //            return;
        //        }

        //        targetVarNameProp.stringValue = selectedVarName;

        //        if (targetBank == null) return;

        //        var targetVariableName = targetVarNameProp.stringValue;
        //        if (targetBank.HasInt(targetVariableName))
        //            container.Add(intField);
        //        else if (targetBank.HasFloat(targetVariableName))
        //            container.Add(floatField);
        //        else if (targetBank.HasString(targetVariableName))
        //            container.Add(stringField);
        //        else if (targetBank.HasBoolean(targetVariableName))
        //            container.Add(boolToggle);
        //    }

        //    void RefreshSetTypeSelector()
        //    {
        //        var comparisonSelector = container.Q<EnumField>("settype");

        //        comparisonSelector.SetEnabled(true);
        //        if (targetBank == null) return;

        //        var currVarName = targetVarNameProp.stringValue;
        //        if (currVarName != VariableBank.Null && !(targetBank.HasString(currVarName)) &&
        //            !(targetBank.HasBoolean(currVarName))) return;

        //        comparisonSelector.value = VariableSetterBase.SetType.SetTo;
        //        comparisonSelector.SetEnabled(false);
        //    }
        //}

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
            // get properties.
            VariableSetterBase setter = (VariableSetterBase)property.boxedValue;

            var setTypeProp = property.FindPropertyRelative("m_setType");
            var bankGuidProp = property.FindPropertyRelative("m_targetBankGuid");
            var targetVarNameProp = property.FindPropertyRelative("m_targetVariableName");
            var cachedBankProp = property.FindPropertyRelative("m_cachedBank");

            var intValueProp = property.FindPropertyRelative("m_intValue");
            var floatValueProp = property.FindPropertyRelative("m_floatValue");
            var stringValueProp = property.FindPropertyRelative("m_stringValue");
            var boolValueProp = property.FindPropertyRelative("m_boolValue");

            float height = EditorGUIUtility.singleLineHeight;
            float spacing = EditorGUIUtility.standardVerticalSpacing;
            bool isArrayElement = property.propertyPath.Contains("Array");

            #region rect stuff.
            Rect bankSelectorRect = position;
            Rect variableSelectorRect;
            Rect setTypeSelectorRect;
            Rect actualValueRect;

            Rect downRect = position;
            downRect.x += k_horizontalPadding;
            downRect.width -= k_horizontalPadding * 2;
            downRect.height = height;

            if (!isArrayElement)
                downRect.y += height + spacing;

            if (!setter.HasFixedBank)
            {
                const float k_bankSelector = 8f;
                const float k_varSelector = 10f;
                const float k_setTypeSelector = 3f;
                const float k_actualValue = 5f;

                Rect[] rects = Helpers.SliceRectHorizontally(downRect, 4, Helpers.K_SPACING, 0f, k_bankSelector, k_varSelector, k_setTypeSelector, k_actualValue);
                bankSelectorRect = rects[0];
                variableSelectorRect = rects[1];
                setTypeSelectorRect = rects[2];
                actualValueRect = rects[3];
            }

            else
            {
                const float k_varSelectorFixed = 7f;
                const float k_setTypeSelectorFixed = 1f;
                const float k_actualValueFixed = 5f;

                Rect[] rects = Helpers.SliceRectHorizontally(downRect, 3, Helpers.K_SPACING, 0f, k_varSelectorFixed, k_setTypeSelectorFixed, k_actualValueFixed);
                variableSelectorRect = rects[0];
                setTypeSelectorRect = rects[1];
                actualValueRect = rects[2];
            }
            #endregion

            // declare needed variables.
            VariableBank targetBank = null;
            string currentBankGuid = bankGuidProp.stringValue;

            if (!isArrayElement)
            {
                GUIStyle style = new("window")
                {
                    richText = true,
                };

                GUI.Box(position, $"<b>{Helpers.SplitCamelCase(setter.GetType().Name, " ")}</b> ({property.displayName})", style);
            }

            if (VariableBankDatabase.NoBanks)
            {
                EditorGUI.LabelField(position, "There are no VariableBanks in your project. Create at least one to continue.");
                return;
            }

            if (Application.isPlaying) GUI.enabled = false;

            if (!setter.HasFixedBank)
            {
                int selectedBankIndex;

                if (!setter.BankAsDirectReference)
                {
                    selectedBankIndex = EditorGUI.Popup(bankSelectorRect, VariableBankDatabase.Exists(currentBankGuid) ? VariableBankDatabase.GetIndexOf(currentBankGuid) : 0, VariableBankDatabase.GetBankNameList().ToArray());

                    if (selectedBankIndex < 0 || selectedBankIndex >= VariableBankDatabase.BanksInAssets.Count)
                        selectedBankIndex = 0;

                    targetBank = VariableBankDatabase.BanksInAssets[selectedBankIndex];
                }

                else
                {
                    VariableBank bank = (VariableBank)
                        EditorGUI.ObjectField(bankSelectorRect, VariableBankDatabase.GetBankIfExists(currentBankGuid), typeof(VariableBank), false);

                    if (setter.CacheBankDirectly && bank != null && (!bank.ForExternalUse))
                        Debug.LogWarning("Selected bank for a directly-cached variable manipulator is an internal bank. This might cause reference loss.");

                    selectedBankIndex = bank != null ?
                        VariableBankDatabase.GetIndexOf(bank.Guid) : -1;

                    if (selectedBankIndex < 0 || selectedBankIndex >= VariableBankDatabase.BanksInAssets.Count)
                        selectedBankIndex = -1;

                    targetBank = bank;
                }

                if (setter.CacheBankDirectly) 
                    cachedBankProp.objectReferenceValue = targetBank;

                if (targetBank == null)
                {
                    bankGuidProp.stringValue = string.Empty;
                    if (setter.BankAsDirectReference) EditorGUI.LabelField(variableSelectorRect, "Select a bank to continue.");
                    return;
                }

                bankGuidProp.stringValue = targetBank.Guid;
            }

            else
            {
                targetBank = VariableBankDatabase.GetBankIfExists(currentBankGuid);
            }

            if (targetBank == null)
            {
                string message1 = "This setter has a fixed bank. Set 'm_targetBankGuid' to a valid guid.";
                string message2 = "This setter has a fixed bank. Set 'm_cachedBank' to a valid bank.";

                EditorGUI.LabelField(downRect, setter.CacheBankDirectly ? message2 : message1);
                return;
            }

            List<string> allNamesWithTypes = new List<string> { VariableBank.Null };

            allNamesWithTypes.AddRange(targetBank.GetAllVariableNamesWithTypes());

            targetVarNameProp.stringValue = allNamesWithTypes[EditorGUI.Popup(variableSelectorRect,
                            allNamesWithTypes.Contains(targetVarNameProp.stringValue) ? allNamesWithTypes.IndexOf(targetVarNameProp.stringValue) : 0, allNamesWithTypes.ToArray())];

            var targetVariableName = targetVarNameProp.stringValue;

            if (targetBank.HasBoolean(targetVariableName) || 
                targetBank.HasString(targetVariableName) ||
                targetVariableName == VariableBank.Null)
            {
                GUI.enabled = false;
                setTypeProp.enumValueIndex = (int)(VariableSetterBase.SetType.SetTo);
            }

            setTypeProp.enumValueIndex = (int)((VariableSetterBase.SetType)(EditorGUI.EnumPopup(setTypeSelectorRect, (VariableSetterBase.SetType)setTypeProp.enumValueIndex)));

            GUI.enabled = true;

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

}