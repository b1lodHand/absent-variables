using com.absence.variablesystem.internals;
using com.absence.variablesystem.mutations;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.absence.variablesystem
{
    /// <summary>
    /// The base class for any type of variable. You can override the effect of mutators by deriving this class. Or you can
    /// use it diretly as a generic class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Serializable]
    public class Variable<T> : VariableBase
    {
        [SerializeField] 
        protected event Action<VariableValueChangedCallbackContext<T>> m_onValueChanged;

        [SerializeField] protected T m_underlyingValue;
        [SerializeField] protected T m_value;

        public List<Mutation<T>> MutationsInOrder => m_mutations.OrderBy(mut => mut.Priority).ToList();

        public T Value
        {
            get
            {
                return m_value;
            }
        }

        public T UnderlyingValue
        {
            get
            {
                return m_underlyingValue;
            }

            set
            {
                SetRaw(value);
            }
        }

        [SerializeField] protected bool m_bypassEvents;

        public Variable()
        {
            this.m_underlyingValue = default;
            this.m_bypassEvents = false;

            Refresh();
        }
        public Variable(T value)
        {
            this.m_underlyingValue = value;
            this.m_bypassEvents = false;

            Refresh();
        }

        [SerializeField] protected List<Mutation<T>> m_mutations = new List<Mutation<T>>();

        /// <summary>
        /// Mutate this variable.
        /// </summary>
        /// <param name="mutation"></param>
        public void Mutate(Mutation<T> mutation)
        {
            m_mutations.Add(mutation);
            mutation.OnAdd(this);

            Refresh();
        }
        /// <summary>
        /// Remove a specific mutation from this variable.
        /// </summary>
        /// <param name="mutation"></param>
        public void Immutate(Mutation<T> mutation)
        {
            if (m_mutations.Contains(mutation))
            {
                mutation.OnRemove(this);
                m_mutations.Remove(mutation);
            }

            Refresh();
        }

        /// <summary>
        /// Clear all of the mutations on this variable.
        /// </summary>
        public void ClearMutations()
        {
            m_mutations.Clear();
            Refresh();
        }
        /// <summary>
        /// Use to fetch <see cref="Value"/> according to the current modifiers.
        /// </summary>
        public void Refresh()
        {
            ApplyMutations();
        }

        protected void CopyMutations(Variable<T> copyFrom)
        {
            m_mutations = new List<Mutation<T>>(copyFrom.m_mutations);
        }
        protected T1 WithMutationsOf<T1>(T1 other) where T1 : Variable<T>
        {
            CopyMutations(other);
            Refresh();
            return (T1)this;
        }

        public void SetUnderlyingValueWithoutCallbacks(T newValue)
        {
            DisableValueChangeCallbacks();

            SetRaw(newValue);

            EnableValueChangeCallbacks();
        }

        /// <summary>
        /// Get notified when the value of this variable changes.
        /// </summary>
        /// <param name="evt"></param>
        public void AddValueChangeListener(Action<VariableValueChangedCallbackContext<T>> evt)
        {
            m_onValueChanged += evt;
        }
        /// <summary>
        /// Remove the notification you've added.
        /// </summary>
        /// <param name="evt"></param>
        public void RemoveValueChangeListener(Action<VariableValueChangedCallbackContext<T>> evt)
        {
            m_onValueChanged -= evt;
        }

        internal void DisableValueChangeCallbacks() => m_bypassEvents = true;
        internal void EnableValueChangeCallbacks() => m_bypassEvents = false;

        protected virtual void SetRaw(T value)
        {
            T val = m_underlyingValue;
            m_underlyingValue = value;

            Refresh();

            RaiseValueChangeEvent(val, Value);
        }
        protected virtual void ApplyMutations()
        {
            List<Mutation<T>> mutations = MutationsInOrder;

            T val = m_underlyingValue;
            for (int i = 0; i < mutations.Count; i++)
            {
                Mutation<T> current = mutations[i];
                val = current.Apply(val);
            }

            m_value = val;

            RaiseValueChangeEvent(val, Value);
        }
        protected void RaiseValueChangeEvent(T previousValue, T currentValue)
        {
            if (m_bypassEvents) return;

            var context = new VariableValueChangedCallbackContext<T>()
            {
                previousValue = previousValue,
                newValue = currentValue
            };

            m_onValueChanged?.Invoke(context);
        }

        public virtual bool ValueEquals(Variable<T> other)
        {
            return this.Value.Equals(other.Value);
        }

        public static explicit operator Variable<T>(T raw)
        {
            return new Variable<T>(raw);
        }
    }
}
