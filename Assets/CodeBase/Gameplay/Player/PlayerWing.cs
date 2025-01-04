using System.Collections.Generic;
using CodeBase.Gameplay.Logic;
using UnityEngine;

namespace CodeBase.Gameplay.Player
{
    public class PlayerWing : MonoBehaviour, IHealth
    {
        public float SpeedWing { get; set; }
        
        public List<GameObject> WingCubs = new();
        
        private float _speedReducer;

        public void ReducerSpeed()
        {
            _speedReducer = SpeedWing / WingCubs.Count;
        }
        
        public void TakeDamage(GameObject hitObject)
        {
            WingCubs.Remove(hitObject);
            SpeedWing -= _speedReducer;
        }
    }
}