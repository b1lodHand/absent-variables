
using System.IO;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace com.absence.variablesystem.Editor
{
    public class VariableBankCreationHandler
    {
        private static readonly string k_createPath = "Assets/Scriptables/VariableBanks";

        [MenuItem("absence/core/variable system/Create Variable Bank", priority = 0)]
        static void CreateVariableBank()
        {
            CreateVariableBankEndNameEditAction create = ScriptableObject.CreateInstance<CreateVariableBankEndNameEditAction>();
            var path = Path.Combine(k_createPath, "New VariableBank.asset");
            var icon = EditorGUIUtility.IconContent("d_ScriptableObject Icon").image as Texture2D;

            if (!AssetDatabase.IsValidFolder("Assets/Scriptables")) AssetDatabase.CreateFolder("Assets", "Scriptables");
            if (!AssetDatabase.IsValidFolder("Assets/Scriptables/VariableBanks")) AssetDatabase.CreateFolder("Assets/Scriptables", "VariableBanks");

            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, create, path, icon, null);
        }

        internal class CreateVariableBankEndNameEditAction : EndNameEditAction
        {
            public override void Action(int instanceId, string pathName, string resourceFile)
            {
                var itemCreated = ScriptableObject.CreateInstance<VariableBank>();

                AssetDatabase.CreateAsset(itemCreated, pathName);
                itemCreated.OnDestroyAction += () =>
                {
                    VariableSetterDrawer.RefreshBanks();
                    VariableComparerDrawer.RefreshBanks();
                };

                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                VariableSetterDrawer.RefreshBanks();
                VariableComparerDrawer.RefreshBanks();

                Selection.activeObject = itemCreated;
            }

            public override void Cancelled(int instanceId, string pathName, string resourceFile)
            {
                VariableBank item = EditorUtility.InstanceIDToObject(instanceId) as VariableBank;
                ScriptableObject.DestroyImmediate(item);
            }
        }
    }

}