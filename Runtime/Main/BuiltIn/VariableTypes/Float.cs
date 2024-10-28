namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Float : Variable<float>
    {
        public Float() : base() { }

        public Float(string name, float value) : base(name, value)
        {
        }

        public static implicit operator Float(float v)
        {
            return new Float("", v);
        }

        public static implicit operator float(Float f)
        {
            return f.Value;
        }

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
    }
}
