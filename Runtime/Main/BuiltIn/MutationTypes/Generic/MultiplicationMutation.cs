using com.absence.variablesystem.mutations.builtin.internals;

namespace com.absence.variablesystem.mutations.builtin
{
    public class MultiplicationMutation
    {
        float m_xVal;
        float m_yVal;
        float m_zVal;

        int m_intVal;

        public MultiplicationMutation(float value)
        {
            m_xVal = value;
        }

        public MultiplicationMutation(int value)
        {
            m_intVal = value;
        }

        public MultiplicationMutation(float x, float y)
        {
            m_xVal = x;
            m_yVal = y;
        }

        public MultiplicationMutation(float x, float y, float z)
        {
            m_xVal = x;
            m_yVal = y;
            m_zVal = z;
        }

        public static implicit operator FloatMultiplicationMutation(MultiplicationMutation m)
        {
            return new FloatMultiplicationMutation(m.m_xVal);
        }

        public static implicit operator IntegerMultiplicationMutation(MultiplicationMutation m)
        {
            return new IntegerMultiplicationMutation(m.m_intVal);
        }

        public static implicit operator Vector2MultiplicationMutation(MultiplicationMutation m)
        {
            return new Vector2MultiplicationMutation(new UnityEngine.Vector2(m.m_xVal, m.m_yVal));
        }

        public static implicit operator Vector3MultiplicationMutation(MultiplicationMutation m)
        {
            return new Vector3MultiplicationMutation(new UnityEngine.Vector3(m.m_xVal, m.m_yVal, m.m_zVal));
        }
    }
}
