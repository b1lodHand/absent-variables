namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class BooleanVariable : Variable<bool>
    {
        #region Constructors
        public BooleanVariable() : base()
        {
        }

        public BooleanVariable(bool value) : base(value)
        {
        }
        #endregion

        #region Conversions
        public static implicit operator BooleanVariable(bool v)
        {
            return new BooleanVariable(v);
        }

        public static explicit operator bool(BooleanVariable f)
        {
            return f.Value;
        }
        #endregion

        #region Wrappers
        public void Invert()
        {
            UnderlyingValue = !UnderlyingValue;
        }
        #endregion

        #region Operators

        #endregion
    }
}
