using System;
using System.Collections;
using CodeBase.Common.PhysicsService;
using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Gameplay.Logic
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody2D Rigidbody;

        public LayerMask CubeMask;
        public LayerMask HeartLayerMask;

        public float CircleOffsetY;
        public float CircleRadius;
        public float SpeedBullet { get; set; }
        
        private IObjectPool _objectPool;
        private float _durationDestroyBullet = 6f;
        private IPhysicsService _physicsService;


        public void Construct(IObjectPool objectPool, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _objectPool = objectPool;
        }


        private void Update()
        {
            CheckCube();
        }

        public void OnSpawned()
        {
            StartShot();
        }

        public void StartShot()
        {
            Rigidbody.linearVelocity = Vector3.up * SpeedBullet;
            StartCoroutine(ReturnToPool(_durationDestroyBullet));
        }

        private void CheckCube()
        {
            if ( CubeMeteorite(CubeMask) != null)
            {
                
                Destroy(CubeMeteorite(CubeMask).gameObject);
                StartCoroutine(ReturnToPool(0.02f));
            }
        }

        private Collider2D CubeMeteorite(LayerMask layerMask) => 
            _physicsService.CircleCastCollider(transform.position, CircleOffsetY, CircleRadius, layerMask);
        
        public IEnumerator ReturnToPool(float duration)
        {
            yield return new WaitForSeconds(duration);
            _objectPool.DisableObject(gameObject, ArmamentsTypeId.Bullet);
        }
        
        private void OnDrawGizmos()
        {
            
            Gizmos.color = Color.red;

           
            Vector2 playerCenter = (Vector2)transform.position + new Vector2(0, CircleOffsetY);

           
            Gizmos.DrawWireSphere(playerCenter, CircleRadius);
        }
        
    }
}