using System;
using System.Collections.Generic;
using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Logic;
using CodeBase.Gameplay.Sounds;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Gameplay.Enemy
{
    public class Meteorite : MonoBehaviour
    {
        public GameObject ParticleEffect;
        public Sound Sound;
    
        public int Score { get; set; }
    
        public Heart Heart;
        public List<GameObject> EmptyPoint = new ();
        public List<GameObject> Cube = new ();
        private SpawnMeteorite _spawnMeteorite;

        public void Construct(SpawnMeteorite spawnMeteorite)
        {
            _spawnMeteorite = spawnMeteorite;
        }
        
        private void Start() => 
            Heart.Hit += Destroy;
        
        private void Destroy()
        {
            _spawnMeteorite.DestroyMeteor(Score);
            Instantiate(ParticleEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        private void OnDisable() => 
            Heart.Hit -= Destroy;
    }
}
