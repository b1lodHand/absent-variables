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
                m_ints.Add(integer.Name, integer.Variable);
            }

            foreach (var floatingPoint in target.Floats)
            {
                m_floats.Add(floatingPoint.Name, floatingPoint.Variable);
            }

            foreach (var str in target.Strings)
            {
                m_strings.Add(str.Name, str.Variable);
            }

            foreach (var boolean in target.Booleans)
            {
                m_booleans.Add(boolean.Name, boolean.Variable);
            }
        }

        public BooleanVariable GetBoolean(string variableName)
        {
            return m_booleans[variableName];
        }

        public FloatVariable GetFloat(string variableName)
        {
            return m_floats[variableName];
        }

        public IntegerVariable GetInt(string variableName)
        {
            return m_ints[variableName];
        }

        public StringVariable GetString(string variableName)
        {
            return m_strings[variableName];
        }

        public bool HasBoolean(string variableName)
        {
            return m_booleans.ContainsKey(variableName);
        }

        public bool HasFloat(string variableName)
        {
            return m_floats.ContainsKey(variableName);
        }

        public bool HasInt(string variableName)
        {
            return m_ints.ContainsKey(variableName);
        }

        public bool HasString(string variableName)
        {
            return m_strings.ContainsKey(variableName);
        }

        public bool SetBoolean(string variableName, bool newValue)
        {
            if (!HasBoolean(variableName)) return false;

            m_booleans[variableName].UnderlyingValue = newValue;
            return true;
        }

        public bool SetFloat(string variableName, float newValue)
        {
            if (!HasFloat(variableName)) return false;

            m_floats[variableName].UnderlyingValue = newValue;
            return true;
        }

        public bool SetInt(string variableName, int newValue)
        {
            if (!HasInt(variableName)) return false;

            m_ints[variableName].UnderlyingValue = newValue;
            return true;
        }

        public bool SetString(string variableName, string newValue)
        {
            if (!HasString(variableName)) return false;

            m_strings[variableName].UnderlyingValue = newValue;
            return true;
        }

        public bool TryGetBoolean(string variableName, out bool value)
        {
            value = default;
            bool result = m_booleans.TryGetValue(variableName, out BooleanVariable boolean);
            if (result) value = boolean.Value;

            return result;
        }

        public bool TryGetFloat(string variableName, out float value)
        {
            value = default;
            bool result = m_floats.TryGetValue(variableName, out FloatVariable floatingPoint);
            if (result) value = floatingPoint.Value;

            return result;
        }

        public bool TryGetInt(string variableName, out int value)
        {
            value = default;
            bool result = m_ints.TryGetValue(variableName, out IntegerVariable integer);
            if (result) value = integer.Value;

            return result;
        }

        public bool TryGetString(string variableName, out string value)
        {
            value = default;
            bool result = m_strings.TryGetValue(variableName, out StringVariable str);
            if (result) value = str.Value;

            return result;
        }
    }
}
