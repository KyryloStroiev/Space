using System;
using UnityEngine;

namespace CodeBase.Infrastraction.Factory
{
    public class MeteoriteMove : MonoBehaviour
    {
        public float Speed { get; set; } = 3;
        public float RotationSpeed { get; set; } = 100f;
        
        public Rigidbody2D Rigidbody;

        private void Start()
        {
            Rigidbody.velocity = Vector2.down * Speed;
            Rigidbody.angularVelocity = RotationSpeed;
        }
        
    }
}