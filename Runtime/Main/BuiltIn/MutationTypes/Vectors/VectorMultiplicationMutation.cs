using com.absence.variablesystem.internals;
using UnityEngine;

namespace com.absence.variablesystem.mutations.internals
{
    [System.Serializable]
    public class Vector2MultiplicationMutation : Mutation<Vector2>
    {
        public Vector2MultiplicationMutation() : base()
        {
        }

        public Vector2MultiplicationMutation(Vector2 mutationValue) : base(mutationValue)
        {
        }

        public Vector2MultiplicationMutation(Vector2 mutationValue, AffectionMethod affectionMethod) : base(mutationValue, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public Vector2MultiplicationMutation(Vector2 mutationValue, float duration) : base(mutationValue, duration)
        {
        }

        public Vector2MultiplicationMutation(Vector2 mutationValue, AffectionMethod affectionMethod, float duration) : base(mutationValue, affectionMethod, duration)
        {
        }
#endif

        protected override int m_order => 1;

        public override Vector2 Apply(Vector2 initialValue)
        {
            Vector2 temp = new(initialValue.x, initialValue.y);
            temp.x *= Value.x;
            temp.y *= Value.y;

            return temp;
        }
    }

    [System.Serializable]
    public class Vector3MultiplicationMutation : Mutation<Vector3>
    {
        public Vector3MultiplicationMutation() : base()
        {
        }

        public Vector3MultiplicationMutation(Vector3 mutationValue) : base(mutationValue)
        {
        }

        public Vector3MultiplicationMutation(Vector3 mutationValue, AffectionMethod affectionMethod) : base(mutationValue, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public Vector3MultiplicationMutation(Vector3 mutationValue, float duration) : base(mutationValue, duration)
        {
        }

        public Vector3MultiplicationMutation(Vector3 mutationValue, AffectionMethod affectionMethod, float duration) : base(mutationValue, affectionMethod, duration)
        {
        }
#endif

        protected override int m_order => 1;

        public override Vector3 Apply(Vector3 initialValue)
        {
            Vector3 temp = new(initialValue.x, initialValue.y, initialValue.z);

            temp.x *= Value.x;
            temp.y *= Value.y;
            temp.z *= Value.z;

            return temp;
        }
    }
}
