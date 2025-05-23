#if CAN_USE_TIMERS
using com.absence.timersystem;
using com.absence.timersystem.internals;
#endif

using com.absence.variablesystem.internals;
using UnityEngine;

namespace com.absence.variablesystem.mutations
{
    /// <summary>
    /// Used for changing a variable's value with a reference on that change. With this, you can revert any of your changes after in game.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Serializable]
    public abstract class Mutation<T>
    {
        public const int MAX_ORDER = 255;
        public const int MIN_ORDER = 0;

        [field: SerializeField] public T Value { get; set; }
        [field: SerializeField] public AffectionMethod AffectionMethod { get; private set; }
        public int Priority
        {
            get
            {
                switch (AffectionMethod)
                {
                    case AffectionMethod.Root:
                        return 0;
                    case AffectionMethod.InOrder:
                        if (m_order < MIN_ORDER) return 0;
                        else if (m_order > MAX_ORDER) return MAX_ORDER;
                        else return m_order;
                    case AffectionMethod.Overall:
                        return MAX_ORDER;
                    default:
                        return 0;
                }
            }
        }

        protected abstract int m_order { get; }

#if CAN_USE_TIMERS
        [field: SerializeField] public float Duration { get; protected set; }
        [field: SerializeField] public ITimer Timer { get; protected set; }
        [field: SerializeField] public bool InitializedForTimers { get; protected set; }
        [field: SerializeField] public TimerManager TimerManagerUsed { get; protected set; }
#endif

        public virtual void OnAdd(Variable<T> variable)
        {
#if CAN_USE_TIMERS
            if (InitializedForTimers) 
            {
                Timer = absence.timersystem.Timer.Create(Duration);
                Timer.onComplete += (s) => variable.Immutate(this);
            }
#endif
        }

        public virtual void OnRemove(Variable<T> variable)
        {
#if CAN_USE_TIMERS
            if (InitializedForTimers)
            {
                if (Timer != null && !Timer.HasCompleted) Timer.Fail();
                Timer = null;
            }
#endif
        }

        public abstract T Apply(T initialValue);

        public Mutation() { }

        public Mutation(T mutationValue)
        {
            Value = mutationValue;
            AffectionMethod = AffectionMethod.InOrder;
        }

        public Mutation(T mutationValue, AffectionMethod affectionMethod)
        {
            Value = mutationValue;
            AffectionMethod = affectionMethod;
        }

#if CAN_USE_TIMERS
        public Mutation(T mutationValue, float duration, TimerManager manager = null)
        {
            Value = mutationValue;
            Duration = duration;
            AffectionMethod = AffectionMethod.InOrder;

            if (manager == null) manager = TimerManager.Instance;
            TimerManagerUsed = manager;

            InitializedForTimers = true;
        }

        public Mutation(T mutationValue, AffectionMethod affectionMethod, float duration, TimerManager manager = null)
        {
            Value = mutationValue;
            Duration = duration;
            AffectionMethod = affectionMethod;

            if (manager == null) manager = TimerManager.Instance;
            TimerManagerUsed = manager;

            InitializedForTimers = true;
        }
#endif
    }
}
