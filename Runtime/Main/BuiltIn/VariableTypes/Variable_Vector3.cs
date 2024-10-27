using UnityEngine;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Variable_Vector3 : Variable<Vector3>
    {
        public Variable_Vector3() : base()
        {
        }

        public Variable_Vector3(string name, Vector3 value) : base(name, value)
        {

        }

        protected override void RevertMutations_Internal()
        {

        }

        protected override void ApplyMutations_Internal()
        {

        }

        public static implicit operator Variable_Vector3(Vector3 v)
        {
            return new Variable_Vector3("", v);
        }
    }
}
