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
    
        public float Score { get; set; }
    
        public Heart Heart;
        public List<GameObject> EmptyPoint = new ();
        public List<GameObject> Cube = new ();
        private SpawnMeteorite _spawnMeteorite;
        private IObjectPool _objectPool;

        public void Construct(SpawnMeteorite spawnMeteorite, IObjectPool objectPool)
        {
            _objectPool = objectPool;
            _spawnMeteorite = spawnMeteorite;
        }
        
        private void Start() => 
            Heart.Hit += Destroy;

        private void Update()
        {
            Debug.Log(Cube.Count);
        }

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
