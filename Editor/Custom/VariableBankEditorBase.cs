using com.absence.variablesystem.banksystembase;
using UnityEditor;
using UnityEngine;

namespace com.absence.variablesystem.editor
{
    [CustomEditor(typeof(VariableBank), true, isFallback = true)]
    public class VariableBankEditorBase : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawIMGUI(true);
        }

        public virtual void DrawIMGUI(bool drawDetails)
        {
            VariableBank bank = (VariableBank)target;

            if (drawDetails)
            {
                DrawDetails(true);
                EditorGUILayout.Space(10);
            }

            Undo.RecordObject(target, "Variable Bank (Inspector)");

            EditorGUI.BeginChangeCheck();
            serializedObject.UpdateIfRequiredOrScript();
            SerializedProperty iterator = serializedObject.GetIterator();
            bool enterChildren = true;
            while (iterator.NextVisible(enterChildren))
            {
                using (var scope = new EditorGUIHiddenScope("m_Script" == iterator.propertyPath ||
                                                            "m_guid" == iterator.propertyPath ||
                                                            "m_forExternalUse" == iterator.propertyPath))
                {
                    if (!scope.Hidden) EditorGUILayout.PropertyField(iterator, true);
                }

                enterChildren = false;
            }

            serializedObject.ApplyModifiedProperties();
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(target);
            }

            void DrawDetails(bool disabled)
            {
                if (disabled) GUI.enabled = false;

                GUIStyle detailStyle = new GUIStyle(GUI.skin.label);
                detailStyle.richText = true;

                GUIStyle detailTitleStyle = new GUIStyle("window");
                detailTitleStyle.richText = true;

                GUILayout.BeginVertical("<b>Details</b>", detailTitleStyle);

                GUILayout.BeginHorizontal();

                EditorGUILayout.LabelField($"<b>Name:</b> {bank.name}", detailStyle, GUILayout.ExpandWidth(true));
                if (disabled) GUI.enabled = true;
                if (GUILayout.Button("Copy", GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false)))
                {
                    GUIUtility.systemCopyBuffer = bank.name;
                }

                if (disabled) GUI.enabled = false;

                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();

                EditorGUILayout.LabelField($"<b>Guid:</b> {bank.Guid}", detailStyle, GUILayout.ExpandWidth(true));
                if (disabled) GUI.enabled = true;
                if (GUILayout.Button("Copy", GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false)))
                {
                    GUIUtility.systemCopyBuffer = bank.Guid;
                }

                if (disabled) GUI.enabled = false;

                GUILayout.EndHorizontal();

                EditorGUILayout.EndVertical();
                GUILayout.FlexibleSpace();

                if (disabled) GUI.enabled = true;
            }
        }
    }
}
