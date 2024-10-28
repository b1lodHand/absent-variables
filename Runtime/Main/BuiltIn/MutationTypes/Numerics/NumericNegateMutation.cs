using com.absence.variablesystem.internals;
using com.absence.variablesystem.mutations;

namespace com.absence.variablesystem.builtin.mutations.internals
{
    [System.Serializable]
    public class FloatNegateMutation : Mutation<float>
    {
        public FloatNegateMutation() : base() 
        { 
        }

        public FloatNegateMutation(float mutationValue) : base(mutationValue)
        {
        }

        public FloatNegateMutation(float mutationValue, AffectionMethod affectionMethod) : base(mutationValue, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public FloatNegateMutation(float mutationValue, float duration) : base(mutationValue, duration)
        {
        }

        public FloatNegateMutation(float mutationValue, AffectionMethod affectionMethod, float duration) : base(mutationValue, affectionMethod, duration)
        {
        }

        protected override int m_order => 2;
#endif

        public override void OnApply(ref float targetValue)
        {
            targetValue *= -1f;
        }

        public override void OnRevert(ref float targetValue)
        {
            targetValue *= -1f;
        }
    }

    [System.Serializable]
    public class IntegerNegateMutation : Mutation<int>
    {
        public IntegerNegateMutation() : base() 
        { 
        }

        public IntegerNegateMutation(int mutationValue) : base(mutationValue)
        {
        }

        public IntegerNegateMutation(int mutationValue, AffectionMethod affectionMethod) : base(mutationValue, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public IntegerNegateMutation(int mutationValue, float duration) : base(mutationValue, duration)
        {
        }

        public IntegerNegateMutation(int mutationValue, AffectionMethod affectionMethod, float duration) : base(mutationValue, affectionMethod, duration)
        {
        }

        protected override int m_order => 2;
#endif

        public override void OnApply(ref int targetValue)
        {
            targetValue *= -1;
        }

        public override void OnRevert(ref int targetValue)
        {
            targetValue *= -1;
        }
    }
}
