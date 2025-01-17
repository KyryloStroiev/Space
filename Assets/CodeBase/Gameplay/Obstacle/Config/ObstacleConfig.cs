using UnityEngine;

namespace CodeBase.Gameplay.Obstacle
{
    [CreateAssetMenu(fileName = "obstacleConfig", menuName = "Static Data/Obstacle")]
    public class ObstacleConfig : ScriptableObject
    {
        public ObstacleTypeId TypeId;
        public float Speed;

        public GameObject Prefab;
        
    }
}