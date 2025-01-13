using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    [CreateAssetMenu(fileName = "Meteorite", menuName = "Static Data/Meteorite")]
    public class MeteoriteData : ScriptableObject
    {
        public MeteoriteTypeId MeteoriteTypeId;
        
        public float Speed;
        public float RotationSpeed = 100f;

        public int Score = 5;
        
        public float MaxFillPercentageMeteorite = 70;
        public float MinFillPercentageMeteorite = 20;

        
        public GameObject MeteoritePrefab;
    }
}