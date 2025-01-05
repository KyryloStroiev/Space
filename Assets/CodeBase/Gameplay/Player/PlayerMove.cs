using System;
using CodeBase.Service.InputsService;
using UnityEngine;

namespace CodeBase.Gameplay.Player
{
    public class PlayerMove : MonoBehaviour
    {
        public float Speed { get; set; }
        public float MaxXPosition { get; set; }

        public PlayerWing LeftWing;
        public PlayerWing RightWing;
        public Rigidbody2D Rigidbody;

        private Vector2 _direction;

        private const float SmoothSpeed = 3f;
        private float _targetDirection;
        private float _smoothDirection;
        public float Direction => _smoothDirection;
        
        private IInputService _inputService;


        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        private void Start() => 
            SetWingSpeed();

        private void FixedUpdate() => 
            Move();

        private void Update() => 
            MoveDirection();

        private void SetWingSpeed()
        {
            LeftWing.SpeedWing = RightWing.SpeedWing = Speed;
            LeftWing.ReducerSpeed();
            RightWing.ReducerSpeed();
        }

        private void Move()
        {
            Vector2 newPosition = Rigidbody.position + _direction * Time.fixedDeltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, -MaxXPosition, MaxXPosition);
            Rigidbody.MovePosition(newPosition);
        }



        private void MoveDirection()
        {
            float direction = _inputService.Axis();
            _targetDirection = direction;
            _smoothDirection = Mathf.Lerp(_smoothDirection, _targetDirection, SmoothSpeed * Time.deltaTime);
            if (direction < 0)
            {
                _direction.x = direction * LeftWing.SpeedWing;
            }
            else if (direction > 0)
            {
                _direction.x = direction * RightWing.SpeedWing;
            }
            else
            {
                _direction.x = 0;
            }
            _direction.y = 0;
        }

        
    }
}
