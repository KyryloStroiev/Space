using System;
using UnityEngine;

namespace CodeBase.Gameplay.Armaments
{
    [Serializable]
    public class ArmamentData
    {
        public int MaxSpawnCount;
        
        public float Speed;
        public float CircleRadius;
        public float TimeToExplode;
        public GameObject Prefab;
        
        
    }
}