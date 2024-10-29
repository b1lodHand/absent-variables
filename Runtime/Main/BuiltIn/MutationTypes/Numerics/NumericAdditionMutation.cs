using com.absence.variablesystem.internals;

namespace com.absence.variablesystem.mutations.internals
{
    [System.Serializable]
    public class FloatAdditionMutation : Mutation<float>
    {
        public FloatAdditionMutation() : base()
        {
        }

        public FloatAdditionMutation(float mutationValue) : base(mutationValue)
        {
        }

        public FloatAdditionMutation(float mutationValue, AffectionMethod affectionMethod) : base(mutationValue, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public FloatAdditionMutation(float mutationValue, float duration) : base(mutationValue, duration)
        {
        }

        public FloatAdditionMutation(float mutationValue, AffectionMethod affectionMethod, float duration) : base(mutationValue, affectionMethod, duration)
        {
        }

        protected override int m_order => 0;
#endif

        public override void OnApply(ref float targetValue)
        {
            targetValue += Value;
        }

        public override void OnRevert(ref float targetValue)
        {
            targetValue -= Value;
        }
    }

    [System.Serializable]
    public class IntegerAdditionMutation : Mutation<int>
    {
        public IntegerAdditionMutation() : base()
        {
        }

        public IntegerAdditionMutation(int mutationValue) : base(mutationValue)
        {
        }

        public IntegerAdditionMutation(int mutationValue, AffectionMethod affectionMethod) : base(mutationValue, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public IntegerAdditionMutation(int mutationValue, float duration) : base(mutationValue, duration)
        {
        }

        public IntegerAdditionMutation(int mutationValue, AffectionMethod affectionMethod, float duration) : base(mutationValue, affectionMethod, duration)
        {
        }

        protected override int m_order => 0;
#endif

        public override void OnApply(ref int targetValue)
        {
            targetValue += Value;
        }

        public override void OnRevert(ref int targetValue)
        {
            targetValue -= Value;
        }
    }
}
