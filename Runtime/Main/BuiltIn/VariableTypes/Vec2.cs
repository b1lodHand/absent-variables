using com.absence.variablesystem.internals;
using UnityEngine;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Vec2 : Variable<Vector2>, INumericVariable<Vector2>
    {
        #region Constructors
        public Vec2() : base()
        {
        }

        public Vec2(string name, Vector2 value) : base(name, value)
        {

        }
        #endregion

        #region Conversions
        public static implicit operator Vec2(Vector2 v)
        {
            return new Vec2("", v);
        }

        public static implicit operator Vector2(Vec2 f)
        {
            return f.Value;
        }
        #endregion

        #region Wrappers
        public void Add(Vector2 amount, SetType setType = SetType.Baked)
        {
            Set(m_value + amount, setType);
        }

        public void Multiply(Vector2 multiplier, SetType setType = SetType.Baked)
        {
            Set(m_value * multiplier, setType);
        }

        public void Multiply(float multiplier, SetType setType = SetType.Baked)
        {
            Set(m_value * multiplier, setType);
        }

        public void Negate(SetType setType = SetType.Baked)
        {
            Multiply(-1f, setType);
        }
        #endregion

        #region Operators
        public static Vec2 operator +(Vec2 f, Vector2 v) 
        {
            return new Vec2(f.Name, f.Value + v).WithMutationsOf(f);
        }

        public static Vec2 operator -(Vec2 f, Vector2 v)
        {
            return new Vec2(f.Name, f.Value - v).WithMutationsOf(f);
        }

        public static Vec2 operator *(Vec2 f, Vector2 v)
        {
            return new Vec2(f.Name, f.Value * v).WithMutationsOf(f);
        }

        public static Vec2 operator /(Vec2 f, Vector2 v)
        {
            return new Vec2(f.Name, f.Value / v).WithMutationsOf(f);
        }

        public static Vec2 operator +(Vec2 f, Vec2 v)
        {
            return new Vec2(f.Name, f.Value + v.Value).WithMutationsOf(f);
        }

        public static Vec2 operator -(Vec2 f, Vec2 v)
        {
            return new Vec2(f.Name, f.Value - v.Value).WithMutationsOf(f);
        }

        public static Vec2 operator *(Vec2 f, Vec2 v)
        {
            return new Vec2(f.Name, f.Value * v.Value).WithMutationsOf(f);
        }

        public static Vec2 operator /(Vec2 f, Vec2 v)
        {
            return new Vec2(f.Name, f.Value / v.Value).WithMutationsOf(f);
        }
        #endregion

        public override bool ValueEquals(Variable<Vector2> other)
        {
            return this.Value == other.Value;
        }
    }
}
