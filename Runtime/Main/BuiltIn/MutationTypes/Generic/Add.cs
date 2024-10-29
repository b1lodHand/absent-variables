using com.absence.variablesystem.internals;
using com.absence.variablesystem.mutations.internals;

namespace com.absence.variablesystem.builtin.mutations
{
    [System.Serializable]
    public static class Add
    {
        public static FloatAdditionMutation CreateForFloat(float value, AffectionMethod additionType = AffectionMethod.InOrder)
        {
            return new FloatAdditionMutation(value, additionType);
        }

        public static IntegerAdditionMutation CreateForInteger(int value, AffectionMethod additionType = AffectionMethod.InOrder)
        {
            return new IntegerAdditionMutation(value, additionType);
        }
        
        public static Vector2AdditionMutation CreateForVec2(UnityEngine.Vector2 value, AffectionMethod additionType = AffectionMethod.InOrder)
        {
            return new Vector2AdditionMutation(value, additionType);
        }

        public static Vector3AdditionMutation CreateForVec3(UnityEngine.Vector3 value, AffectionMethod additionType = AffectionMethod.InOrder)
        {
            return new Vector3AdditionMutation(value, additionType);
        }

#if CAN_USE_TIMERS
        public static FloatAdditionMutation CreateForFloat(float value, float duration, AffectionMethod additionType = AffectionMethod.InOrder)
        {
            return new FloatAdditionMutation(value, additionType, duration);
        }

        public static IntegerAdditionMutation CreateForInteger(int value, float duration, AffectionMethod additionType = AffectionMethod.InOrder)
        {
            return new IntegerAdditionMutation(value, additionType, duration);
        }

        public static Vector2AdditionMutation CreateForVec2(UnityEngine.Vector2 value, float duration, AffectionMethod additionType = AffectionMethod.InOrder)
        {
            return new Vector2AdditionMutation(value, additionType, duration);
        }

        public static Vector3AdditionMutation CreateForVec3(UnityEngine.Vector3 value, float duration, AffectionMethod additionType = AffectionMethod.InOrder)
        {
            return new Vector3AdditionMutation(value, additionType, duration);
        }
#endif
    }
}
