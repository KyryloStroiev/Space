using System.Collections.Generic;
using CodeBase.Infrastraction.Service;
using CodeBase.StateData;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Infrastraction.Factory
{
    public class MeteoriteFactory: GameFactory, IMeteoriteFactory
    {
        private readonly IStaticDataService _staticDataService;
        private LevelData _levelData;


        public MeteoriteFactory(IStaticDataService staticDataService) : base(staticDataService) => 
            _staticDataService = staticDataService;


        public GameObject CreateSpawn()
        {
            _levelData = _staticDataService.ForLevel();
            GameObject spawnPoint = InstantiateObject(AssetAdress.SpawnAdress);
            spawnPoint.GetComponent<SpawnMeteorite>().Construct(this, _levelData.MinTimeSpawnMeteorite, _levelData.MaxTimeSpawnMeteorite);
            return spawnPoint;
        }

     
        public GameObject CreateMeteorite(MeteoriteTypeId meteoriteTypeId)
        {
            MeteoriteData meteoriteData = _staticDataService.ForMeteorite(meteoriteTypeId);
            GameObject meteoritePrefab = GameObject.Instantiate(meteoriteData.MeteoritePrefab, CalculateSpawnPosition(), Quaternion.identity);
            
            meteoritePrefab.GetComponent<MeteoriteMove>().Speed = meteoriteData.Speed;
            
            Meteorite meteorite = meteoritePrefab.GetComponent<Meteorite>();
            meteorite.Score = meteoriteData.Score;
            
            CreateCubeMeteorite(meteorite.EmptyPoint, meteoritePrefab, meteoriteData);

            return meteoritePrefab;
        }

        private void CreateCubeMeteorite(List<GameObject> emptyPoint ,GameObject meteorite, MeteoriteData meteoriteData)
        {
            float fillPercentage = Random.Range(meteoriteData.MinFillPercentageMeteorite,
                meteoriteData.MaxFillPercentageMeteorite)/100;
            
            for (int i = 0; i < emptyPoint.Count; i++)
            {
                if (Random.value < fillPercentage)
                {
                    GameObject instantiate =
                        InstantiateObject(emptyPoint[i].transform.position, AssetAdress.CubeAdress);
                    instantiate.transform.parent = meteorite.transform;
                }
            }
        }

        private Vector3 CalculateSpawnPosition()
        {
            float randomSpawnXPosition = Random.Range(-_levelData.MaxRangeXPosition, _levelData.MaxRangeXPosition);
            
            return new Vector3(randomSpawnXPosition, _levelData.CenterPoitnEnemyInitialize.y,
                _levelData.CenterPoitnEnemyInitialize.z);
        }
        
    }
}