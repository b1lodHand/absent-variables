namespace com.absence.variablesystem
{
    [System.Serializable]
    public sealed class FixedVariableSetter : BaseVariableSetter
    {
        public override bool HasFixedBank => true;

        /// <summary>
        /// Use to clone this comparer.
        /// </summary>
        /// <param name="overrideBank">New bank to use with the clone.</param>
        /// <returns>Returns a clone comparer which has the same values with the original.</returns>
        public FixedVariableSetter Clone(VariableBank overrideBank)
        {
            FixedVariableSetter clone = new();

            clone.m_boolValue = m_boolValue;
            clone.m_floatValue = m_floatValue;
            clone.m_intValue = m_intValue;
            clone.m_stringValue = m_stringValue;

            clone.m_setType = m_setType;
            clone.m_targetVariableName = m_targetVariableName;

            clone.SetFixedBank(overrideBank);

            return clone;
        }
    }
}
