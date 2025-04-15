using System;
using UnityEngine;

namespace com.absence.variablesystem.banksystembase
{
    /// <summary>
    /// The base class for setters.
    /// </summary>
    [System.Serializable]
    public abstract class VariableSetterBase
    {
        /// <summary>
        /// An enum for deciding which way the setting will work.
        /// </summary>
        public enum SetType
        {
            [InspectorName("=")] SetTo = 0,
            [InspectorName("+")] IncrementBy = 1,
            [InspectorName("-")] DecrementBy = 2,
            [InspectorName("x")] MultipltyBy = 3,
            [InspectorName("÷")] DivideBy = 4,
        }

        [SerializeField] protected SetType m_setType = SetType.SetTo;
        [SerializeField] protected string m_targetBankGuid;
        [SerializeField] protected string m_targetVariableName = VariableBank.Null;

#if UNITY_EDITOR
        [HideInInspector, SerializeReference] internal VariableNamePair m_targetVariableNamePair;
#endif 

        [SerializeField] protected int m_intValue;
        [SerializeField] protected float m_floatValue;
        [SerializeField] protected string m_stringValue;
        [SerializeField] protected bool m_boolValue;

        public virtual bool DontThrowExceptions => false;
        public virtual bool CanUseInEditMode => false;

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
        public SetType TypeOfSet
        {
            get
            {
                return m_setType;
            }

            set
            {
                m_setType = value;
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
        /// Override to define how this setter will find it's runtime bank.
        /// </summary>
        /// <returns>The runtime bank or null</returns>
        protected abstract IPrimitiveVariableContainer GetRuntimeBank();

        /// <summary>
        /// Sets the target variable in target <see cref="VariableBank"/> to intended value.
        /// </summary>
        public virtual void Perform()
        {
            if ((!CanUseInEditMode) && (!Application.isPlaying))
            {
                if (DontThrowExceptions) return;
                else throw new Exception("You cannot call Perform() on setters outside play mode!");
            }

            IPrimitiveVariableContainer bank = GetRuntimeBank();
            Perform(bank);
        }

        public virtual void Perform(IPrimitiveVariableContainer bank)
        {
            if (bank == null)
            {
                if (DontThrowExceptions) return;
                else throw new Exception("Target bank of the variable setter is null.");
            }

            if (m_targetVariableName == VariableBank.Null)
            {
                if (DontThrowExceptions) return;
                else throw new Exception("Target variable of the variable setter is null.");
            }

            if (bank.HasInt(m_targetVariableName))
                PerformForInt(bank);
            else if (bank.HasFloat(m_targetVariableName))
                PerformForFloat(bank);
            else if (bank.HasString(m_targetVariableName))
                PerformForString(bank);
            else if (bank.HasBoolean(m_targetVariableName))
                PerformForBoolean(bank);
        }

        #region Performs
        /// <summary>
        /// Override to define the logic for booleans.
        /// </summary>
        /// <param name="bank">Runtime bank.</param>
        protected virtual void PerformForBoolean(IPrimitiveVariableContainer bank)
        {
            if (!bank.SetBoolean(m_targetVariableName, m_boolValue))
            {
                if (DontThrowExceptions) return;
                else throw new Exception($"Target variable couldn't be found: '{m_targetVariableName}'");
            }
        }

        /// <summary>
        /// Override to define the logic for strings.
        /// </summary>
        /// <param name="bank">Runtime bank.</param>
        protected virtual void PerformForString(IPrimitiveVariableContainer bank)
        {
            if (!bank.SetString(m_targetVariableName, m_stringValue))
            {
                if (DontThrowExceptions) return;
                else throw new Exception($"Target variable couldn't be found: '{m_targetVariableName}'");
            }
        }

        /// <summary>
        /// Override to define the logic for floating points.
        /// </summary>
        /// <param name="bank">Runtime bank.</param>
        protected virtual void PerformForFloat(IPrimitiveVariableContainer bank)
        {
            if (!bank.TryGetFloat(m_targetVariableName, out float value))
            {
                if (DontThrowExceptions) return;
                else throw new Exception($"Target variable couldn't be found: '{m_targetVariableName}'");
            }

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

        /// <summary>
        /// Override to define the logic for integers.
        /// </summary>
        /// <param name="bank">Runtime bank.</param>
        protected virtual void PerformForInt(IPrimitiveVariableContainer bank)
        {
            if (!bank.TryGetInt(m_targetVariableName, out int value))
            {
                if (DontThrowExceptions) return;
                else throw new Exception($"Target variable couldn't be found: '{m_targetVariableName}'");
            }

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
