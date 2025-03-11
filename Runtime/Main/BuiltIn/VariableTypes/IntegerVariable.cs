using com.absence.variablesystem.internals;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class IntegerVariable : Variable<int>, INumericVariable<int>
    {
        #region Constructors
        public IntegerVariable() { }

        public IntegerVariable(int value) : base(value)
        {
        }
        #endregion

        #region Conversions
        public static implicit operator IntegerVariable(int v)
        {
            return new IntegerVariable(v);
        }

        public static explicit operator int(IntegerVariable f)
        {
            return f.Value;
        }
        #endregion

        #region Operators
        //public static IntegerVariable operator +(IntegerVariable f, int v)
        //{
        //    return new IntegerVariable(f.Name, f.Value + v).WithMutationsOf(f);
        //}

        //public static IntegerVariable operator -(IntegerVariable f, int v)
        //{
        //    return new IntegerVariable(f.Name, f.Value - v).WithMutationsOf(f);
        //}

        //public static IntegerVariable operator *(IntegerVariable f, int v)
        //{
        //    return new IntegerVariable(f.Name, f.Value * v).WithMutationsOf(f);
        //}

        //public static IntegerVariable operator /(IntegerVariable f, int v)
        //{
        //    return new IntegerVariable(f.Name, f.Value / v).WithMutationsOf(f);
        //}

        //public static IntegerVariable operator +(IntegerVariable f, float v)
        //{
        //    return new IntegerVariable(f.Name, f.Value + (int)v).WithMutationsOf(f);
        //}

        //public static IntegerVariable operator -(IntegerVariable f, float v)
        //{
        //    return new IntegerVariable(f.Name, f.Value - (int)v).WithMutationsOf(f);
        //}

        //public static IntegerVariable operator *(IntegerVariable f, float v)
        //{
        //    return new IntegerVariable(f.Name, f.Value * (int)v).WithMutationsOf(f);
        //}

        //public static IntegerVariable operator /(IntegerVariable f, float v)
        //{
        //    return new IntegerVariable(f.Name, f.Value / (int)v).WithMutationsOf(f);
        //}

        //public static IntegerVariable operator +(IntegerVariable f, IntegerVariable v)
        //{
        //    return new IntegerVariable(f.Name, f.Value + v.Value).WithMutationsOf(f);
        //}

        //public static IntegerVariable operator -(IntegerVariable f, IntegerVariable v)
        //{
        //    return new IntegerVariable(f.Name, f.Value - v.Value).WithMutationsOf(f);
        //}

        //public static IntegerVariable operator *(IntegerVariable f, IntegerVariable v)
        //{
        //    return new IntegerVariable(f.Name, f.Value * v.Value).WithMutationsOf(f);
        //}

        //public static IntegerVariable operator /(IntegerVariable f, IntegerVariable v)
        //{
        //    return new IntegerVariable(f.Name, f.Value / v.Value).WithMutationsOf(f);
        //}
        #endregion
    }
}
