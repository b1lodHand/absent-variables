namespace com.absence.variablesystem.banksystembase
{
    public interface IVariableContainerOfType<T>
    {
        public T Get(string key);
        public Variable<T> GetVariable(string key);
        public bool TryGetVariable(string key, out Variable<T> result);
        public bool HasVariable(string key);
        public bool SetVariable(string key, T newValue);
        public void AddValueChangeListener(string key, VariableValueChangedCallbackContext<T> callbackAction);
    }
}
