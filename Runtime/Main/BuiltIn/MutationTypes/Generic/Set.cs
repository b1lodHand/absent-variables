using com.absence.variablesystem.builtin.mutations.internals;
using com.absence.variablesystem.internals;

namespace com.absence.variablesystem.builtin.mutations
{
    public static class Set
    {
        public static SetMutation<T> Create<T>(T mutationValue, AffectionMethod setType = AffectionMethod.InOrder)
        {
            return new SetMutation<T>(mutationValue, setType);
        }

#if CAN_USE_TIMERS
        public static SetMutation<T> Create<T>(T mutationValue, float duration, AffectionMethod setType = AffectionMethod.InOrder)
        {
            return new SetMutation<T>(mutationValue, setType, duration);
        }
#endif
    }
}
