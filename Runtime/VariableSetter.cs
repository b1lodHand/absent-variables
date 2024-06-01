namespace com.absence.variablesystem
{
    [System.Serializable]
    public sealed class VariableSetter : BaseVariableSetter
    {
        public override bool HasFixedBank => false;

        /// <summary>
        /// Use to clone this setter.
        /// </summary>
        /// <param name="overrideBank">Bank of the cloned setter.</param>
        /// <returns></returns>
        public VariableSetter Clone(VariableBank overrideBank)
        {
            VariableSetter clone = new();

            clone.m_boolValue = m_boolValue;
            clone.m_floatValue = m_floatValue;
            clone.m_intValue = m_intValue;
            clone.m_stringValue = m_stringValue;

            clone.m_setType = m_setType;
            clone.m_targetVariableName = m_targetVariableName;

            clone.m_targetBank = overrideBank;

            return clone;
        }
    }

}