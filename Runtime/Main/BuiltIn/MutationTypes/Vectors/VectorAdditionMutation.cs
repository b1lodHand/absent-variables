using com.absence.variablesystem.internals;
using UnityEngine;

namespace com.absence.variablesystem.mutations.internals
{
    [System.Serializable]
    public class Vector2AdditionMutation : Mutation<Vector2>
    {
        public Vector2AdditionMutation() : base()
        {
        }

        public Vector2AdditionMutation(Vector2 mutationValue) : base(mutationValue)
        {
        }

        public Vector2AdditionMutation(Vector2 mutationValue, AffectionMethod affectionMethod) : base(mutationValue, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public Vector2AdditionMutation(Vector2 mutationValue, float duration) : base(mutationValue, duration)
        {
        }

        public Vector2AdditionMutation(Vector2 mutationValue, AffectionMethod affectionMethod, float duration) : base(mutationValue, affectionMethod, duration)
        {
        }
#endif

        protected override int m_order => 0;

        public override Vector2 Apply(Vector2 initialValue)
        {
            Vector2 temp = new(initialValue.x, initialValue.y);

            temp.x += Value.x;
            temp.y += Value.y;

            return temp;
        }
    }

    [System.Serializable]
    public class Vector3AdditionMutation : Mutation<Vector3>
    {
        public Vector3AdditionMutation() : base()
        {
        }

        public Vector3AdditionMutation(Vector3 mutationValue) : base(mutationValue)
        {
        }

        public Vector3AdditionMutation(Vector3 mutationValue, AffectionMethod affectionMethod) : base(mutationValue, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public Vector3AdditionMutation(Vector3 mutationValue, float duration) : base(mutationValue, duration)
        {
        }

        public Vector3AdditionMutation(Vector3 mutationValue, AffectionMethod affectionMethod, float duration) : base(mutationValue, affectionMethod, duration)
        {
        }
#endif

        protected override int m_order => 0;

        public override Vector3 Apply(Vector3 initialValue)
        {
            Vector3 temp = new(initialValue.x, initialValue.y, initialValue.z);

            temp.x += Value.x;
            temp.y += Value.y;
            temp.z += Value.z;

            return temp;
        }
    }
}
