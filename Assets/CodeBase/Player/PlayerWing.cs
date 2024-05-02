using System;
using System.Collections.Generic;
using CodeBase.Logic;
using UnityEngine;


namespace CodeBase.Player
{
    public class PlayerWing : MonoBehaviour, IHealth
    {
        public float SpeedWing;
        
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