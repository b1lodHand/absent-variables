using System.Text;
using UnityEditor;
using UnityEngine;

namespace com.absence.variablesystem.banksystembase.editor
{
    public static class EditorJobsHelper
    {
        [MenuItem("absencee_/absent-variables/Refresh VariableBank Database")]
        static void RefreshVBDatabase()
        {
            VariableBankDatabase.Refresh();

            StringBuilder sb = new StringBuilder();
            sb.Append("<b>[VBDATABASE] Banks found in assets: </b>");

            VariableBankDatabase.BanksInAssets.ForEach(bankAsset =>
            {
                sb.Append("\n\t");

                sb.Append("<color=white>");
                sb.Append("-> ");
                sb.Append(bankAsset.name);
                sb.Append("</color>");

                sb.Append($" [Guid: <color=white>{bankAsset.Guid}</color>]");
            });

            Debug.Log(sb.ToString());
        }
    }
}
