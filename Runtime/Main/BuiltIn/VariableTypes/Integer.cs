namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Integer : Variable<int>
    {
        public Integer() { }

        public Integer(string name, int value) : base(name, value)
        {
        }

        public static implicit operator Integer(int v)
        {
            return new Integer("", v);
        }

        public static implicit operator int(Integer f)
        {
            return f.Value;
        }

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
    }
}
