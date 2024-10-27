using UnityEngine;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Variable_Vector2 : Variable<Vector2>
    {
        public Variable_Vector2() : base()
        {
        }

        public Variable_Vector2(string name, Vector2 value) : base(name, value)
        {

        }

        protected override void RevertMutations_Internal()
        {

        }

        protected override void ApplyMutations_Internal()
        {

        }

        public static implicit operator Variable_Vector2(Vector2 v)
        {
            return new Variable_Vector2("", v);
        }
    }
}
