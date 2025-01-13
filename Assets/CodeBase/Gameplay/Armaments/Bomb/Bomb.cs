using System;
using CodeBase.Common.PhysicsService;
using CodeBase.Gameplay.Logic;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.Armaments
{
    public class Bomb : MonoBehaviour
    {
        public float TimeToExplode { get; set; }
        public float CircleRadius {get; set;}
        
        public LayerMask LayerMask;

        public BombAnimation BombAnimation;

        private IObjectPool _objectPool;
        private IPhysicsService _physicsService;
        private float _timeToExplode;
        
        public void Construct(IObjectPool objectPool, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _objectPool = objectPool;
            
        }

        private void OnEnable()
        {
            _timeToExplode = TimeToExplode;
        }


        private void Update()
        {
            StartCountdown();
            Explode();
        }

        private void StartCountdown()
        {
            if (CheckMeteorite().Length > 0)
            {
                _timeToExplode -= Time.deltaTime;
            }
        }

        private void Explode()
        {
            if (_timeToExplode <= 0)
            {
                foreach (Collider2D meteorite in CheckMeteorite())
                {
                    Destroy(meteorite.gameObject);
                    
                }
                BombAnimation.StopBlinking();
                _objectPool.DisableObject(gameObject, ArmamentsTypeId.Bomb);
            }
            
        }
        

        private Collider2D[] CheckMeteorite() => 
            _physicsService.CircleAllCastCollider(transform.position,  CircleRadius, LayerMask);

        
        
       
    }
}