using System.Collections.Generic;
using CodeBase.Common.PhysicsService;
using CodeBase.Gameplay.Logic;
using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    public class Meteorite : MonoBehaviour, IDamageTaken
    {
       
        public GameObject ParticleEffect;
        public Sound Sound;
    
        public int Score { get; set; }
        
        public List<GameObject> EmptyPoint = new ();
        public List<GameObject> Cube = new ();
        private SpawnMeteorite _spawnMeteorite;
        private IPhysicsService _physicsService;

        public void Construct(SpawnMeteorite spawnMeteorite, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _spawnMeteorite = spawnMeteorite;
        }

        
        private void Destroy()
        {
            _spawnMeteorite.DestroyMeteor(Score);
            Instantiate(ParticleEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


        public void TakeDamage()
        {
            Destroy();
        }
    }
}
