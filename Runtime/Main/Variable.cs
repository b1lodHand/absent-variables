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
    public abstract class Variable<T> : VariableBase
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
                RevertMutations();

                if (!m_bypassEvents)
                {
                    var previous = m_value;
                    var context = new VariableValueChangedCallbackContext<T>() { previousValue = previous, newValue = value };
                    m_onValueChanged?.Invoke(context);
                }

                m_value = value;

                ApplyMutations();
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

            var context = new VariableValueChangedCallbackContext<T>()
            {
                previousValue = val,
                newValue = m_value
            };

            m_onValueChanged?.Invoke(context);
        }

        /// <summary>
        /// Use to define how this variable subtype handles the applying process of mutations.
        /// </summary>
        protected virtual void ApplyMutations()
        {
            T val = m_value;
            m_mutations.OrderBy(mut => mut.Priority).ToList().ForEach(mut2 => mut2.OnApply(ref m_value));

            var context = new VariableValueChangedCallbackContext<T>()
            {
                previousValue = val,
                newValue = m_value
            };

            m_onValueChanged?.Invoke(context);
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

        public static implicit operator T(Variable<T> c)
        {
            return c.Value;
        }
    }

    /// <summary>
    /// Used for the event system of variables.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VariableValueChangedCallbackContext<T>
    {
        public T previousValue { get; set; }
        public T newValue { get; set; }
    }
}
