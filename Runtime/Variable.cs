using System;
using UnityEngine;

namespace com.absence.variablesystem
{
    public class Variable<T>
    {
        protected event Action<VariableValueChangedCallbackContext<T>> m_onValueChanged;

        [SerializeField] protected string m_name;
        public string Name { get => m_name; protected set => m_name = value; }

        [SerializeField] protected T m_value;
        public T Value
        {
            get
            {
                return m_value;
            }

            set
            {
                var previous = m_value;
                var context = new VariableValueChangedCallbackContext<T>() { previousValue = previous, newValue = value };
                m_onValueChanged?.Invoke(context);
                m_value = value;
            }
        }

        public void RegisterOnValueChangedEvent(Action<VariableValueChangedCallbackContext<T>> evt)
        {
            m_onValueChanged += evt;
        }

        public void UnregisterOnValueChangedEvent(Action<VariableValueChangedCallbackContext<T>> evt)
        {
            m_onValueChanged -= evt;
        }
    }

    [System.Serializable] public class Variable_Integer : Variable<int> { }
    [System.Serializable] public class Variable_Float : Variable<float> { }
    [System.Serializable] public class Variable_String : Variable<string> { }
    [System.Serializable] public class Variable_Boolean : Variable<bool> { }

    public class VariableValueChangedCallbackContext<T>
    {
        public T previousValue { get; set; }
        public T newValue { get; set; }
    }
}
