using com.absence.variablesystem.internals;

namespace com.absence.variablesystem.mutations.internals
{
    [System.Serializable]
    public class FloatMultiplicationMutation : Mutation<float>
    {
        public FloatMultiplicationMutation() : base()
        {
        }

        public FloatMultiplicationMutation(float mutationValue) : base(mutationValue)
        {
        }

        public FloatMultiplicationMutation(float mutationValue, AffectionMethod affectionMethod) : base(mutationValue, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public FloatMultiplicationMutation(float mutationValue, float duration) : base(mutationValue, duration)
        {
        }

        public FloatMultiplicationMutation(float mutationValue, AffectionMethod affectionMethod, float duration) : base(mutationValue, affectionMethod, duration)
        {
        }
#endif

        protected override int m_order => 1;


        public override void OnApply(ref float targetValue)
        {
            targetValue *= Value;
        }

        public override void OnRevert(ref float targetValue)
        {
            targetValue /= Value;
        }
    }

    [System.Serializable]
    public class IntegerMultiplicationMutation : Mutation<int>
    {
        public IntegerMultiplicationMutation() : base()
        {
        }

        public IntegerMultiplicationMutation(int mutationValue) : base(mutationValue)
        {
        }

        public IntegerMultiplicationMutation(int mutationValue, AffectionMethod affectionMethod) : base(mutationValue, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public IntegerMultiplicationMutation(int mutationValue, float duration) : base(mutationValue, duration)
        {
        }

        public IntegerMultiplicationMutation(int mutationValue, AffectionMethod affectionMethod, float duration) : base(mutationValue, affectionMethod, duration)
        {
        }
#endif

        protected override int m_order => 1;

        public override void OnApply(ref int targetValue)
        {
            targetValue *= Value;
        }

        public override void OnRevert(ref int targetValue)
        {
            targetValue /= Value;
        }
    }
}
