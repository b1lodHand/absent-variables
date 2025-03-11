using com.absence.variablesystem.internals;

namespace com.absence.variablesystem.banksystembase
{
    public interface IGenericVariableContainer
    {
        public Variable<T> GetVariable<T>(string key);
        public bool TryGetVariable<T>(string key, out Variable<T> result);
        public bool HasVariable(string key);
        public bool SetVariable<T>(string key, T newValue);
    }
}
