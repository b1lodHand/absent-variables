using System;

namespace com.absence.variablesystem.editor
{
    internal readonly struct EditorGUIHiddenScope : IDisposable
    {
        public bool Hidden { get; }

        public EditorGUIHiddenScope(bool condition)
        {
            Hidden = condition;
        }

        public void Dispose() { }
    }
}
