using System;
using CodeBase.Common.PhysicsService;
using CodeBase.Gameplay.Logic;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Armaments
{
    public class Laser : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        
        public LayerMask layerMask;
        
        private IPhysicsService _physicsService;
        
        private float _timerActive = 2;
        private float _timer = 0;
        
        private float scaleSpeed = 152;
        private Transform _shotPoint;
        private float _direction;


        public void Construct(IPhysicsService physicsService, Transform shotPoint, float direction)
        {
            _direction = direction;
            _shotPoint = shotPoint;
            _physicsService = physicsService;
           
        }

        private void OnEnable()
        {
            _timer = _timerActive;
        }

        private void Update()
        {
            Vector3 originalPosition = _shotPoint.position;
            
            Vector3 newScale = transform.localScale;

          
            newScale.x += scaleSpeed * Time.deltaTime;
            
           
            transform.localScale = newScale;

           
            transform.position = originalPosition + Vector3.right * _direction * (newScale.x - 1) / 2;
            
            
            Collider2D boxCastCollider = _physicsService.BoxCastCollider(transform, layerMask);
            Debug.Log(boxCastCollider);
            
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _timer = _timerActive;
                Destroy(gameObject);
            }
            
            
            
        }
    }
}