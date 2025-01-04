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
        private float _timePassed;
        private MeteoriteFactory _meteoriteFactory;
        private IObjectPool _objectPool;

        public void Construct(MeteoriteFactory meteoriteFactory, IObjectPool objectPool, float minTimeSpawn, float maxTimeSpawn )
        {
            _objectPool = objectPool;
            _meteoriteFactory = meteoriteFactory;
            MinTimeSpawn = minTimeSpawn;
            MaxTimeSpawn = maxTimeSpawn;
            SetTimeSpawn();
        }

        private void Update()
        {
            ChangeSpawnTime();
            if (CanSpawn())
            {
                SpawnMeteorites();
            }

            PassedTime();
        }


        private void SpawnMeteorites()
        {
            GameObject meteorite = _meteoriteFactory.CreateMeteorite(GetRandomType());
            meteorite.GetComponent<Meteorite>().Construct(this, _objectPool);
            SetTimeSpawn();
        }

        private MeteoriteTypeId GetRandomType()
        {
            int enumLength = Enum.GetValues(typeof(MeteoriteTypeId)).Length;
            int randomIndex= Random.Range(0, enumLength);
            ReducingSpawnTime();
            return (MeteoriteTypeId)randomIndex;
        }


        private void ReducingSpawnTime()
        {
            MaxTimeSpawn -= _timePassed;
            if (MaxTimeSpawn <= MinTimeSpawn)
            {
                MinTimeSpawn = MaxTimeSpawn;
            }
        }
        
        private void ChangeSpawnTime() => 
            _timeSpawn -= Time.deltaTime;

        private bool CanSpawn() => 
            _timeSpawn <= 0;

        private void SetTimeSpawn() => 
            _timeSpawn = Random.Range(MinTimeSpawn, MaxTimeSpawn);

        private void PassedTime() => 
            _timePassed += Time.deltaTime / 1000;

        public void DestroyMeteor(float score)
        {
            Sound.PlayOneShot(SoundType.MeteoriteDamage);
            DestroyMeteorite?.Invoke(score);
        }
    }
    
    
}