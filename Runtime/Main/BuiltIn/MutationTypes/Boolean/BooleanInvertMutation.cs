using com.absence.variablesystem.internals;

namespace com.absence.variablesystem.mutations.internals
{
    [System.Serializable]
    public class BooleanInvertMutation : Mutation<bool>
    {
        public BooleanInvertMutation() : base(false)
        {
        }

        public BooleanInvertMutation(AffectionMethod affectionMethod) : base(false, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public BooleanInvertMutation(float duration) : base(false, duration)
        {
        }

        public BooleanInvertMutation(AffectionMethod affectionMethod, float duration)
            : base(false, affectionMethod, duration)
        {
        }
#endif

        protected override int m_order => 0;

        public override bool Apply(bool initialValue)
        {
            return !initialValue;
        }
    }
}
