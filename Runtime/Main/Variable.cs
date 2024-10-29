using com.absence.variablesystem.mutations;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.absence.variablesystem.internals
{
    /// <summary>
    /// The base class for any type of variable. You can override the effect of mutators by deriving this class. Or you can
    /// use it diretly as a generic class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Serializable]
    public abstract class Variable<T> : VariableBase
    {
        [SerializeField] 
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
                SetRaw(value);
            }
        }

        [SerializeField] protected bool m_bypassEvents;

        public Variable()
        {
            this.m_name = string.Empty;
            this.m_bypassEvents = false;
        }
        public Variable(string name, T value)
        {
            this.m_name = name;
            this.m_value = value;
            this.m_bypassEvents = false;
        }

        [SerializeField] protected List<Mutation<T>> m_mutations = new List<Mutation<T>>();

        /// <summary>
        /// Mutate this variable.
        /// </summary>
        /// <param name="mutation"></param>
        public void Mutate(Mutation<T> mutation)
        {
            RevertMutations();

            m_mutations.Add(mutation);
            mutation.OnAdd(this);

            ApplyMutations();
        }

        /// <summary>
        /// Remove a specific mutation from this variable.
        /// </summary>
        /// <param name="mutation"></param>
        public void Immutate(Mutation<T> mutation)
        {
            RevertMutations();

            if (m_mutations.Contains(mutation))
            {
                mutation.OnRemove(this);
                m_mutations.Remove(mutation);
            }

            ApplyMutations();
        }

        /// <summary>
        /// Clear all of the mutations on this variable.
        /// </summary>
        public void ClearMutations()
        {
            RevertMutations();
            m_mutations.Clear();
            ApplyMutations();
        }

        public void Refresh()
        {
            RevertMutations();
            ApplyMutations();
        }

        public void Set(T value, SetType setType = SetType.Baked)
        {
            switch (setType)
            {
                case SetType.Raw:
                    SetRaw(value);
                    break;
                case SetType.Baked:
                    SetBaked(value);
                    break;
                default:
                    break;
            }
        }

        protected virtual void SetRaw(T value)
        {
            T val = m_value;

            RevertMutations();

            m_value = value;

            ApplyMutations();

            RaiseValueChangeEvent(val, m_value);
        }

        protected virtual void SetBaked(T value)
        {
            T val = m_value;
            m_value = value;

            Refresh();

            RaiseValueChangeEvent(val, m_value);
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

        /// <summary>
        /// Use to define how this variable subtype handles the reverting process of mutations.
        /// </summary>
        protected virtual void RevertMutations()
        {
            T val = m_value;
            m_mutations.OrderByDescending(mut => mut.Priority).ToList().ForEach(mut2 => mut2.OnRevert(ref m_value));

            RaiseValueChangeEvent(val, Value);
        }

        /// <summary>
        /// Use to define how this variable subtype handles the applying process of mutations.
        /// </summary>
        protected virtual void ApplyMutations()
        {
            T val = m_value;
            m_mutations.OrderBy(mut => mut.Priority).ToList().ForEach(mut2 => mut2.OnApply(ref m_value));

            RaiseValueChangeEvent(val, Value);
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

        public void DisableValueChangeCallbacks() => m_bypassEvents = true;
        public void EnableValueChangeCallbacks() => m_bypassEvents = false;
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

        public static implicit operator T(Variable<T> c)
        {
            return c.Value;
        }
    }
}
