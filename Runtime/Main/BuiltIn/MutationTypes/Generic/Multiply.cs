using com.absence.variablesystem.mutations.internals;
using UnityEngine;

namespace com.absence.variablesystem.mutations
{
    public static class Multiply
    {
        public static FloatMultiplicationMutation CreateForFloat(float value, AffectionMethod mulType  = AffectionMethod.InOrder)
        {
            return new FloatMultiplicationMutation(value, mulType);
        }

        public static IntegerMultiplicationMutation CreateForInteger(int value, AffectionMethod mulType = AffectionMethod.InOrder)
        {
            return new IntegerMultiplicationMutation(value, mulType);
        }

        public static Vector2MultiplicationMutation CreateForVec2(Vector2 value, AffectionMethod mulType = AffectionMethod.InOrder)
        {
            return new Vector2MultiplicationMutation(value, mulType);
        }

        public static Vector3MultiplicationMutation CreateForVec3(Vector3 value, AffectionMethod mulType = AffectionMethod.InOrder)
        {
            return new Vector3MultiplicationMutation(value, mulType);
        }

#if CAN_USE_TIMERS
        public static FloatMultiplicationMutation CreateTimedForFloat(float value, float duration, AffectionMethod mulType = AffectionMethod.InOrder)
        {
            return new FloatMultiplicationMutation(value, mulType, duration);
        }

        public static IntegerMultiplicationMutation CreateTimedForInteger(int value, float duration, AffectionMethod mulType = AffectionMethod.InOrder)
        {
            return new IntegerMultiplicationMutation(value, mulType, duration);
        }

        public static Vector2MultiplicationMutation CreateTimedForVec2(Vector2 value, float duration, AffectionMethod mulType = AffectionMethod.InOrder)
        {
            return new Vector2MultiplicationMutation(value, mulType, duration);
        }

        public static Vector3MultiplicationMutation CreateTimedForVec3(Vector3 value, float duration, AffectionMethod mulType = AffectionMethod.InOrder)
        {
            return new Vector3MultiplicationMutation(value, mulType, duration);
        }
#endif
    }
}
