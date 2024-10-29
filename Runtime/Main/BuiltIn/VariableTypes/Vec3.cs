using com.absence.variablesystem.internals;
using System;
using UnityEngine;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Vec3 : Variable<Vector3>, INumericVariable<Vector3>
    {
        #region Constructors
        public Vec3() : base()
        {
        }

        public Vec3(string name, Vector3 value) : base(name, value)
        {

        }
        #endregion

        #region Conversions
        public static implicit operator Vec3(Vector3 v)
        {
            return new Vec3("", v);
        }

        public static implicit operator Vector3(Vec3 f)
        {
            return f.Value;
        }
        #endregion

        #region Wrappers
        public void Add(Vector3 amount, SetType setType = SetType.Baked)
        {
            Set(m_value + amount, setType);
        }

        [Obsolete("This method is deprecated. Use Cross instead.")]
        public void Multiply(Vector3 multiplier, SetType setType = SetType.Baked)
        {
            Cross(multiplier, setType);
        }

        public void Multiply(float multiplier, SetType setType = SetType.Baked)
        {
            Set(m_value * multiplier, setType);
        }

        public void Cross(Vector3 rhs, SetType setType = SetType.Baked)
        {
            Set(Vector3.Cross(m_value, rhs), setType);
        }

        public void Negate(SetType setType = SetType.Baked)
        {
            Multiply(-1f, setType);
        }
        #endregion

        #region Operators
        public static Vec3 operator +(Vec3 f, Vector3 v)
        {
            return new Vec3(f.Name, f.Value + v).WithMutationsOf(f);
        }

        public static Vec3 operator -(Vec3 f, Vector3 v)
        {
            return new Vec3(f.Name, f.Value - v).WithMutationsOf(f);
        }

        public static Vec3 operator +(Vec3 f, Vec3 v)
        {
            return new Vec3(f.Name, f.Value + v.Value).WithMutationsOf(f);
        }

        public static Vec3 operator -(Vec3 f, Vec3 v)
        {
            return new Vec3(f.Name, f.Value - v.Value).WithMutationsOf(f);
        }
        #endregion

        public override bool ValueEquals(Variable<Vector3> other)
        {
            return this.Value == other.Value;
        }
    }
}
