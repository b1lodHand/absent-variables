namespace com.absence.variablesystem.internals
{
    /// <summary>
    /// Used for the event system of variables.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VariableValueChangedCallbackContext<T>
    {
        public T previousValue { get; set; }
        public T newValue { get; set; }
    }
}
