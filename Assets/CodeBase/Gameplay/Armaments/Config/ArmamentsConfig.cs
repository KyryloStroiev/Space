using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay.Armaments
{
    [CreateAssetMenu(fileName = "armamentsConfig", menuName = "Config/ArmamentsConfig")]
    public class ArmamentsConfig : ScriptableObject
    {
        public ArmamentsTypeId TypeId;
        public List<ArmamentData> Datas;
    }
}