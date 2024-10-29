using UnityEditor;

namespace com.absence.variablesystem.editor
{
    internal static class ExtensionMethods
    {
        internal static bool IsArrayElement(this SerializedProperty property)
        {
            return property.propertyPath.Contains("Array");
        }
    }
}
