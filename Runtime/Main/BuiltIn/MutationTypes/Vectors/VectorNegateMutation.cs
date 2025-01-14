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

        public override Vector2 Apply(Vector2 initialValue)
        {
            Vector2 temp = new(initialValue.x, initialValue.y);

            temp.x *= -1f;
            temp.y *= -1f;

            return temp;
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
        
        public override Vector3 Apply(Vector3 initialValue)
        {
            Vector3 temp = new(initialValue.x, initialValue.y, initialValue.z);

            temp.x *= -1f;
            temp.y *= -1f;
            temp.z *= -1f;

            return temp;
        }
    }

}
