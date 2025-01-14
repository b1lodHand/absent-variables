using com.absence.variablesystem.internals;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class StringVariable : Variable<string>
    {
        #region Constructors
        public StringVariable() : base()
        {
        }

        public StringVariable(string name, string value) : base(name, value)
        {

        }
        #endregion

        #region Conversions
        public static implicit operator StringVariable(string v)
        {
            return new StringVariable("", v);
        }

        public static explicit operator string(StringVariable c)
        {
            return c.Value;
        }
        #endregion

        #region Operators
        //public static StringVariable operator +(StringVariable a, string b)
        //{
        //    return new StringVariable("", a.Value + b);
        //}

        //public static StringVariable operator +(StringVariable a, StringVariable b)
        //{
        //    return new StringVariable("", a.Value + b.Value);
        //}
        #endregion
    }
}
