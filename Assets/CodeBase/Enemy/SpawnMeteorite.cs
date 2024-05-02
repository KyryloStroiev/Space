using System;
using CodeBase.Logic;
using CodeBase.StateData;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Infrastraction.Factory
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
        
        public void Construct(MeteoriteFactory meteoriteFactory, float minTimeSpawn, float maxTimeSpawn )
        {
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
            meteorite.GetComponent<Meteorite>().Construct(this);
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

        public void Destroy(float score)
        {
            Sound.PlayOneShot(SoundType.MeteoriteDamage);
            DestroyMeteorite?.Invoke(score);
        }
    }
    
    
}