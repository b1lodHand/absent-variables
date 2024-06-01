using UnityEngine;

namespace com.absence.variablesystem
{
    [System.Serializable]
    public class VariableSetter
    {
        public enum SetType
        {
            [InspectorName("=")] SetTo = 0,
            [InspectorName("+")] IncrementBy = 1,
            [InspectorName("-")] DecrementBy = 2,
            [InspectorName("x")] MultipltyBy = 3,
            [InspectorName("÷")] DivideBy = 4,
        }

        [SerializeField] protected SetType m_setType = SetType.SetTo;
        [SerializeField] protected VariableBank m_targetBank;
        [SerializeField] protected string m_targetVariableName = VariableBank.Null;

        [SerializeField] protected int m_intValue;
        [SerializeField] protected float m_floatValue;
        [SerializeField] protected string m_stringValue;
        [SerializeField] protected bool m_boolValue;

        public virtual bool HasFixedBank => false;

        /// <summary>
        /// Use to set a fixed bank to this setter. This will cause the bank selector to disappear. You can:
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
        /// Sets the target variable in target <see cref="VariableBank"/> to intended value.
        /// </summary>
        public virtual void Perform()
        {
            if (m_targetBank == null) return;
            if (m_targetVariableName == VariableBank.Null) return;

            if (m_targetBank.HasInt(m_targetVariableName))
                Perform_Int();
            else if (m_targetBank.HasFloat(m_targetVariableName))
                Perform_Float();
            else if (m_targetBank.HasString(m_targetVariableName))
                Perform_String();
            else if (m_targetBank.HasBoolean(m_targetVariableName))
                Perform_Boolean();
        }

        protected virtual void Perform_Boolean()
        {
            m_targetBank.SetBoolean(m_targetVariableName, m_boolValue);
        }
        protected virtual void Perform_String()
        {
            m_targetBank.SetString(m_targetVariableName, m_stringValue);
        }
        protected virtual void Perform_Float()
        {
            var target = m_targetBank.GetFloat(m_targetVariableName);
            switch (m_setType)
            {
                case SetType.SetTo:
                    target.Value = m_floatValue;
                    break;
                case SetType.IncrementBy:
                    target.Value += m_floatValue;
                    break;
                case SetType.DecrementBy:
                    target.Value -= m_floatValue;
                    break;
                case SetType.MultipltyBy:
                    target.Value *= m_floatValue;
                    break;
                case SetType.DivideBy:
                    target.Value /= m_floatValue;
                    break;
                default:
                    break;
            }
        }
        protected virtual void Perform_Int()
        {
            var target = m_targetBank.GetInt(m_targetVariableName);
            switch (m_setType)
            {
                case SetType.SetTo:
                    target.Value = m_intValue;
                    break;
                case SetType.IncrementBy:
                    target.Value += m_intValue;
                    break;
                case SetType.DecrementBy:
                    target.Value -= m_intValue;
                    break;
                case SetType.MultipltyBy:
                    target.Value *= m_intValue;
                    break;
                case SetType.DivideBy:
                    target.Value /= m_intValue;
                    break;
                default:
                    break;
            }
        }

        public virtual VariableSetter Clone(VariableBank overrideBank)
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