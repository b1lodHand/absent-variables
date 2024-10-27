using System.Linq;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Variable_String : Variable<string>
    {
        string m_initialValue;

        public Variable_String() : base()
        {
            m_initialValue = Value;
        }

        public Variable_String(string name, string value) : base(name, value)
        {
            m_initialValue = Value;
        }

        protected override void ApplyMutations_Internal()
        {

        }

        protected override void RevertMutations_Internal()
        {
            Value = m_initialValue;
        }

        public static implicit operator Variable_String(string v)
        {
            return new Variable_String("", v);
        }

        public static implicit operator string(Variable_String c)
        {
            return c.Value;
        }
    }
}
