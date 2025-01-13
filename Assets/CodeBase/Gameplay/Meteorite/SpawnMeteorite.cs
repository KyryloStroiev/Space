using System;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Logic;
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
        public event Action<float> DestroyMeteorite;

        private float _timeSpawn;
        private float _cooldownReduction= 0.015f;
        private float _maxTimeSpawn;
        
        private IMeteoriteFactory _meteoriteFactory;
        private IHudService _hudService;

        public void Construct(IMeteoriteFactory meteoriteFactory, IHudService hudService)
        {
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
            meteorite.GetComponent<Meteorite>().Construct(this);
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