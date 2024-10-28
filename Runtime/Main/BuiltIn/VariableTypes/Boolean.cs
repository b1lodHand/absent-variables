namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Boolean : Variable<bool>
    {
        bool m_initialValue;

        public Boolean() : base()
        {
            m_initialValue = Value;
        }

        public Boolean(string name, bool value) : base(name, value)
        {
            m_initialValue = Value;
        }

        public static implicit operator Boolean(bool v)
        {
            return new Boolean("", v);
        }

        public static implicit operator bool(Boolean f)
        {
            return f.Value;
        }

        public static Boolean operator !(Boolean f)
        {
            return new Boolean(f.Name, !f);
        }
    }
}
