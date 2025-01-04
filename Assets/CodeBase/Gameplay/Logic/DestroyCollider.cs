using System;
using CodeBase.Common.PhysicsService;
using CodeBase.Gameplay.Armaments;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Logic
{
    public class DestroyCollider : MonoBehaviour
    {
        public LayerMask CubeLayer;
        public LayerMask HeartMeteoriteLayer;
        
        private IPhysicsService _physicsService;
        private IObjectPool _objectPool;

        [Inject]
        private void Construct(IPhysicsService physicsService, IObjectPool objectPool)
        {
            _objectPool = objectPool;
            _physicsService = physicsService;
        }

        private void Update()
        {
            CheckCube();
        }

        private void CheckCube()
        {
            if ( CubeMeteorite(CubeLayer) != null)
            {
                _objectPool.DisableObject(CubeMeteorite(CubeLayer).gameObject, ArmamentsTypeId.CubeMeteorite);
            }
            else if (CubeMeteorite(HeartMeteoriteLayer) != null)
            {
                Destroy(CubeMeteorite(HeartMeteoriteLayer).gameObject);
            }
        }

        private Collider2D CubeMeteorite(LayerMask layerMask) => 
            _physicsService.BoxCastCollider(transform, layerMask);
     
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            
            Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z), Vector3.one);
            Gizmos.DrawWireCube(Vector3.zero, transform.localScale);
        }
    }
}
