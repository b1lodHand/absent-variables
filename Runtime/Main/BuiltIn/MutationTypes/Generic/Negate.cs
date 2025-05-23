using com.absence.variablesystem.mutations.internals;

namespace com.absence.variablesystem.mutations
{
    public static class Negate
    {
        public static FloatNegateMutation CreateForFloat(float value, AffectionMethod negType = AffectionMethod.InOrder)
        {
            return new FloatNegateMutation(value, negType);
        }

        public static IntegerNegateMutation CreateForInteger(int value, AffectionMethod negType = AffectionMethod.InOrder)
        {
            return new IntegerNegateMutation(value, negType);
        }

        public static Vector2NegateMutation CreateForVec2(UnityEngine.Vector2 value, AffectionMethod negType = AffectionMethod.InOrder)
        {
            return new Vector2NegateMutation(value, negType);
        }

        public static Vector3NegateMutation CreateForVec3(UnityEngine.Vector3 value, AffectionMethod negType = AffectionMethod.InOrder)
        {
            return new Vector3NegateMutation(value, negType);
        }

        public static BooleanInvertMutation CreateForBoolean(AffectionMethod negType = AffectionMethod.InOrder)
        {
            return new BooleanInvertMutation(negType);
        }

#if CAN_USE_TIMERS
        public static FloatNegateMutation CreateTimedForFloat(float value, float duration, AffectionMethod negType = AffectionMethod.InOrder)
        {
            return new FloatNegateMutation(value, negType, duration);
        }

        public static IntegerNegateMutation CreateTimedForInteger(int value, float duration, AffectionMethod negType = AffectionMethod.InOrder)
        {
            return new IntegerNegateMutation(value, negType, duration);
        }

        public static Vector2NegateMutation CreateTimedForVec2(UnityEngine.Vector2 value, float duration, AffectionMethod negType = AffectionMethod.InOrder)
        {
            return new Vector2NegateMutation(value, negType, duration);
        }

        public static Vector3NegateMutation CreateTimedForVec3(UnityEngine.Vector3 value, float duration, AffectionMethod negType = AffectionMethod.InOrder)
        {
            return new Vector3NegateMutation(value, negType, duration);
        }

        public static BooleanInvertMutation CreateTimedForBoolean(float duration, AffectionMethod negType = AffectionMethod.InOrder)
        {
            return new BooleanInvertMutation(negType, duration);
        }
#endif
    }
}
