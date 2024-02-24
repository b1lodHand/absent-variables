
using System.Collections.Generic;
using UnityEngine;

namespace com.absence.variablesystem
{
    public class Varcaster : MonoBehaviour
    {
        [SerializeField] private List<VariableComparer> m_comparers = new List<VariableComparer>();
        [SerializeField] private List<VariableSetter> m_setters = new List<VariableSetter>();
    }
}