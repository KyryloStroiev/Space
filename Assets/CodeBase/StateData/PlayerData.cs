using System;
using UnityEngine;

namespace CodeBase.StateData
{
    [CreateAssetMenu(fileName = "Player", menuName = "Static Data/Player")]
    public class PlayerData: ScriptableObject
    {
        public float Speed;
        
        public float SpeedBullet;

        public float MaxXPosition = 50;

       
    }
}