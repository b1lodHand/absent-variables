namespace com.absence.variablesystem.banksystembase
{
    [System.Serializable]
    public class IndependentVariableSetter : DirectVariableSetter
    {
        public override bool CacheBankDirectly => true;
    }
}
