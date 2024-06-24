using System.Text;
using UnityEditor;
using UnityEngine;

namespace com.absence.variablesystem.editor
{
    public static class EditorJobsHelper
    {
        [MenuItem("absencee_/absent-variables/Refresh VariableBank Database")]
        static void RefreshVBDatabase()
        {
            VariableBankDatabase.Refresh();

            StringBuilder sb = new StringBuilder();
            sb.Append("<color=white>Banks found in assets: </color>");

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
