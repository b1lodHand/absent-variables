using com.absence.variablesystem.banksystembase;

namespace com.absence.variablesystem.banksystem
{
    [System.Serializable]
    public class DirectVariableComparer : VariableComparerBase
    {
        public override bool HasFixedBank => false;
        public override bool BankAsDirectReference => true;
        public override bool CacheBankDirectly => true;

        protected override IPrimitiveVariableContainer GetRuntimeBank()
        {
            return null;
        }
    }
}
