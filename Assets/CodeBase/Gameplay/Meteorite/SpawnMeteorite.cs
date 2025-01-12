using System;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Logic;
using CodeBase.Gameplay.Sounds;
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

        public void Construct(IMeteoriteFactory meteoriteFactory) => 
            _meteoriteFactory = meteoriteFactory;

        private void Start()
        {
            _maxTimeSpawn = MaxTimeSpawn;
            SetTimeSpawn();
        }

        private void Update()
        {
            Debug.Log(_maxTimeSpawn);
            
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

        
        public void DestroyMeteor(float score)
        {
            Sound.PlayOneShot(SoundType.MeteoriteDamage);
            DestroyMeteorite?.Invoke(score);
        }
    }
    
    
}