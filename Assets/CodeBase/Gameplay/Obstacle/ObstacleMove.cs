using System;
using UnityEngine;

namespace CodeBase.Gameplay.Obstacle
{
    public class ObstacleMove : MonoBehaviour
    {
        public Rigidbody2D Rigidbody;
        public float Speed {set; get;}
        
        private void Start()
        {
            Rigidbody.linearVelocity = new Vector2(0,Speed * -1);
        }

       
    }
}