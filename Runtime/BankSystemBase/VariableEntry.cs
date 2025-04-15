using UnityEngine;

namespace com.absence.variablesystem.banksystembase
{
    [System.Serializable]
    public class VariableEntry
    {
        public string Name = string.Empty;
        public string Guid = string.Empty;

#if UNITY_EDITOR
        [SerializeField] internal bool Warning = false;
        [SerializeField] internal bool Error = false;
#endif
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
