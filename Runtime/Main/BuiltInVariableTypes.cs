using System.Linq;
using UnityEngine;
using com.absence.variablesystem.mutations;

namespace com.absence.variablesystem
{
    [System.Serializable]
    public class Variable_Integer : Variable<int>
    {
        public Variable_Integer() { }

        public Variable_Integer(string name, int value) : base(name, value)
        {
        }

        protected override void RevertMutations()
        {
            if (m_mutations.Count == 0) return;

            var value = Value;

            var additives = m_mutations.Where(m => m.MutationType == MutationType.Additive).ToList();
            var multiplicatives = m_mutations.Where(m => m.MutationType == MutationType.Multiplicative).ToList();

            multiplicatives.ForEach(m =>
            {
                value /= m.MutationValue;
            });

            additives.ForEach(m =>
            {
                value -= m.MutationValue;
            });

            Value = value;
        }

        protected override void ApplyMutations()
        {
            if (m_mutations.Count == 0) return;

            var value = Value;

            var additives = m_mutations.Where(m => m.MutationType == MutationType.Additive).ToList();
            var multiplicatives = m_mutations.Where(m => m.MutationType == MutationType.Multiplicative).ToList();

            additives.ForEach(m =>
            {
                value += m.MutationValue;
            });

            multiplicatives.ForEach(m =>
            {
                value *= m.MutationValue;
            });

            Value = value;
        }
    }

    [System.Serializable]
    public class Variable_Float : Variable<float>
    {
        public Variable_Float() : base() { }

        public Variable_Float(string name, float value) : base(name, value)
        {
        }

        protected override void RevertMutations()
        {
            var value = Value;

            var additives = m_mutations.Where(m => m.MutationType == MutationType.Additive).ToList();
            var multiplicatives = m_mutations.Where(m => m.MutationType == MutationType.Multiplicative).ToList();

            multiplicatives.ForEach(m =>
            {
                value /= m.MutationValue;
            });

            additives.ForEach(m =>
            {
                value -= m.MutationValue;
            });

            Value = value;
        }

        protected override void ApplyMutations()
        {
            var value = Value;

            var additives = m_mutations.Where(m => m.MutationType == MutationType.Additive).ToList();
            var multiplicatives = m_mutations.Where(m => m.MutationType == MutationType.Multiplicative).ToList();

            additives.ForEach(m =>
            {
                value += m.MutationValue;
            });

            multiplicatives.ForEach(m =>
            {
                value *= m.MutationValue;
            });

            Value = value;
        }
    }

    [System.Serializable]
    public class Variable_Vector3
    {
        public Variable_Float X { get; set; } = new Variable_Float();
        public Variable_Float Y { get; set; } = new Variable_Float();
        public Variable_Float Z { get; set; } = new Variable_Float();

        public Vector3 GetValue() => new Vector3(X.Value, Y.Value, Z.Value);
        public void SetValue(Vector3 newValue)
        {
            X.Value = newValue.x;
            Y.Value = newValue.y;
            Z.Value = newValue.z;
        }

        public void AddMutation(Mutation<float> mutation)
        {
            X.AddMutation(mutation);
            Y.AddMutation(mutation);
            Z.AddMutation(mutation);
        }
    }

    [System.Serializable]
    public class Variable_String : Variable<string>
    {
        public Variable_String() : base() { }

        public Variable_String(string name, string value) : base(name, value) 
        {
        }

        protected override void ApplyMutations()
        {

        }

        protected override void RevertMutations()
        {

        }
    }

    [System.Serializable]
    public class Variable_Boolean : Variable<bool>
    {
        public Variable_Boolean() : base() { }

        public Variable_Boolean(string name, bool value) : base(name, value) 
        { 
        }

        protected override void ApplyMutations()
        {

        }

        protected override void RevertMutations()
        {

        }
    }
}
