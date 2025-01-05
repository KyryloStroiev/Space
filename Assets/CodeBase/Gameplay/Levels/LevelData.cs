using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Gameplay.Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "Static Data/Level")]
    public class LevelData: ScriptableObject
    {
        public Vector3 PointPlayerInitialize;

        public Vector3 CenterPoitnEnemyInitialize;
        
        
        public GameObject Hud;

    }
}