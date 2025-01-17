using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.Config
{
    [CreateAssetMenu(fileName = "Windows", menuName = "Static Data/UI")]
    public class WindowsData: ScriptableObject
    {
        public List<WindowsConfig> Configs;
        
    }
}