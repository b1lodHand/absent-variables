using com.absence.variablesystem.internals;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Integer : Variable<int>, INumericVariable<int>
    {
        #region Constructors
        public Integer() { }

        public Integer(string name, int value) : base(name, value)
        {
        }
        #endregion

        #region Conversions
        public static implicit operator Integer(int v)
        {
            return new Integer("", v);
        }

        public static implicit operator int(Integer f)
        {
            return f.Value;
        }
        #endregion

        #region Wrappers
        public void Add(int amount, SetType setType = SetType.Baked)
        {
            Set(m_value + amount, setType);
        }

        public void Multiply(int multiplier, SetType setType = SetType.Baked)
        {
            Set(m_value * multiplier, setType);
        }

        public void Negate(SetType setType = SetType.Baked)
        {
            Multiply(-1, setType);
        }
        #endregion

        #region Operators
        public static Integer operator +(Integer f, int v)
        {
            return new Integer(f.Name, f.Value + v).WithMutationsOf(f);
        }

        public static Integer operator -(Integer f, int v)
        {
            return new Integer(f.Name, f.Value - v).WithMutationsOf(f);
        }

        public static Integer operator *(Integer f, int v)
        {
            return new Integer(f.Name, f.Value * v).WithMutationsOf(f);
        }

        public static Integer operator /(Integer f, int v)
        {
            return new Integer(f.Name, f.Value / v).WithMutationsOf(f);
        }

        public static Integer operator +(Integer f, float v)
        {
            return new Integer(f.Name, f.Value + (int)v).WithMutationsOf(f);
        }

        public static Integer operator -(Integer f, float v)
        {
            return new Integer(f.Name, f.Value - (int)v).WithMutationsOf(f);
        }

        public static Integer operator *(Integer f, float v)
        {
            return new Integer(f.Name, f.Value * (int)v).WithMutationsOf(f);
        }

        public static Integer operator /(Integer f, float v)
        {
            return new Integer(f.Name, f.Value / (int)v).WithMutationsOf(f);
        }

        public static Integer operator +(Integer f, Integer v)
        {
            return new Integer(f.Name, f.Value + v.Value).WithMutationsOf(f);
        }

        public static Integer operator -(Integer f, Integer v)
        {
            return new Integer(f.Name, f.Value - v.Value).WithMutationsOf(f);
        }

        public static Integer operator *(Integer f, Integer v)
        {
            return new Integer(f.Name, f.Value * v.Value).WithMutationsOf(f);
        }

        public static Integer operator /(Integer f, Integer v)
        {
            return new Integer(f.Name, f.Value / v.Value).WithMutationsOf(f);
        }
        #endregion
    }
}
