using com.absence.variablesystem.internals;
using UnityEngine;

namespace com.absence.variablesystem.mutations.internals
{
    [System.Serializable]
    public class Vector2NegateMutation : Mutation<Vector2>
    {
        public Vector2NegateMutation() : base() { }

        public Vector2NegateMutation(Vector2 mutationValue) : base(mutationValue)
        {
        }

        public Vector2NegateMutation(Vector2 mutationValue, AffectionMethod affectionMethod) : base(mutationValue, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public Vector2NegateMutation(Vector2 mutationValue, float duration) : base(mutationValue, duration)
        {
        }

        public Vector2NegateMutation(Vector2 mutationValue, AffectionMethod affectionMethod, float duration) : base(mutationValue, affectionMethod, duration)
        {
        }
#endif
        protected override int m_order => 2;

        public override void OnApply(ref Vector2 targetValue)
        {
            targetValue.x *= -1f;
            targetValue.y *= -1f;
        }

        public override void OnRevert(ref Vector2 targetValue)
        {
            targetValue.x *= -1f;
            targetValue.y *= -1f;
        }
    }

    [System.Serializable]
    public class Vector3NegateMutation : Mutation<Vector3>
    {

        public Vector3NegateMutation() : base() { }


        public Vector3NegateMutation(Vector3 mutationValue) : base(mutationValue)
        {
        }

        public Vector3NegateMutation(Vector3 mutationValue, AffectionMethod affectionMethod) : base(mutationValue, affectionMethod)
        {
        }

#if CAN_USE_TIMERS
        public Vector3NegateMutation(Vector3 mutationValue, float duration) : base(mutationValue, duration)
        {
        }

        public Vector3NegateMutation(Vector3 mutationValue, AffectionMethod affectionMethod, float duration) : base(mutationValue, affectionMethod, duration)
        {
        }
#endif

        protected override int m_order => 2;

        public override void OnApply(ref Vector3 targetValue)
        {
            targetValue.x *= -1f;
            targetValue.y *= -1f;
            targetValue.z *= -1f;
        }

        public override void OnRevert(ref Vector3 targetValue)
        {
            targetValue.x *= -1f;
            targetValue.y *= -1f;
            targetValue.z *= -1f;
        }
    }

}
