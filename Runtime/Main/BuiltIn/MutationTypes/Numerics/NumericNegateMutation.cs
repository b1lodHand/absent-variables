namespace com.absence.variablesystem.mutations.builtin.internals
{
    public class FloatNegateMutation : Mutation<float>
    {
        public FloatNegateMutation() : base() { }

        public FloatNegateMutation(float mutationValue) : base(mutationValue)
        {
        }

        public override int Priority => 2;

        public override void OnAdd(ref float targetValue)
        {
            
        }

        public override void OnApply(ref float targetValue)
        {
            targetValue *= -1f;
        }

        public override void OnRemove(ref float targetValue)
        {
            
        }

        public override void OnRevert(ref float targetValue)
        {
            targetValue *= -1f;
        }
    }

    public class IntegerNegateMutation : Mutation<int>
    {
        public IntegerNegateMutation() : base() { }

        public IntegerNegateMutation(int mutationValue) : base(mutationValue)
        {
        }

        public override int Priority => 2;

        public override void OnAdd(ref int targetValue)
        {
            
        }

        public override void OnApply(ref int targetValue)
        {
            targetValue *= -1;
        }

        public override void OnRemove(ref int targetValue)
        {
            
        }

        public override void OnRevert(ref int targetValue)
        {
            targetValue *= -1;
        }
    }
}
