namespace com.absence.variablesystem.mutations
{
    /// <summary>
    /// Used for changing a variable's value with a reference on that change. With this, you can revert any of your changes after in game.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Serializable]
    public abstract class Mutation<T>
    {
        public T Value { get; private set; }
        public abstract int Priority { get; }

        public abstract void OnAdd(ref T targetValue);
        public abstract void OnRemove(ref T targetValue);
        public abstract void OnApply(ref T targetValue);
        public abstract void OnRevert(ref T targetValue);

        public Mutation() { }

        public Mutation(T mutationValue)
        {
            Value = mutationValue;
        }
    }
}
