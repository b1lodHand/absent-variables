using System.Linq;

namespace com.absence.variablesystem
{
    [System.Serializable]
    public class Variable_Integer : Variable<int>
    {
        public Variable_Integer() { }

        public Variable_Integer(string name, int value) : base(name, value)
        {
        }

        protected override void RevertMutations_Internal()
        {

        }

        protected override void ApplyMutations_Internal()
        {

        }

        public static implicit operator Variable_Integer(int v)
        {
            return new Variable_Integer("", v);
        }

        public static Variable_Integer operator +(Variable_Integer f, int v)
        {
            f.Value += v;
            return f;
        }

        public static Variable_Integer operator -(Variable_Integer f, int v)
        {
            f.Value -= v;
            return f;
        }

        public static Variable_Integer operator *(Variable_Integer f, int v)
        {
            f.Value *= v;
            return f;
        }

        public static Variable_Integer operator /(Variable_Integer f, int v)
        {
            f.Value /= v;
            return f;
        }
    }
}
