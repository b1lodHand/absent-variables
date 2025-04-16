namespace com.absence.variablesystem.banksystembase
{
    [System.Serializable]
    public class IndependentVariableComparer : DirectVariableComparer
    {
        public override bool CacheBankDirectly => true;
    }
}
