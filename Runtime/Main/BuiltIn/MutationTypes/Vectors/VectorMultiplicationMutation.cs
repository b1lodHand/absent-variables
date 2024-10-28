using com.absence.variablesystem.internals;
using com.absence.variablesystem.mutations;
using UnityEngine;

namespace com.absence.variablesystem.builtin.mutations.internals
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

        public override void OnApply(ref Vector2 targetValue)
        {
            targetValue.x *= Value.x;
            targetValue.y *= Value.y;
        }

        public override void OnRevert(ref Vector2 targetValue)
        {
            targetValue.x /= Value.x;
            targetValue.y /= Value.y;
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

        public override void OnApply(ref Vector3 targetValue)
        {
            targetValue.x *= Value.x;
            targetValue.y *= Value.y;
            targetValue.z *= Value.z;
        }

        public override void OnRevert(ref Vector3 targetValue)
        {
            targetValue.x /= Value.x;
            targetValue.y /= Value.y;
            targetValue.z /= Value.z;
        }
    }
}
