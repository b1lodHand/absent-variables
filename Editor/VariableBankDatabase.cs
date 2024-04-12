using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace com.absence.variablesystem.Editor
{
    [InitializeOnLoad]
    public static class VariableBankDatabase
    {
        static List<VariableBank> m_banks;
        public static List<VariableBank> Banks => m_banks;

        static VariableBankDatabase()
        {
            m_banks = new List<VariableBank>();
            Refresh();
        }

        public static bool NoBanks => m_banks.Count == 0;

        public static void Refresh()
        {
            m_banks = AssetDatabase.FindAssets("t:VariableBank").ToList().ConvertAll(foundGuid =>
            {
                return AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(foundGuid), typeof(VariableBank)) as VariableBank;
            });
        }

        public static bool Exists(string bankName)
        {
            return m_banks.Where(b => b.name == bankName).ToList().Count > 0;
        }

        public static VariableBank GetBankIfExists(string bankName)
        {
            if (Exists(bankName)) return m_banks.Where(b => b.name == bankName).FirstOrDefault();
            else return null;
        }

        public static List<string> GetBankNameList()
        {
            return m_banks.ConvertAll(b => b.name);
        }
    }
}
