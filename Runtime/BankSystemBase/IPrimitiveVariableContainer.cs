using com.absence.variablesystem.builtin;

namespace com.absence.variablesystem.banksystembase
{
    public interface IPrimitiveVariableContainer
    {
        public IntegerVariable GetInt(string variableName);
        public FloatVariable GetFloat(string variableName);
        public StringVariable GetString(string variableName);
        public BooleanVariable GetBoolean(string variableName);

        public bool HasInt(string variableName);
        public bool HasFloat(string variableName);
        public bool HasString(string variableName);
        public bool HasBoolean(string variableName);

        public bool SetInt(string variableName, int newValue);
        public bool SetFloat(string variableName, float newValue);
        public bool SetString(string variableName, string newValue);
        public bool SetBoolean(string variableName, bool newValue);

        public bool TryGetInt(string variableName, out int value);
        public bool TryGetFloat(string variableName, out float value);
        public bool TryGetString(string variableName, out string value);
        public bool TryGetBoolean(string variableName, out bool value);
    }
}
