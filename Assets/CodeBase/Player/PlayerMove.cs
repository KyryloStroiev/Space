using System;
using CodeBase.Player;
using UnityEngine;

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
    private float YStartPosition;
    
    private PlayerController _controller;

    private void Awake()
    {
        YStartPosition = transform.position.y;
        _controller = new PlayerController();
    }

    private void Start()
    {
        LeftWing.SpeedWing = RightWing.SpeedWing = Speed;
        LeftWing.ReducerSpeed();
        RightWing.ReducerSpeed();
    }


    private void FixedUpdate() => 
        Move();

    private void Update() => 
        MoveLeftRight();

    private void Move()
    {
        Vector2 newPosition = Rigidbody.position + _direction * Time.fixedDeltaTime;
        newPosition.y = YStartPosition;
        newPosition.x = Mathf.Clamp(newPosition.x, -MaxXPosition, MaxXPosition);
        Rigidbody.MovePosition(newPosition);
    }



    private void MoveLeftRight()
    {
        float direction = Axis();
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

    private float Axis() => 
        _controller.Player.Move.ReadValue<float>();

    private void OnEnable() => 
        _controller?.Enable();

    private void OnDisable() => 
        _controller?.Disable();
}
