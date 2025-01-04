using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    public class MeteoriteMove : MonoBehaviour
    {
        public float Speed { get; set; } = 3;
        public float RotationSpeed { get; set; } = 100f;
        
        public Rigidbody2D Rigidbody;

        private void Start()
        {
            Rigidbody.linearVelocity = Vector2.down * Speed;
            Rigidbody.angularVelocity = RotationSpeed;
        }
        
    }
}