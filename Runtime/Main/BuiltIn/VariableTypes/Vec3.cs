using UnityEngine;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Vec3 : Variable<Vector3>
    {
        public Vec3() : base()
        {
        }

        public Vec3(string name, Vector3 value) : base(name, value)
        {

        }

        public static implicit operator Vec3(Vector3 v)
        {
            return new Vec3("", v);
        }

        public static implicit operator Vector3(Vec3 f)
        {
            return f.Value;
        }

        public static Vec3 operator +(Vec3 f, Vector3 v)
        {
            return new Vec3(f.Name, f.Value + v).WithMutationsOf(f);
        }

        public static Vec3 operator -(Vec3 f, Vector3 v)
        {
            return new Vec3(f.Name, f.Value - v).WithMutationsOf(f);
        }
    }
}
