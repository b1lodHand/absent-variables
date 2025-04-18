using com.absence.variablesystem.builtin;
using com.absence.variablesystem.imported;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AYellowpaper.SerializedCollections;

namespace com.absence.variablesystem.banksystembase
{
    /// <summary>
    /// The scriptable object represents a bank of variables.
    /// </summary>
    [CreateAssetMenu(menuName = "absencee_/absent-variables/Variable Bank (External)", fileName = "New VB (External)")]
    public class VariableBank : ScriptableObject, IPrimitiveVariableContainer
    {
        /// <summary>
        /// A constant string that represents a null variable name (with the prefix).
        /// </summary>
        public const string Null = "null: null";

        internal static string TrimVariableNameType(string nameToTrim)
        {
            if (!nameToTrim.Contains(':')) return nameToTrim;
            return nameToTrim.Split(':')[1].Trim();
        }

        [SerializeField, Readonly, Tooltip("Guid of this bank.")] 
        private string m_guid = System.Guid.NewGuid().ToString();

        /// <summary>
        /// Guid of this bank.
        /// </summary>
        public string Guid => m_guid;

        [SerializeField, Readonly, Tooltip("If true, this bank won't get cloned in the startup and also will not get shown on the variable bank name lists.")] 
        private bool m_forExternalUse = true;

        /// <summary>
        /// If true, this bank won't get cloned in the startup and also will not get shown on the variable bank name lists. Set to
        /// true if you'll use direct references of such. For more information, read the docs.
        /// </summary>
        public bool ForExternalUse
        {
            get
            {
                return m_forExternalUse;
            }

            set
            {
                if (Application.isPlaying) throw new Exception("You cannot set AvoidCloning of a bank runtime!");

                m_forExternalUse = value;
            }
        }

        [SerializeField] 
        internal SerializedDictionary<string, IntegerVariable> m_ints = new();

        [SerializeField]
        internal SerializedDictionary<string, FloatVariable> m_floats = new();

        [SerializeField]
        internal SerializedDictionary<string, StringVariable> m_strings = new();

        [SerializeField]
        internal SerializedDictionary<string, BooleanVariable> m_booleans = new();

        public Dictionary<string, IntegerVariable> Ints
        {
            get
            {
                return m_ints;
            }

            set
            {
                m_ints = (SerializedDictionary<string, IntegerVariable>)value;
            }
        }

        public Dictionary<string, FloatVariable> Floats
        {
            get
            {
                return m_floats;
            }

            set
            {
                m_floats = (SerializedDictionary<string, FloatVariable>)value;
            }
        }

        public Dictionary<string, StringVariable> Strings
        {
            get
            {
                return m_strings;
            }

            set
            {
                m_strings = (SerializedDictionary<string, StringVariable>)value;
            }
        }

        public Dictionary<string, BooleanVariable> Booleans
        {
            get
            {
                return m_booleans;
            }

            set
            {
                m_booleans = (SerializedDictionary<string, BooleanVariable>)value;
            }
        }

        /// <summary>
        /// The action gets invoked when this bank gets destroyed.
        /// </summary>
        public event Action OnDestroyAction;

        private VariableBank m_clonedFrom = null;

        /// <summary>
        /// Returns null if this is not a clone. Returns the original bank if this is a clone.
        /// </summary>
        public VariableBank ClonedFrom => m_clonedFrom;

        /// <summary>
        /// Use to check if this bank is a clone.
        /// </summary>
        public bool IsClone => m_clonedFrom != null;

        /// <summary>
        /// Use to get a list of all variables' names of this bank.
        /// </summary>
        /// <returns>A list of variable names. Example: "example_int"</returns>
        public List<string> GetAllVariableNames()
        {
            List<string> result = new();

            foreach (var integerVariable in m_ints) 
            {
                result.Add(integerVariable.Key);
            }

            foreach (var floatVariable in m_floats)
            {
                result.Add(floatVariable.Key);
            }

            foreach (var stringVariable in m_strings)
            {
                result.Add(stringVariable.Key);
            }

            foreach (var booleanVariable in m_booleans)
            {
                result.Add(booleanVariable.Key);
            }

            return result;
        }

        /// <summary>
        /// Use to get a list of all variables' names of this bank, each one of the names will contain a type prefix. <b>Those
        /// prefixes get trimmed when you pass them to any function of a variable bank.</b>
        /// </summary>
        /// <returns>A list of all variable names with the prefixes. Example: "int: example_int"</returns>
        public List<string> GetAllVariableNamesWithTypes()
        {
            List<string> result = new();

            foreach (var integerVariable in m_ints)
            {
                result.Add("int: " + integerVariable.Key);
            }

            foreach (var floatVariable in m_floats)
            {
                result.Add("float: " + floatVariable.Key);
            }

            foreach (var stringVariable in m_strings)
            {
                result.Add("string: " + stringVariable.Key);
            }

            foreach (var booleanVariable in m_booleans)
            {
                result.Add("bool: " + booleanVariable.Key);
            }

            return result;
        }

        public int GetInt(string variableName)
        {
            variableName = TrimVariableNameType(variableName);
            return FindIntegerOrNull(variableName).Value;
        }

        public float GetFloat(string variableName)
        {
            variableName = TrimVariableNameType(variableName);
            return FindFloatOrNull(variableName).Value;
        }

        public string GetString(string variableName)
        {
            variableName = TrimVariableNameType(variableName);
            return FindStringOrNull(variableName).Value;
        }

        public bool GetBoolean(string variableName)
        {
            variableName = TrimVariableNameType(variableName);
            return FindBooleanOrNull(variableName).Value;
        }

        public IntegerVariable GetIntVariable(string variableName)
        {
            variableName = TrimVariableNameType(variableName);
            return FindIntegerOrNull(variableName);
        }

        public FloatVariable GetFloatVariable(string variableName)
        {
            variableName = TrimVariableNameType(variableName);
            return FindFloatOrNull(variableName);
        }

        public StringVariable GetStringVariable(string variableName)
        {
            variableName = TrimVariableNameType(variableName);
            return FindStringOrNull(variableName);
        }

        public BooleanVariable GetBooleanVariable(string variableName)
        {
            variableName = TrimVariableNameType(variableName);
            return FindBooleanOrNull(variableName);
        }

        /// <summary>
        /// Use to get value of an integer variable within this bank.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <param name="value">Value of the variable.</param>
        /// <returns>True if a variable with the target name exists within the bank.</returns>
        public bool TryGetInt(string variableName, out int value)
        {
            variableName = TrimVariableNameType(variableName);
            bool result = TryFindVariable(variableName, m_ints, out value);

            return result;
        }

        /// <summary>
        /// Use to get value of a floating point variable within this bank.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <param name="value">Value of the variable.</param>
        /// <returns>True if a variable with the target name exists within the bank.</returns>
        public bool TryGetFloat(string variableName, out float value)
        {
            variableName = TrimVariableNameType(variableName);
            bool result = TryFindVariable(variableName, m_floats, out value);

            return result;
        }

        /// <summary>
        /// Use to get value of a string variable within this bank.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <param name="value">Value of the variable.</param>
        /// <returns>True if a variable with the target name exists within the bank.</returns>
        public bool TryGetString(string variableName, out string value)
        {
            variableName = TrimVariableNameType(variableName);
            bool result = TryFindVariable(variableName, m_strings, out value);

            return result;
        }

        /// <summary>
        /// Use to get value of a boolean variable within this bank.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <param name="value">Value of the variable.</param>
        /// <returns>True if a variable with the target name exists within the bank.</returns>
        public bool TryGetBoolean(string variableName, out bool value)
        {
            variableName = TrimVariableNameType(variableName);
            bool result = TryFindVariable(variableName, m_booleans, out value);

            return result;
        }

        /// <summary>
        /// Use to add a value change callback to an integer variable with a specific name.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <param name="callbackAction">What to do when value of the variable changes.</param>
        public void AddValueChangeListenerToInt(string variableName, Action<VariableValueChangedCallbackContext<int>> callbackAction)
        {
            variableName = TrimVariableNameType(variableName);
            var target = FindIntegerOrNull(variableName);
            target.AddValueChangeListener(callbackAction);
        }

        /// <summary>
        /// Use to add a value change callback to a floating point variable with a specific name.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <param name="callbackAction">What to do when value of the variable changes.</param>
        public void AddValueChangeListenerToFloat(string variableName, Action<VariableValueChangedCallbackContext<float>> callbackAction)
        {
            variableName = TrimVariableNameType(variableName);
            var target = FindFloatOrNull(variableName);
            target.AddValueChangeListener(callbackAction);
        }

        /// <summary>
        /// Use to add a value change callback to a string variable with a specific name.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <param name="callbackAction">What to do when value of the variable changes.</param>
        public void AddValueChangeListenerToString(string variableName, Action<VariableValueChangedCallbackContext<string>> callbackAction)
        {
            variableName = TrimVariableNameType(variableName);
            var target = FindStringOrNull(variableName);
            target.AddValueChangeListener(callbackAction);
        }

        /// <summary>
        /// Use to add a value change callback to a boolean variable with a specific name.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <param name="callbackAction">What to do when value of the variable changes.</param>
        public void AddValueChangeListenerToBoolean(string variableName, Action<VariableValueChangedCallbackContext<bool>> callbackAction)
        {
            variableName = TrimVariableNameType(variableName);
            var target = FindBooleanOrNull(variableName);
            target.AddValueChangeListener(callbackAction);
        }

        /// <summary>
        /// Use to change an integer variable's value.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <param name="newValue">New value for the variable.</param>
        /// <returns>True if value changing process ended successfully. False otherwise.</returns>
        public bool SetInt(string variableName, int newValue)
        {
            variableName = TrimVariableNameType(variableName);
            return SetVariableIfExists(variableName, newValue, m_ints);
        }

        /// <summary>
        /// Use to change a floating point variable's value.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <param name="newValue">New value for the variable.</param>
        /// <returns>True if value changing process ended successfully. False otherwise.</returns>
        public bool SetFloat(string variableName, float newValue)
        {
            variableName = TrimVariableNameType(variableName);
            return SetVariableIfExists(variableName, newValue, m_floats);
        }

        /// <summary>
        /// Use to change a string variable's value.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <param name="newValue">New value for the variable.</param>
        /// <returns>True if value changing process ended successfully. False otherwise.</returns>
        public bool SetString(string variableName, string newValue)
        {
            variableName = TrimVariableNameType(variableName);
            return SetVariableIfExists(variableName, newValue, m_strings);
        }

        /// <summary>
        /// Use to change a boolean variable's value.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <param name="newValue">New value for the variable.</param>
        /// <returns>True if value changing process ended successfully. False otherwise.</returns>
        public bool SetBoolean(string variableName, bool newValue)
        {
            variableName = TrimVariableNameType(variableName);
            return SetVariableIfExists(variableName, newValue, m_booleans);
        }

        /// <summary>
        /// Use to check if an integer variable with the target name exists within this bank.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <returns>True if exists, false otherwise.</returns>
        public bool HasInt(string variableName) => m_ints.TryGetValue(TrimVariableNameType(variableName), out _);

        /// <summary>
        /// Use to check if a floating point variable with the target name exists within this bank.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <returns>True if exists, false otherwise.</returns>
        public bool HasFloat(string variableName) => m_floats.TryGetValue(TrimVariableNameType(variableName), out _);

        /// <summary>
        /// Use to check if a string variable with the target name exists within this bank.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <returns>True if exists, false otherwise.</returns>
        public bool HasString(string variableName) => m_strings.TryGetValue(TrimVariableNameType(variableName), out _);

        /// <summary>
        /// Use to check if a boolean variable with the target name exists within this bank.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <returns>True if exists, false otherwise.</returns>
        public bool HasBoolean(string variableName) => m_booleans.TryGetValue(TrimVariableNameType(variableName), out _);

        /// <summary>
        /// Use to check if a variable with the target name exists within this bank.
        /// </summary>
        /// <param name="variableName">Target name.</param>
        /// <returns>True if exists, false otherwise.</returns>
        public bool HasAny(string variableName)
        {
            return (this.HasInt(variableName) ||
                    this.HasFloat(variableName) ||
                    this.HasString(variableName) ||
                    this.HasBoolean(variableName));
        }

        bool TryFindVariable<T1, T2>(string nameToSearch, Dictionary<string, T2> container, out T1 result) where T2 : Variable<T1>
        {
            result = default;

            T2 target = FindVariableOrNull<T1, T2>(nameToSearch, container);
            if (target == null) return false;

            result = target.Value;
            return true;
        }

        IntegerVariable FindIntegerOrNull(string nameToSearch)
        {
            return FindVariableOrNull<int, IntegerVariable>(nameToSearch, m_ints);
        }

        FloatVariable FindFloatOrNull(string nameToSearch)
        {
            return FindVariableOrNull<float, FloatVariable>(nameToSearch, m_floats);
        }

        StringVariable FindStringOrNull(string nameToSearch) 
        {
            return FindVariableOrNull<string, StringVariable>(nameToSearch, m_strings);
        }

        BooleanVariable FindBooleanOrNull(string nameToSearch)
        {
            return FindVariableOrNull<bool, BooleanVariable>(nameToSearch, m_booleans);
        }

        T2 FindVariableOrNull<T1, T2>(string nameToSearch, Dictionary<string, T2> container) where T2 : Variable<T1> 
        {
            if (container.TryGetValue(nameToSearch, out T2 value))
                return value;

            return null;
        }

        bool SetVariableIfExists<T1, T2>(string nameToSearch, T1 newValue, Dictionary<string, T2> container) where T2 : Variable<T1>
        {
            T2 target = FindVariableOrNull<T1, T2>(nameToSearch, container);
            if (target == null) return false;

            target.UnderlyingValue = newValue;
            return true;
        }

        /// <summary>
        /// Use to clone this bank.
        /// </summary>
        /// <returns>Returns the clone created.</returns>
        public VariableBank Clone()
        {
            VariableBank clone = Instantiate(this);

            clone.m_clonedFrom = this;
            clone.m_guid = m_guid;
            clone.OnDestroyAction = null;

            return clone;
        }

        private void OnDestroy()
        {
            OnDestroyAction?.Invoke();
        }
    }
}