namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class String : Variable<string>
    {
        #region Constructors
        public String() : base()
        {
        }

        public String(string name, string value) : base(name, value)
        {

        }
        #endregion

        #region Conversions
        public static implicit operator String(string v)
        {
            return new String("", v);
        }

        public static implicit operator string(String c)
        {
            return c.Value;
        }
        #endregion

        #region Operators
        public static String operator +(String a, string b)
        {
            return new String("", a.Value + b);
        }
        public static String operator +(String a, String b)
        {
            return new String("", a.Value + b.Value);
        }
        #endregion
    }
}
