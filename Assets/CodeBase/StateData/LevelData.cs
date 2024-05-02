using UnityEngine;

namespace CodeBase.StateData
{
    [CreateAssetMenu(fileName = "Level", menuName = "Static Data/Level")]
    public class LevelData: ScriptableObject
    {
        public Vector3 PointPlayerInitialize;

        public Vector3 CenterPoitnEnemyInitialize;
        
        public float MaxRangeXPosition;

        public float MinTimeSpawnMeteorite = 1;
        public float MaxTimeSpawnMeteorite = 3;


    }
}