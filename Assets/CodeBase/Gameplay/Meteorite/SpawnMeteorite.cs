﻿using System;
using CodeBase.Common.PhysicsService;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Logic;
using CodeBase.Gameplay.Obstacle;
using CodeBase.Gameplay.Obstacle.Factory;
using CodeBase.Gameplay.Sounds;
using CodeBase.UI.Service;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Gameplay.Enemy
{
    public class SpawnMeteorite: MonoBehaviour
    {
        public float MinTimeSpawn { get; set; }
        public float MaxTimeSpawn { get; set; }

        public Sound Sound;

        private float _timeSpawn;
        private float _cooldownReduction= 0.015f;
        private float _maxTimeSpawn;
        
        private IMeteoriteFactory _meteoriteFactory;
        private IHudService _hudService;
        private IObstacleFactory _obstacleFactory;
        private IPhysicsService _physicsService;

        public void Construct(IMeteoriteFactory meteoriteFactory, IHudService hudService, IObstacleFactory obstacleFactory, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _obstacleFactory = obstacleFactory;
            _hudService = hudService;
            _meteoriteFactory = meteoriteFactory;
        }

        private void Start()
        {
            _maxTimeSpawn = MaxTimeSpawn;
            SetTimeSpawn();
        }

        private void Update()
        {
            ChangeSpawnTime();
            
            if (CanSpawn())
            {
                SpawnMeteorites();
                SetTimeSpawn();
                ReducingSpawnTime();
            }
            
        }


        private void SpawnMeteorites()
        {
            GameObject meteorite = _meteoriteFactory.CreateMeteorite(GetRandomType());
            meteorite.GetComponent<Meteorite>().Construct(this, _physicsService);
        }
        

        private MeteoriteTypeId GetRandomType() => 
            (MeteoriteTypeId)Random.Range(0, Enum.GetValues(typeof(MeteoriteTypeId)).Length);


        private void SetTimeSpawn() => 
            _timeSpawn = Random.Range(MinTimeSpawn, _maxTimeSpawn);

        private void ReducingSpawnTime()
        {
            if (_maxTimeSpawn > MinTimeSpawn)
            {
                _maxTimeSpawn -= _cooldownReduction;
            }
            else
            {
                _maxTimeSpawn = MinTimeSpawn;
            }
        }

        private void ChangeSpawnTime() => 
            _timeSpawn -= Time.deltaTime;

        private bool CanSpawn() => 
            _timeSpawn <= 0;

        
        public void DestroyMeteor(int score)
        {
            Sound.PlayOneShot(SoundType.MeteoriteDamage);
            _hudService.GetScore(score);
        }
    }
    
    
}