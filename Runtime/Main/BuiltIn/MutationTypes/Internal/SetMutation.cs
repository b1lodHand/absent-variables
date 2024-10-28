using com.absence.variablesystem.internals;
using com.absence.variablesystem.mutations;
using UnityEngine;

namespace com.absence.variablesystem.builtin.mutations.internals
{
    [System.Serializable]
    public class SetMutation<T> : Mutation<T>
    {
        [SerializeField] T m_initialValue;

        internal SetMutation() : base()
        {
        }

        public SetMutation(T mutationValue) : base(mutationValue)
        {
        }

        public SetMutation(T mutationValue, AffectionMethod affectionMethod) : base(mutationValue, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public SetMutation(T mutationValue, float duration) : base(mutationValue, duration)
        {
        }

        public SetMutation(T mutationValue, AffectionMethod affectionMethod, float duration) : base(mutationValue, affectionMethod, duration)
        {
        }
#endif

        protected override int m_order => 0;

        public override void OnAdd(Variable<T> variable)
        {
            base.OnAdd(variable);

            m_initialValue = variable.Value;
        }

        public override void OnApply(ref T targetValue)
        {
            m_initialValue = targetValue;
            targetValue = Value;
        }

        public override void OnRevert(ref T targetValue)
        {
            targetValue = m_initialValue;
        }
    }
}
