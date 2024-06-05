using com.absence.variablesystem.internals;
using com.absence.variablesystem.mutations;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.absence.variablesystem
{
    /// <summary>
    /// The base class for any type of variable. You can override the effect of mutators by deriving this class. Or you can
    /// use it diretly as a generic class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
                var previous = m_value;
                var context = new VariableValueChangedCallbackContext<T>() { previousValue = previous, newValue = value };
                m_onValueChanged?.Invoke(context);
                m_value = value;
            }
        }

        protected List<Mutation<T>> m_mutations  = new List<Mutation<T>>();

        /// <summary>
        /// Mutate this variable.
        /// </summary>
        /// <param name="mutation"></param>
        public void AddMutation(Mutation<T> mutation)
        {
            RevertMutations();
            m_mutations.Add(mutation);
            ApplyMutations();
        }

        /// <summary>
        /// Remove a specific mutation from this variable.
        /// </summary>
        /// <param name="mutation"></param>
        public void RemoveMutation(Mutation<T> mutation)
        {
            RevertMutations();
            if(m_mutations.Contains(mutation)) m_mutations.Remove(mutation);
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

        /// <summary>
        /// Use to define how this variable subtype handles the reverting process of mutations.
        /// </summary>
        protected abstract void RevertMutations();

        /// <summary>
        /// Use to define how this variable subtype handles the applying process of mutations.
        /// </summary>
        protected abstract void ApplyMutations();

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
