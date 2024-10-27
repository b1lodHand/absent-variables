using com.absence.variablesystem.mutations.builtin.internals;
using UnityEngine;

namespace com.absence.variablesystem.mutations.builtin
{
    public class NegateMutation : MonoBehaviour
    {
        public NegateMutation()
        {
        }

        public static implicit operator FloatNegateMutation(NegateMutation m)
        {
            return new FloatNegateMutation();
        }

        public static implicit operator IntegerNegateMutation(NegateMutation m)
        {
            return new IntegerNegateMutation();
        }

        public static implicit operator Vector2NegateMutation(NegateMutation m)
        {
            return new Vector2NegateMutation();
        }

        public static implicit operator Vector3NegateMutation(NegateMutation m)
        {
            return new Vector3NegateMutation();
        }
    }
}
