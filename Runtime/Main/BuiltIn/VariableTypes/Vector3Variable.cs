using com.absence.variablesystem.internals;
using UnityEngine;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Vector3Variable : Variable<Vector3>, INumericVariable<Vector3>
    {
        #region Constructors
        public Vector3Variable() : base()
        {
        }

        public Vector3Variable(Vector3 value) : base(value)
        {

        }
        #endregion

        #region Conversions
        public static implicit operator Vector3Variable(Vector3 v)
        {
            return new Vector3Variable(v);
        }

        public static explicit operator Vector3(Vector3Variable f)
        {
            return f.Value;
        }
        #endregion

        #region Operators
        //public static Vector3Variable operator +(Vector3Variable f, Vector3 v)
        //{
        //    return new Vector3Variable(f.Name, f.Value + v).WithMutationsOf(f);
        //}

        //public static Vector3Variable operator -(Vector3Variable f, Vector3 v)
        //{
        //    return new Vector3Variable(f.Name, f.Value - v).WithMutationsOf(f);
        //}

        //public static Vector3Variable operator +(Vector3Variable f, Vector3Variable v)
        //{
        //    return new Vector3Variable(f.Name, f.Value + v.Value).WithMutationsOf(f);
        //}

        //public static Vector3Variable operator -(Vector3Variable f, Vector3Variable v)
        //{
        //    return new Vector3Variable(f.Name, f.Value - v.Value).WithMutationsOf(f);
        //}
        #endregion

        public override bool ValueEquals(Variable<Vector3> other)
        {
            return this.Value == other.Value;
        }
    }
}
