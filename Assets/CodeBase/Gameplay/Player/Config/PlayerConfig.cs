using CodeBase.Gameplay.Logic;
using UnityEngine;

namespace CodeBase.Gameplay.Player
{
    [CreateAssetMenu(fileName = "Player", menuName = "Config/Player")]
    public class PlayerConfig: ScriptableObject
    {
        public float Speed = 15f;

        public float SpeedBullet = 10f;

        public float MaxXPosition = 44f;
        
        public GameObject PlayerPrefab;
        public GameObject BulletPrefab;
        


    }
}