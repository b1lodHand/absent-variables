using com.absence.variablesystem.internals;
using com.absence.variablesystem.mutations;

namespace com.absence.variablesystem.builtin.mutations.internals
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

        public override void OnApply(ref bool targetValue)
        {
            targetValue = !targetValue;
        }

        public override void OnRevert(ref bool targetValue)
        {
            targetValue = !targetValue;
        }
    }
}
