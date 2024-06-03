using System;
using UnityEngine;

namespace com.absence.variablesystem.internals
{
    [System.Serializable]
    public abstract class BaseVariableSetter
    {
        public enum SetType
        {
            [InspectorName("=")] SetTo = 0,
            [InspectorName("+")] IncrementBy = 1,
            [InspectorName("-")] DecrementBy = 2,
            [InspectorName("x")] MultipltyBy = 3,
            [InspectorName("�")] DivideBy = 4,
        }

        [SerializeField] protected SetType m_setType = SetType.SetTo;
        [SerializeField] protected string m_targetBankGuid;
        [SerializeField] protected string m_targetVariableName = VariableBank.Null;

        [SerializeField] protected int m_intValue;
        [SerializeField] protected float m_floatValue;
        [SerializeField] protected string m_stringValue;
        [SerializeField] protected bool m_boolValue;

        public abstract bool HasFixedBank { get; }

        /// <summary>
        /// Sets the target variable in target <see cref="VariableBank"/> to intended value.
        /// </summary>
        public virtual void Perform()
        {
            if (!Application.isPlaying) throw new Exception("You cannot call GetResult() on comparers outside play mode!");

            VariableBank bank = VariableBank.GetClone(m_targetBankGuid);

            if (bank == null) return;
            if (m_targetVariableName == VariableBank.Null) return;

            if (bank.HasInt(m_targetVariableName))
                Perform_Int(bank);
            else if (bank.HasFloat(m_targetVariableName))
                Perform_Float(bank);
            else if (bank.HasString(m_targetVariableName))
                Perform_String(bank);
            else if (bank.HasBoolean(m_targetVariableName))
                Perform_Boolean(bank);
        }

        #region Performs
        protected virtual void Perform_Boolean(VariableBank bank)
        {
            bank.SetBoolean(m_targetVariableName, m_boolValue);
        }
        protected virtual void Perform_String(VariableBank bank)
        {
            bank.SetString(m_targetVariableName, m_stringValue);
        }
        protected virtual void Perform_Float(VariableBank bank)
        {
            if (!bank.TryGetFloat(m_targetVariableName, out float value)) return;

            switch (m_setType)
            {
                case SetType.SetTo:
                    value = m_floatValue;
                    break;
                case SetType.IncrementBy:
                    value += m_floatValue;
                    break;
                case SetType.DecrementBy:
                    value -= m_floatValue;
                    break;
                case SetType.MultipltyBy:
                    value *= m_floatValue;
                    break;
                case SetType.DivideBy:
                    value /= m_floatValue;
                    break;
                default:
                    break;
            }

            bank.SetFloat(m_targetVariableName, value);
        }
        protected virtual void Perform_Int(VariableBank bank)
        {
            if (!bank.TryGetInt(m_targetVariableName, out int value)) return;

            switch (m_setType)
            {
                case SetType.SetTo:
                    value = m_intValue;
                    break;
                case SetType.IncrementBy:
                    value += m_intValue;
                    break;
                case SetType.DecrementBy:
                    value -= m_intValue;
                    break;
                case SetType.MultipltyBy:
                    value *= m_intValue;
                    break;
                case SetType.DivideBy:
                    value /= m_intValue;
                    break;
                default:
                    break;
            }

            bank.SetInt(m_targetVariableName, value);
        }
        #endregion
    }
}
