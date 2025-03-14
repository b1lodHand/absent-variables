namespace com.absence.variablesystem.banksystembase
{
    [System.Serializable]
    public class VariableNamePair
    {
        public string Name = string.Empty;
    }

    [System.Serializable]
    public class VariableNamePair<T1, T2> : VariableNamePair where T2 : Variable<T1>
    {
        public T2 Variable = default;
    }

    [System.Serializable]
    public class VariableNamePair<T> : VariableNamePair<T, Variable<T>>
    {
    }
}
