using UnityEngine;

namespace com.absence.variablesystem.mutations.builtin.internals
{
    public class Vector2NegateMutation : Mutation<Vector2>
    {
        public Vector2NegateMutation() : base() { }

        public Vector2NegateMutation(Vector2 mutationValue) : base(mutationValue)
        {
        }

        public override int Priority => 2;

        public override void OnAdd(ref Vector2 targetValue)
        {
            
        }

        public override void OnApply(ref Vector2 targetValue)
        {
            targetValue.x *= -1f;
            targetValue.y *= -1f;
        }

        public override void OnRemove(ref Vector2 targetValue)
        {
            
        }

        public override void OnRevert(ref Vector2 targetValue)
        {
            targetValue.x *= -1f;
            targetValue.y *= -1f;
        }
    }

    public class Vector3NegateMutation : Mutation<Vector3>
    {
        public Vector3NegateMutation() : base() { }

        public Vector3NegateMutation(Vector3 mutationValue) : base(mutationValue)
        {
        }

        public override int Priority => 2;

        public override void OnAdd(ref Vector3 targetValue)
        {
           
        }

        public override void OnApply(ref Vector3 targetValue)
        {
            targetValue.x *= -1f;
            targetValue.y *= -1f;
            targetValue.z *= -1f;
        }

        public override void OnRemove(ref Vector3 targetValue)
        {
           
        }

        public override void OnRevert(ref Vector3 targetValue)
        {
            targetValue.x *= -1f;
            targetValue.y *= -1f;
            targetValue.z *= -1f;
        }
    }

}
