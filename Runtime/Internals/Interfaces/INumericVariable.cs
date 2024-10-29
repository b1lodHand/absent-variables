namespace com.absence.variablesystem.internals
{
    public interface INumericVariable<T>
    {
        public void Add(T amount, SetType setType = SetType.Baked);
        public void Multiply(T multiplier, SetType setType = SetType.Baked);
        public void Negate(SetType setType = SetType.Baked);
    }
}
