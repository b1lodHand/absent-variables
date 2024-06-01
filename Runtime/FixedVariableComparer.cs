namespace com.absence.variablesystem
{
    [System.Serializable]
    public sealed class FixedVariableComparer : BaseVariableComparer
    {
        public override bool HasFixedBank => true;

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
            if (!HasFixedBank) return;

            m_targetBank = fixedBank;
        }

        /// <summary>
        /// Use to clone this comparer.
        /// </summary>
        /// <param name="overrideBank">New bank to use with the clone.</param>
        /// <returns>Returns a clone comparer which has the same values with the original.</returns>
        public FixedVariableComparer Clone(VariableBank overrideBank)
        {
            FixedVariableComparer clone = new();

            clone.m_boolValue = m_boolValue;
            clone.m_floatValue = m_floatValue;
            clone.m_intValue = m_intValue;
            clone.m_stringValue = m_stringValue;

            clone.m_comparisonType = m_comparisonType;
            clone.m_targetVariableName = m_targetVariableName;

            clone.SetFixedBank(overrideBank);

            return clone;
        }
    }
}
