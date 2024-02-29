using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace com.absence.variablesystem
{
    public class VariableBank : ScriptableObject
    {
        public static readonly string Null = "null: null";

        [SerializeField] protected List<Variable_Integer> m_ints = new();
        [SerializeField] protected List<Variable_Float> m_floats = new();
        [SerializeField] protected List<Variable_String> m_strings = new();
        [SerializeField] protected List<Variable_Boolean> m_booleans = new();

        public List<Variable_Integer> Ints { get { return m_ints; } internal set { m_ints = value; } }
        public List<Variable_Float> Floats { get { return m_floats; } internal set { m_floats = value; } }
        public List<Variable_String> Strings { get { return m_strings; } internal set { m_strings = value; } }
        public List<Variable_Boolean> Booleans { get { return m_booleans; } internal set { m_booleans = value; } }

        public event Action OnDestroyAction;

        public List<string> GetAllVariableNames()
        {
            var totalCount = m_ints.Count + m_floats.Count + m_strings.Count + m_booleans.Count;
            var result = new List<string>();
            if (totalCount == 0) return result;

            m_ints.ConvertAll(v => v.Name).ToList().ForEach(k => result.Add(k));
            m_floats.ConvertAll(v => v.Name).ToList().ForEach(k => result.Add(k));
            m_strings.ConvertAll(v => v.Name).ToList().ForEach(k => result.Add(k));
            m_booleans.ConvertAll(v => v.Name).ToList().ForEach(k => result.Add(k));

            return result;
        }
        public List<string> GetAllVariableNamesWithTypes()
        {
            var totalCount = m_ints.Count + m_floats.Count + m_strings.Count + m_booleans.Count;
            var result = new List<string>();
            if (totalCount == 0) return result;

            m_ints.ConvertAll(v => v.Name).ToList().ForEach(k => result.Add($"int: {k}"));
            m_floats.ConvertAll(v => v.Name).ToList().ForEach(k => result.Add($"float: {k}"));
            m_strings.ConvertAll(v => v.Name).ToList().ForEach(k => result.Add($"string: {k}"));
            m_booleans.ConvertAll(v => v.Name).ToList().ForEach(k => result.Add($"bool: {k}"));

            return result;
        }

        public Variable_Integer GetInt(string variableName)
        {
            variableName = TrimVariableNameType(variableName);

            var check = m_ints.Where(v => v.Name == variableName).ToList();
            if (check.Count > 0) return check.FirstOrDefault();
            else return null;
        }
        public Variable_Float GetFloat(string variableName)
        {
            variableName = TrimVariableNameType(variableName);

            var check = m_floats.Where(v => v.Name == variableName).ToList();
            if (check.Count > 0) return check.FirstOrDefault();
            else return null;
        }
        public Variable_String GetString(string variableName)
        {
            variableName = TrimVariableNameType(variableName);

            var check = m_strings.Where(v => v.Name == variableName).ToList();
            if (check.Count > 0) return check.FirstOrDefault();
            else return null;
        }
        public Variable_Boolean GetBoolean(string variableName)
        {
            variableName = TrimVariableNameType(variableName);

            var check = m_booleans.Where(v => v.Name == variableName).ToList();
            if (check.Count > 0) return check.FirstOrDefault();
            else return null;
        }

        public bool SetInt(string variableName, int newValue)
        {
            variableName = TrimVariableNameType(variableName);

            var found = m_ints.Where(v => v.Name == variableName).FirstOrDefault();
            if(found == null) return false;

            found.Value = newValue;
            return true;
        }
        public bool SetFloat(string variableName, float newValue)
        {
            variableName = TrimVariableNameType(variableName);

            var found = m_floats.Where(v => v.Name == variableName).FirstOrDefault();
            if (found == null) return false;

            found.Value = newValue;
            return true;
        }
        public bool SetString(string variableName, string newValue)
        {
            variableName = TrimVariableNameType(variableName);

            var found = m_strings.Where(v => v.Name == variableName).FirstOrDefault();
            if (found == null) return false;

            found.Value = newValue;
            return true;
        }
        public bool SetBoolean(string variableName, bool newValue)
        {
            variableName = TrimVariableNameType(variableName);

            var found = m_booleans.Where(v => v.Name == variableName).FirstOrDefault();
            if (found == null) return false;

            found.Value = newValue;
            return true;
        }

        public bool HasInt(string variableName) => m_ints.Any(v => v.Name == TrimVariableNameType(variableName));
        public bool HasFloat(string variableName) => m_floats.Any(v => v.Name == TrimVariableNameType(variableName));
        public bool HasString(string variableName) => m_strings.Any(v => v.Name == TrimVariableNameType(variableName));
        public bool HasBoolean(string variableName) => m_booleans.Any(v => v.Name == TrimVariableNameType(variableName));
        public bool HasAny(string variableName)
        {
            return (this.HasInt(variableName) ||
                    this.HasFloat(variableName) ||
                    this.HasString(variableName) ||
                    this.HasBoolean(variableName));
        }

        public string TrimVariableNameType(string nameToTrim)
        {
            if (!nameToTrim.Contains(':')) return nameToTrim;
            return nameToTrim.Split(':')[1].Trim();
        }
        public string AddVariableNameType(string nameToAddType)
        {
            StringBuilder builder = new StringBuilder();
            if (this.HasInt(nameToAddType)) builder.Append("int: ");
            else if (this.HasFloat(nameToAddType)) builder.Append("float: ");
            else if (this.HasString(nameToAddType)) builder.Append("string: ");
            else if (this.HasBoolean(nameToAddType)) builder.Append("bool: ");

            builder.Append(" ");
            builder.Append(nameToAddType);

            return builder.ToString();
        }

        private void OnDestroy()
        {
            OnDestroyAction?.Invoke();
        }
    }
}