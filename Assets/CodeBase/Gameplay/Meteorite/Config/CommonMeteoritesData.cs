using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    [CreateAssetMenu(fileName = "commonMeteoritesConfig", menuName = "Static Data/MeteoritesConfig", order = 0)]
    public class CommonMeteoritesData : ScriptableObject
    {
        public float MinTimeSpawnMeteorite = 1;
        public float MaxTimeSpawnMeteorite = 3;
        
        public GameObject SpawnMeteoritePrefab;
        public GameObject CubeMeteoritePrefab;
    }
}