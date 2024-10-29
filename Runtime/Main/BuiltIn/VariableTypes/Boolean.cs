using com.absence.variablesystem.internals;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Boolean : Variable<bool>
    {
        bool m_initialValue;

        #region Constructors
        public Boolean() : base()
        {
            m_initialValue = Value;
        }

        public Boolean(string name, bool value) : base(name, value)
        {
            m_initialValue = Value;
        }
        #endregion

        #region Conversions
        public static implicit operator Boolean(bool v)
        {
            return new Boolean("", v);
        }

        public static implicit operator bool(Boolean f)
        {
            return f.Value;
        }
        #endregion

        #region Wrappers
        public void Invert(SetType setType = SetType.Baked)
        {
            Set(!m_value, setType);
        }
        #endregion

        #region Operators
        public static Boolean operator !(Boolean f)
        {
            return new Boolean(f.Name, !f);
        }
        #endregion
    }
}
