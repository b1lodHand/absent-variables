using com.absence.variablesystem.internals;

namespace com.absence.variablesystem.mutations.internals
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
#endif
        protected override int m_order => 2;

        public override float Apply(float initialValue)
        {
            return -initialValue;
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
#endif

        protected override int m_order => 2;

        public override int Apply(int initialValue)
        {
            return -initialValue;
        }
    }
}
