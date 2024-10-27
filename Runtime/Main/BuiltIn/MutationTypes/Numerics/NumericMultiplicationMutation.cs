namespace com.absence.variablesystem.mutations.builtin.internals
{
    public class FloatMultiplicationMutation : Mutation<float>
    {
        public FloatMultiplicationMutation(float mutationValue) : base(mutationValue)
        {
        }

        public override int Priority => 1;

        public override void OnAdd(ref float targetValue)
        {
            
        }

        public override void OnApply(ref float targetValue)
        {
            targetValue *= Value;
        }

        public override void OnRemove(ref float targetValue)
        {
            
        }

        public override void OnRevert(ref float targetValue)
        {
            targetValue /= Value;
        }
    }

    public class IntegerMultiplicationMutation : Mutation<int>
    {
        public IntegerMultiplicationMutation(int mutationValue) : base(mutationValue)
        {
        }

        public override int Priority => 1;

        public override void OnAdd(ref int targetValue)
        {
            
        }

        public override void OnApply(ref int targetValue)
        {
            targetValue *= Value;
        }

        public override void OnRemove(ref int targetValue)
        {
            
        }

        public override void OnRevert(ref int targetValue)
        {
            targetValue /= Value;
        }
    }
}
