using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.StateData
{
    [CreateAssetMenu(fileName = "Windows", menuName = "Static Data/UI")]
    public class WindowsData: ScriptableObject
    {
        public List<WindowsConfig> Configs;
    }
}