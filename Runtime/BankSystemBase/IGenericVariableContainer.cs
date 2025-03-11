namespace com.absence.variablesystem.banksystembase
{
    public interface IGenericVariableContainer
    {
        public T Get<T>(string key);
        public Variable<T> GetVariable<T>(string key);
        public bool TryGetVariable<T>(string key, out Variable<T> result);
        public bool HasVariable(string key);
        public bool SetVariable<T>(string key, T newValue);
        public void AddValueChangeListener<T>(string key, VariableValueChangedCallbackContext<T> callbackAction);
    }
}
