namespace com.absence.variablesystem.banksystembase
{
    [System.Serializable]
    public class VariableEntry
    {
        public string Name = string.Empty;
    }

    [System.Serializable]
    public class VariableEntry<T1, T2> : VariableEntry where T2 : Variable<T1>
    {
        public T2 Variable = default;
    }

    [System.Serializable]
    public class VariableEntry<T> : VariableEntry<T, Variable<T>>
    {
    }
}
