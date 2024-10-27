using System.Linq;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Variable_Float : Variable<float>
    {
        public Variable_Float() : base() { }

        public Variable_Float(string name, float value) : base(name, value)
        {
        }

        protected override void RevertMutations_Internal()
        {

        }

        protected override void ApplyMutations_Internal()
        {

        }

        public static implicit operator Variable_Float(float v)
        {
            return new Variable_Float("", v);
        }

        public static Variable_Float operator+(Variable_Float f, float v)
        {
            f.Value += v;
            return f;
        }

        public static Variable_Float operator -(Variable_Float f, float v)
        {
            f.Value -= v;
            return f;
        }

        public static Variable_Float operator *(Variable_Float f, float v)
        {
            f.Value *= v;
            return f;
        }

        public static Variable_Float operator /(Variable_Float f, float v)
        {
            f.Value /= v;
            return f;
        }
    }
}
