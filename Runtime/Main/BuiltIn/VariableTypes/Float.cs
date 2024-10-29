using com.absence.variablesystem.internals;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Float : Variable<float>, INumericVariable<float>
    {
        #region Constructors
        public Float() : base() { }

        public Float(string name, float value) : base(name, value)
        {
        }
        #endregion

        #region Conversions
        public static implicit operator Float(float v)
        {
            return new Float("", v);
        }

        public static implicit operator float(Float f)
        {
            return f.Value;
        }
        #endregion

        #region Wrappers
        public void Add(float amount, SetType setType = SetType.Baked)
        {
            Set(m_value + amount, setType);
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
        public static Float operator+(Float f, float v)
        {
            return new Float(f.Name, f.Value + v).WithMutationsOf(f);
        }

        public static Float operator -(Float f, float v)
        {
            return new Float(f.Name, f.Value - v).WithMutationsOf(f);
        }

        public static Float operator *(Float f, float v)
        {
            return new Float(f.Name, f.Value * v).WithMutationsOf(f);
        }

        public static Float operator /(Float f, float v)
        {
            return new Float(f.Name, f.Value / v).WithMutationsOf(f);
        }

        public static Float operator +(Float f, int v)
        {
            return new Float(f.Name, f.Value + v).WithMutationsOf(f);
        }

        public static Float operator -(Float f, int v)
        {
            return new Float(f.Name, f.Value - v).WithMutationsOf(f);
        }

        public static Float operator *(Float f, int v)
        {
            return new Float(f.Name, f.Value * v).WithMutationsOf(f);
        }

        public static Float operator /(Float f, int v)
        {
            return new Float(f.Name, f.Value / v).WithMutationsOf(f);
        }

        public static Float operator +(Float f, Float v)
        {
            return new Float(f.Name, f.Value + v.Value).WithMutationsOf(f);
        }

        public static Float operator -(Float f, Float v)
        {
            return new Float(f.Name, f.Value - v.Value).WithMutationsOf(f);
        }

        public static Float operator *(Float f, Float v)
        {
            return new Float(f.Name, f.Value * v.Value).WithMutationsOf(f);
        }

        public static Float operator /(Float f, Float v)
        {
            return new Float(f.Name, f.Value / v.Value).WithMutationsOf(f);
        }
        #endregion
    }
}
