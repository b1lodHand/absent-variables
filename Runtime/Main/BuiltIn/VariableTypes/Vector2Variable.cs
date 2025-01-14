using com.absence.variablesystem.internals;
using UnityEngine;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Vector2Variable : Variable<Vector2>, INumericVariable<Vector2>
    {
        #region Constructors
        public Vector2Variable() : base()
        {
        }

        public Vector2Variable(string name, Vector2 value) : base(name, value)
        {

        }
        #endregion

        #region Conversions
        public static implicit operator Vector2Variable(Vector2 v)
        {
            return new Vector2Variable("", v);
        }

        public static explicit operator Vector2(Vector2Variable f)
        {
            return f.Value;
        }
        #endregion

        #region Operators
        //public static Vector2Variable operator +(Vector2Variable f, Vector2 v) 
        //{
        //    return new Vector2Variable(f.Name, f.Value + v).WithMutationsOf(f);
        //}

        //public static Vector2Variable operator -(Vector2Variable f, Vector2 v)
        //{
        //    return new Vector2Variable(f.Name, f.Value - v).WithMutationsOf(f);
        //}

        //public static Vector2Variable operator *(Vector2Variable f, Vector2 v)
        //{
        //    return new Vector2Variable(f.Name, f.Value * v).WithMutationsOf(f);
        //}

        //public static Vector2Variable operator /(Vector2Variable f, Vector2 v)
        //{
        //    return new Vector2Variable(f.Name, f.Value / v).WithMutationsOf(f);
        //}

        //public static Vector2Variable operator +(Vector2Variable f, Vector2Variable v)
        //{
        //    return new Vector2Variable(f.Name, f.Value + v.Value).WithMutationsOf(f);
        //}

        //public static Vector2Variable operator -(Vector2Variable f, Vector2Variable v)
        //{
        //    return new Vector2Variable(f.Name, f.Value - v.Value).WithMutationsOf(f);
        //}

        //public static Vector2Variable operator *(Vector2Variable f, Vector2Variable v)
        //{
        //    return new Vector2Variable(f.Name, f.Value * v.Value).WithMutationsOf(f);
        //}

        //public static Vector2Variable operator /(Vector2Variable f, Vector2Variable v)
        //{
        //    return new Vector2Variable(f.Name, f.Value / v.Value).WithMutationsOf(f);
        //}
        #endregion

        public override bool ValueEquals(Variable<Vector2> other)
        {
            return this.Value == other.Value;
        }
    }
}
