using System.Linq;

namespace com.absence.variablesystem.builtin
{
    [System.Serializable]
    public class Variable_Boolean : Variable<bool>
    {
        bool m_initialValue;

        public Variable_Boolean() : base()
        {
            m_initialValue = Value;
        }

        public Variable_Boolean(string name, bool value) : base(name, value)
        {
            m_initialValue = Value;
        }

        protected override void ApplyMutations_Internal()
        {

        }

        protected override void RevertMutations_Internal()
        {

        }

        public static implicit operator Variable_Boolean(bool v)
        {
            return new Variable_Boolean("", v);
        }
    }
}
