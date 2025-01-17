using System;
using System.Collections.Generic;
using CodeBase.Common.PhysicsService;
using CodeBase.Gameplay.Sounds;
using UnityEngine;

namespace CodeBase.Gameplay.Logic
{
    public class ShipBox : MonoBehaviour
    {
        public LayerMask LayerMask;
        
        public List<GameObject> AllBoxs;
        
        public GameObject ParticleEffect;
        public Sound Sound;
        private IObjectPool _objectPool;
        private IPhysicsService _physicsService;
        private List<GameObject> _boxesToRemove = new();

        public void Construct(IObjectPool objectPool, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _objectPool = objectPool;
        }

        private void Update()
        {
            DestroyShipBox();
        }

        private void DestroyShipBox()
        {
            _boxesToRemove.Clear();
            foreach (GameObject box in AllBoxs)
            {
                if (box == null) continue; 
                
                if (CollisionMeteorite(box) != null)
                {
                    Instantiate(ParticleEffect, box.transform.position, Quaternion.identity);
                    Destroy(CollisionMeteorite(box).gameObject);
                    Sound.PlayOneShot(SoundType.PlayerHit);
                    _boxesToRemove.Add(box);     
                    Destroy(box);                 
                }
            }
            foreach (GameObject box in _boxesToRemove)
            {
                AllBoxs.Remove(box); 
            }
        }

        private Collider2D CollisionMeteorite(GameObject box) => 
            _physicsService.BoxCastCollider(box.transform, LayerMask);

        
    }
}
