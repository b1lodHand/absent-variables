using com.absence.variablesystem.builtin;
using System;
using System.Collections.Generic;

namespace com.absence.variablesystem.banksystembase
{
    [System.Serializable]
    public class OptimizedVariableBankHandle : IPrimitiveVariableContainer
    {
        VariableBank m_target;

        Dictionary<string, IntegerVariable> m_ints;
        Dictionary<string, FloatVariable> m_floats;
        Dictionary<string, StringVariable> m_strings;
        Dictionary<string, BooleanVariable> m_booleans;

        internal OptimizedVariableBankHandle(VariableBank target)
        {
            if (target == null)
                throw new Exception("Target bank cannot be null!");

            Initialize(target);
        }

        void Initialize(VariableBank target)
        {
            m_target = target;

            m_ints = new();
            m_floats = new();
            m_strings = new();
            m_booleans = new();

            foreach (var integer in target.Ints)
            {
                m_ints.Add(VariableBank.TrimVariableNameType(integer.Name), integer.Variable);
            }

            foreach (var floatingPoint in target.Floats)
            {
                m_floats.Add(VariableBank.TrimVariableNameType(floatingPoint.Name), floatingPoint.Variable);
            }

            foreach (var str in target.Strings)
            {
                m_strings.Add(VariableBank.TrimVariableNameType(str.Name), str.Variable);
            }

            foreach (var boolean in target.Booleans)
            {
                m_booleans.Add(VariableBank.TrimVariableNameType(boolean.Name), boolean.Variable);
            }
        }

        public bool GetBoolean(string variableName)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            return m_booleans[variableName].Value;
        }

        public float GetFloat(string variableName)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            return m_floats[variableName].Value;
        }

        public int GetInt(string variableName)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            return m_ints[variableName].Value;
        }

        public string GetString(string variableName)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            return m_strings[variableName].Value;
        }

        public BooleanVariable GetBooleanVariable(string variableName)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            return m_booleans[variableName];
        }

        public FloatVariable GetFloatVariable(string variableName)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            return m_floats[variableName];
        }

        public IntegerVariable GetIntVariable(string variableName)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            return m_ints[variableName];
        }

        public StringVariable GetStringVariable(string variableName)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            return m_strings[variableName];
        }

        public bool HasBoolean(string variableName)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            return m_booleans.ContainsKey(variableName);
        }

        public bool HasFloat(string variableName)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            return m_floats.ContainsKey(variableName);
        }

        public bool HasInt(string variableName)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            return m_ints.ContainsKey(variableName);
        }

        public bool HasString(string variableName)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            return m_strings.ContainsKey(variableName);
        }

        public bool SetBoolean(string variableName, bool newValue)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            if (!HasBoolean(variableName)) return false;

            m_booleans[variableName].UnderlyingValue = newValue;
            return true;
        }

        public bool SetFloat(string variableName, float newValue)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            if (!HasFloat(variableName)) return false;

            m_floats[variableName].UnderlyingValue = newValue;
            return true;
        }

        public bool SetInt(string variableName, int newValue)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            if (!HasInt(variableName)) return false;

            m_ints[variableName].UnderlyingValue = newValue;
            return true;
        }

        public bool SetString(string variableName, string newValue)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            if (!HasString(variableName)) return false;

            m_strings[variableName].UnderlyingValue = newValue;
            return true;
        }

        public bool TryGetBoolean(string variableName, out bool value)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            value = default;
            bool result = m_booleans.TryGetValue(variableName, out BooleanVariable boolean);
            if (result) value = boolean.Value;

            return result;
        }

        public bool TryGetFloat(string variableName, out float value)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            value = default;
            bool result = m_floats.TryGetValue(variableName, out FloatVariable floatingPoint);
            if (result) value = floatingPoint.Value;

            return result;
        }

        public bool TryGetInt(string variableName, out int value)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            value = default;
            bool result = m_ints.TryGetValue(variableName, out IntegerVariable integer);
            if (result) value = integer.Value;

            return result;
        }

        public bool TryGetString(string variableName, out string value)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            value = default;
            bool result = m_strings.TryGetValue(variableName, out StringVariable str);
            if (result) value = str.Value;

            return result;
        }

        public void AddValueChangeListenerToInt(string variableName, Action<VariableValueChangedCallbackContext<int>> callbackAction)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            m_ints[variableName].AddValueChangeListener(callbackAction);
        }

        public void AddValueChangeListenerToFloat(string variableName, Action<VariableValueChangedCallbackContext<float>> callbackAction)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            m_floats[variableName].AddValueChangeListener(callbackAction);
        }

        public void AddValueChangeListenerToString(string variableName, Action<VariableValueChangedCallbackContext<string>> callbackAction)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            m_strings[variableName].AddValueChangeListener(callbackAction);
        }

        public void AddValueChangeListenerToBoolean(string variableName, Action<VariableValueChangedCallbackContext<bool>> callbackAction)
        {
            variableName = VariableBank.TrimVariableNameType(variableName);

            m_booleans[variableName].AddValueChangeListener(callbackAction);
        }
    }
}
