using System.Collections.Generic;

namespace com.absence.variablesystem.banksystembase
{
    public static class ExtensionMethods
    {
        public static void Validate<T>(this IEnumerable<VariableEntry<T>> array)
        {
            Dictionary<string, VariableEntry<T>> nameEntryPairs = new();

            foreach (var entry in array)
            {
                if (!nameEntryPairs.TryAdd(entry.Name, entry))
                {
                    nameEntryPairs[entry.Name].Error = true;
                    entry.Warning = true;
                }

                else
                {
                    entry.Error = false;
                    entry.Warning = false;
                }
            }
        }


        public static void Validate<T1, T2>(this IEnumerable<VariableEntry<T1, T2>> array) where T2 : Variable<T1>
        {
            Dictionary<string, VariableEntry<T1, T2>> nameEntryPairs = new();

            foreach (var entry in array)
            {
                if (!nameEntryPairs.TryAdd(entry.Name, entry))
                {
                    nameEntryPairs[entry.Name].Error = true;
                    entry.Warning = true;
                }

                else
                {
                    entry.Error = false;
                    entry.Warning = false;
                }
            }
        }
    }
}
