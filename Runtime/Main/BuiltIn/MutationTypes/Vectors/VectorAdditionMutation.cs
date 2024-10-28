using com.absence.variablesystem.internals;
using com.absence.variablesystem.mutations;
using UnityEngine;

namespace com.absence.variablesystem.builtin.mutations.internals
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

        public override void OnApply(ref Vector2 targetValue)
        {
            targetValue.x += Value.x;
            targetValue.y += Value.y;
        }

        public override void OnRevert(ref Vector2 targetValue)
        {
            targetValue.x -= Value.x;
            targetValue.y -= Value.y;
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

        public override void OnApply(ref Vector3 targetValue)
        {
            targetValue.x += Value.x;
            targetValue.y += Value.y;
            targetValue.z += Value.z;
        }

        public override void OnRevert(ref Vector3 targetValue)
        {
            targetValue.x -= Value.x;
            targetValue.y -= Value.y;
            targetValue.z -= Value.z;
        }
    }
}
