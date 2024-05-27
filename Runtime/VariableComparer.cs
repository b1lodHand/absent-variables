using UnityEngine;

namespace com.absence.variablesystem
{
    [System.Serializable]
    public class VariableComparer
    {
        public enum ComparisonType
        {
            [InspectorName("<")] LessThan = 0,
            [InspectorName("≤")] LessOrEqual = 1,
            [InspectorName("=")] EqualsTo = 2,
            [InspectorName("≠")] NotEquals = 3,
            [InspectorName("≥")] GreaterOrEqual = 4,
            [InspectorName(">")] GreaterThan = 5,
        }

        [SerializeField] protected ComparisonType m_comparisonType = ComparisonType.EqualsTo;
        [SerializeField] public VariableBank m_targetBank;
        [SerializeField] protected string m_targetVariableName = VariableBank.Null;

        [SerializeField] protected int m_intValue;
        [SerializeField] protected float m_floatValue;
        [SerializeField] protected string m_stringValue;
        [SerializeField] protected bool m_boolValue;

        [SerializeField] protected VariableBank m_fixedBank = null;

        public virtual bool GetResult()
        {
            var result = true;

            if (m_targetBank == null) return result;
            if (m_targetVariableName == VariableBank.Null) return result;

            if (m_targetBank.HasString(m_targetVariableName))
                result = m_targetBank.GetString(m_targetVariableName).Value == m_stringValue;
            else if (m_targetBank.HasBoolean(m_targetVariableName))
                result = m_targetBank.GetBoolean(m_targetVariableName).Value == m_boolValue;
            else if (m_targetBank.HasInt(m_targetVariableName))
                result = CompareNumerics(m_targetBank.GetInt(m_targetVariableName).Value, m_intValue);
            else if (m_targetBank.HasFloat(m_targetVariableName))
                result = CompareNumerics(m_targetBank.GetFloat(m_targetVariableName).Value, m_floatValue);

            return result;
        }

        bool CompareNumerics(int a, int b)
        {
            switch (m_comparisonType)
            {
                case ComparisonType.LessThan:
                    return a < b;
                case ComparisonType.LessOrEqual:
                    return a <= b;
                case ComparisonType.EqualsTo:
                    return a == b;
                case ComparisonType.GreaterOrEqual:
                    return a >= b;
                case ComparisonType.GreaterThan:
                    return a > b;
                default:
                    return false;
            }
        }
        bool CompareNumerics(float a, float b)
        {
            switch (m_comparisonType)
            {
                case ComparisonType.LessThan:
                    return a < b;
                case ComparisonType.LessOrEqual:
                    return a <= b;
                case ComparisonType.EqualsTo:
                    return a == b;
                case ComparisonType.GreaterOrEqual:
                    return a >= b;
                case ComparisonType.GreaterThan:
                    return a > b;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Use to set a fixed bank to this comparer. This will cause the bank selector to disappear. You can:
        /// <code>
        /// SetFixedBank(null);
        /// </code>
        /// To get bak the bank selector.
        /// </summary>
        /// <param name="fixedBank"></param>
        public void SetFixedBank(VariableBank fixedBank)
        {
            if(fixedBank == null)
            {
                m_fixedBank = null;
                return;
            }

            m_fixedBank = fixedBank;
            m_targetBank = fixedBank;
        }

        /// <summary>
        /// Use to clone this comparer.
        /// </summary>
        /// <param name="overrideBank">New bank to use with the clone.</param>
        /// <returns>Returns a clone comparer which has the same values with the original.</returns>
        public VariableComparer Clone(VariableBank overrideBank)
        {
            VariableComparer clone = new();

            clone.m_boolValue = m_boolValue;
            clone.m_floatValue = m_floatValue;
            clone.m_intValue = m_intValue;
            clone.m_stringValue = m_stringValue;

            clone.m_comparisonType = m_comparisonType;
            clone.m_targetVariableName = m_targetVariableName;

            clone.m_targetBank = overrideBank;

            return clone;
        }
    }
}