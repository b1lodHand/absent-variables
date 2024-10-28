using UnityEngine;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Vec2 : Variable<Vector2>
    {
        public Vec2() : base()
        {
        }

        public Vec2(string name, Vector2 value) : base(name, value)
        {

        }

        public static implicit operator Vec2(Vector2 v)
        {
            return new Vec2("", v);
        }

        public static implicit operator Vector2(Vec2 f)
        {
            return f.Value;
        }

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
    }
}
