using com.absence.variablesystem.mutations.builtin.internals;

namespace com.absence.variablesystem.mutations.builtin
{
    public class AdditionMutation
    {
        float m_xVal;
        float m_yVal;
        float m_zVal;

        int m_intVal;

        public AdditionMutation(float value)
        {
            m_xVal = value;
        }

        public AdditionMutation(int value)
        {
            m_intVal = value;
        }

        public AdditionMutation(float x, float y)
        {
            m_xVal = x;
            m_yVal = y;
        }

        public AdditionMutation(float x, float y, float z)
        {
            m_xVal = x;
            m_yVal = y;
            m_zVal = z;
        }

        public static implicit operator FloatAdditionMutation(AdditionMutation m)
        {
            return new FloatAdditionMutation(m.m_xVal);
        }

        public static implicit operator IntegerAdditionMutation(AdditionMutation m)
        {
            return new IntegerAdditionMutation(m.m_intVal);
        }

        public static implicit operator Vector2AdditionMutation(AdditionMutation m)
        {
            return new Vector2AdditionMutation(new UnityEngine.Vector2(m.m_xVal, m.m_yVal));
        }

        public static implicit operator Vector3AdditionMutation(AdditionMutation m)
        {
            return new Vector3AdditionMutation(new UnityEngine.Vector3(m.m_xVal, m.m_yVal, m.m_zVal));
        }
    }
}
