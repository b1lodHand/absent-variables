using UnityEngine;

namespace com.absence.variablesystem.mutations.builtin.internals
{
    public class Vector2MultiplicationMutation : Mutation<Vector2>
    {
        public Vector2MultiplicationMutation(Vector2 mutationValue) : base(mutationValue)
        {
        }

        public override int Priority => 1;

        public override void OnAdd(ref Vector2 targetValue)
        {
            
        }

        public override void OnApply(ref Vector2 targetValue)
        {
            targetValue.x *= Value.x;
            targetValue.y *= Value.y;
        }

        public override void OnRemove(ref Vector2 targetValue)
        {

        }

        public override void OnRevert(ref Vector2 targetValue)
        {
            targetValue.x /= Value.x;
            targetValue.y /= Value.y;
        }
    }

    public class Vector3MultiplicationMutation : Mutation<Vector3>
    {
        public Vector3MultiplicationMutation(Vector3 mutationValue) : base(mutationValue)
        {
        }

        public override int Priority => 1;

        public override void OnAdd(ref Vector3 targetValue)
        {

        }

        public override void OnApply(ref Vector3 targetValue)
        {
            targetValue.x *= Value.x;
            targetValue.y *= Value.y;
            targetValue.z *= Value.z;
        }

        public override void OnRemove(ref Vector3 targetValue)
        {

        }

        public override void OnRevert(ref Vector3 targetValue)
        {
            targetValue.x /= Value.x;
            targetValue.y /= Value.y;
            targetValue.z /= Value.z;
        }
    }
}
