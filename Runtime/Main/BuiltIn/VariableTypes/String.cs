namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class String : Variable<string>
    {
        public String() : base()
        {
        }

        public String(string name, string value) : base(name, value)
        {

        }

        public static implicit operator String(string v)
        {
            return new String("", v);
        }

        public static implicit operator string(String c)
        {
            return c.Value;
        }
    }
}
