using System;
using UnityEngine;

namespace com.absence.variablesystem.banksystembase
{
    /// <summary>
    /// The base class for comparers.
    /// </summary>
    [System.Serializable]
    public abstract class VariableComparerBase
    {
        /// <summary>
        /// An enum for deciding how the comparison will get performed.
        /// </summary>
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
        [SerializeField] protected string m_targetBankGuid;
        [SerializeField] protected string m_targetVariableName = VariableBank.Null;

        [SerializeField] protected int m_intValue;
        [SerializeField] protected float m_floatValue;
        [SerializeField] protected string m_stringValue;
        [SerializeField] protected bool m_boolValue;

        [SerializeField] protected VariableBank m_cachedBank;

        public virtual bool DontThrowExceptions => false;
        public virtual bool CanUseInEditMode => false;
        public virtual bool ReturnTrueOnException => true;
        public virtual bool BankAsDirectReference => false;
        public virtual bool CacheBankDirectly => false;
        
        public string TargetVariableName
        {
            get
            {
                return m_targetVariableName;
            }

            set
            {
                m_targetVariableName = value;
            }
        }
        public ComparisonType TypeOfComparison
        {
            get
            {
                return m_comparisonType;
            }

            set
            {
                m_comparisonType = value;
            }
        }
        public int IntValue
        {
            get
            {
                return m_intValue;
            }

            set
            {
                m_intValue = value;
            }
        }
        public float FloatValue
        {
            get
            {
                return m_floatValue;
            }

            set
            {
                m_floatValue = value;
            }
        }
        public string StringValue
        {
            get
            {
                return m_stringValue;
            }

            set
            {
                m_stringValue = value;
            }
        }
        public bool BooleanValue
        {
            get
            {
                return m_boolValue;
            }

            set
            {
                m_boolValue = value;
            }
        }

        /// <summary>
        /// Will the bank selector be hidden in the editor?
        /// </summary>
        public abstract bool HasFixedBank { get; }

        /// <summary>
        /// Override to define how this comparer will find it's runtime bank.
        /// </summary>
        /// <returns>The runtime bank or null</returns>
        protected abstract IPrimitiveVariableContainer GetRuntimeBank();

        /// <summary>
        /// Use to get the result of the comparer. <b>Runtime only.</b>
        /// </summary>
        /// <returns>Result of the comparer. Returns true directly if anything goes wrong.</returns>
        public virtual bool GetResult()
        {
            if ((!CanUseInEditMode) && (!Application.isPlaying))
            {
                if (DontThrowExceptions) return ReturnTrueOnException;
                else throw new Exception("You cannot call GetResult() on comparers outside play mode!");
            }

            IPrimitiveVariableContainer bank = CacheBankDirectly ?
                m_cachedBank : GetRuntimeBank();

            return GetResult(bank);
        }

        public virtual bool GetResult(IPrimitiveVariableContainer bank)
        {
            bool result = true;

            if (bank == null)
            {
                if (DontThrowExceptions) return ReturnTrueOnException;
                else throw new Exception("Target bank of the variable comparer is null.");
            }

            if (m_targetVariableName == VariableBank.Null)
            {
                if (DontThrowExceptions) return ReturnTrueOnException;
                else throw new Exception("Target variable of the variable comparer is null.");
            }

            if (bank.TryGetString(m_targetVariableName, out string stringValue)) result = (stringValue == m_stringValue);
            else if (bank.TryGetBoolean(m_targetVariableName, out bool boolValue)) result = (boolValue == m_boolValue);
            else if (bank.TryGetInt(m_targetVariableName, out int intValue)) result = CompareNumerics(intValue, m_intValue);
            else if (bank.TryGetFloat(m_targetVariableName, out float floatValue)) result = CompareNumerics(floatValue, m_floatValue);

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
    }
}
