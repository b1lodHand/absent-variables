using com.absence.variablesystem.internals;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class FloatVariable : Variable<float>, INumericVariable<float>
    {
        #region Constructors
        public FloatVariable() : base() { }

        public FloatVariable(float value) : base(value)
        {
        }
        #endregion

        #region Conversions
        public static implicit operator FloatVariable(float v)
        {
            return new FloatVariable(v);
        }

        public static explicit operator float(FloatVariable f)
        {
            return f.Value;
        }
        #endregion

        #region Operators
        //public static FloatVariable operator+(FloatVariable f, float v)
        //{
        //    return new FloatVariable(f.Name, f.Value + v).WithMutationsOf(f);
        //}

        //public static FloatVariable operator -(FloatVariable f, float v)
        //{
        //    return new FloatVariable(f.Name, f.Value - v).WithMutationsOf(f);
        //}

        //public static FloatVariable operator *(FloatVariable f, float v)
        //{
        //    return new FloatVariable(f.Name, f.Value * v).WithMutationsOf(f);
        //}

        //public static FloatVariable operator /(FloatVariable f, float v)
        //{
        //    return new FloatVariable(f.Name, f.Value / v).WithMutationsOf(f);
        //}

        //public static FloatVariable operator +(FloatVariable f, int v)
        //{
        //    return new FloatVariable(f.Name, f.Value + v).WithMutationsOf(f);
        //}

        //public static FloatVariable operator -(FloatVariable f, int v)
        //{
        //    return new FloatVariable(f.Name, f.Value - v).WithMutationsOf(f);
        //}

        //public static FloatVariable operator *(FloatVariable f, int v)
        //{
        //    return new FloatVariable(f.Name, f.Value * v).WithMutationsOf(f);
        //}

        //public static FloatVariable operator /(FloatVariable f, int v)
        //{
        //    return new FloatVariable(f.Name, f.Value / v).WithMutationsOf(f);
        //}

        //public static FloatVariable operator +(FloatVariable f, FloatVariable v)
        //{
        //    return new FloatVariable(f.Name, f.Value + v.Value).WithMutationsOf(f);
        //}

        //public static FloatVariable operator -(FloatVariable f, FloatVariable v)
        //{
        //    return new FloatVariable(f.Name, f.Value - v.Value).WithMutationsOf(f);
        //}

        //public static FloatVariable operator *(FloatVariable f, FloatVariable v)
        //{
        //    return new FloatVariable(f.Name, f.Value * v.Value).WithMutationsOf(f);
        //}

        //public static FloatVariable operator /(FloatVariable f, FloatVariable v)
        //{
        //    return new FloatVariable(f.Name, f.Value / v.Value).WithMutationsOf(f);
        //}
        #endregion
    }
}
