using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    [CreateAssetMenu(fileName = "commonMeteoritesConfig", menuName = "Static Data/MeteoritesConfig", order = 0)]
    public class CommonMeteoritesData : ScriptableObject
    {
        public float MinTimeSpawnMeteorite;
        public float MaxTimeSpawnMeteorite;
        
        public GameObject SpawnMeteoritePrefab;
        public GameObject CubeMeteoritePrefab;
    }
}