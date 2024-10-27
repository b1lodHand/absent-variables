namespace com.absence.variablesystem.mutations.builtin.internals
{
    public class FloatAdditionMutation : Mutation<float>
    {
        public FloatAdditionMutation(float mutationValue) : base(mutationValue)
        {
        }

        public override int Priority => 0;

        public override void OnAdd(ref float targetValue)
        {
            
        }

        public override void OnApply(ref float targetValue)
        {
            targetValue += Value;
        }

        public override void OnRemove(ref float targetValue)
        {
            
        }

        public override void OnRevert(ref float targetValue)
        {
            targetValue -= Value;
        }
    }

    public class IntegerAdditionMutation : Mutation<float>
    {
        public IntegerAdditionMutation(float mutationValue) : base(mutationValue)
        {
        }

        public override int Priority => 0;

        public override void OnAdd(ref float targetValue)
        {
           
        }

        public override void OnApply(ref float targetValue)
        {
            targetValue += Value;
        }

        public override void OnRemove(ref float targetValue)
        {
            
        }

        public override void OnRevert(ref float targetValue)
        {
            targetValue -= Value;
        }
    }
}
