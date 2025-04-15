//using UnityEditor;
//using UnityEngine;

//namespace com.absence.variablesystem.editor
//{
//    [CustomPropertyDrawer(typeof(VariableEntries), true)]
//    public class VariableEntriesPropertyDrawer : PropertyDrawer
//    {
//        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//        {
//            SerializedProperty listProp = property.FindPropertyRelative("All");

//            return EditorGUI.GetPropertyHeight(listProp, label, listProp.isExpanded);
//        }

//        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//        {
//            SerializedProperty listProp = property.FindPropertyRelative("All");
            
//            using (var scope = new EditorGUI.ChangeCheckScope())
//            {

//            }

//            EditorGUI.PropertyField(position, listProp, label, listProp.isExpanded);
//        }
//    }
//}
