namespace com.absence.variablesystem.mutations
{
    /// <summary>
    /// Used for changing a variable's value with a reference on that change. With this, you can revert any of your changes after in game.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Mutation<T>
    {
        public MutationType MutationType { get; private set; }
        public T MutationValue { get; private set; }

        public Mutation(T mutationValue, MutationType mutationType)
        {
            MutationValue = mutationValue;
            MutationType = mutationType;
        }
    }

    /// <summary>
    /// Used to decide how the mutation will work.
    /// </summary>
    public enum MutationType
    {
        /// <summary>
        /// Addition.
        /// </summary>
        Additive = 0,
        /// <summary>
        /// Multiplication.
        /// </summary>
        Multiplicative = 1,
        /// <summary>
        /// Any other type of mutation.
        /// </summary>
        Other = 2,
    }
}
