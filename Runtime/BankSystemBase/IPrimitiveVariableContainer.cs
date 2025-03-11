using com.absence.variablesystem.builtin;
using System;

namespace com.absence.variablesystem.banksystembase
{
    public interface IPrimitiveVariableContainer
    {
        public int GetInt(string variableName);
        public float GetFloat(string variableName);
        public string GetString(string variableName);
        public bool GetBoolean(string variableName);

        public IntegerVariable GetIntVariable(string variableName);
        public FloatVariable GetFloatVariable(string variableName);
        public StringVariable GetStringVariable(string variableName);
        public BooleanVariable GetBooleanVariable(string variableName);

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

        public void AddValueChangeListenerToInt(string variableName, Action<VariableValueChangedCallbackContext<int>> callbackAction);
        public void AddValueChangeListenerToFloat(string variableName, Action<VariableValueChangedCallbackContext<float>> callbackAction);
        public void AddValueChangeListenerToString(string variableName, Action<VariableValueChangedCallbackContext<string>> callbackAction);
        public void AddValueChangeListenerToBoolean(string variableName, Action<VariableValueChangedCallbackContext<bool>> callbackAction);
    }
}
