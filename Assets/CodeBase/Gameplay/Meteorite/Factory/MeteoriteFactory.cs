using System.Collections.Generic;
using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Cameras;
using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Levels;
using CodeBase.Gameplay.Logic;
using CodeBase.Infrastraction.Service;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Gameplay.Factory
{
    public class MeteoriteFactory: IMeteoriteFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IInstanceFactory _instanceFactory;
        private readonly ICameraProvider _cameraProvider;
        private LevelData _levelData;
        private CommonMeteoritesData _commonMeteoritesData;


        public MeteoriteFactory(IStaticDataService staticDataService, IInstanceFactory instanceFactory, ICameraProvider cameraProvider)
        {
            _staticDataService = staticDataService;
            _instanceFactory = instanceFactory;
            _cameraProvider = cameraProvider;
        }


        public GameObject CreateSpawn()
        {
            _commonMeteoritesData = _staticDataService.ForCommonMeteorites();
            GameObject spawnPoint = _instanceFactory.InstantiateObject(_commonMeteoritesData.SpawnMeteoritePrefab);
            SpawnMeteorite spawnMeteorite = spawnPoint.GetComponent<SpawnMeteorite>();
            spawnMeteorite.Construct(this);
            spawnMeteorite.MinTimeSpawn = _commonMeteoritesData.MinTimeSpawnMeteorite;
            spawnMeteorite.MaxTimeSpawn = _commonMeteoritesData.MaxTimeSpawnMeteorite;
            return spawnPoint;
        }

     
        public GameObject CreateMeteorite(MeteoriteTypeId meteoriteTypeId)
        {
            MeteoriteData meteoriteData = _staticDataService.ForMeteorite(meteoriteTypeId);
            GameObject meteoritePrefab = _instanceFactory.InstantiateObject(meteoriteData.MeteoritePrefab, CalculateSpawnPosition());

            MeteoriteMove meteoriteMove = meteoritePrefab.GetComponent<MeteoriteMove>();
            meteoriteMove.Speed = meteoriteData.Speed;
            meteoriteMove.RotationSpeed = meteoriteData.RotationSpeed;

            Meteorite meteorite = meteoritePrefab.GetComponent<Meteorite>();
            meteorite.Score = meteoriteData.Score;
            
            CreateCubeMeteorite(meteorite.EmptyPoint, meteoritePrefab, meteoriteData, meteorite.Cube);

            return meteoritePrefab;
        }

        private void CreateCubeMeteorite(List<GameObject> emptyPoint ,GameObject meteorite, MeteoriteData meteoriteData, List<GameObject> cubes)
        {
            float fillPercentage = Random.Range(meteoriteData.MinFillPercentageMeteorite,
                meteoriteData.MaxFillPercentageMeteorite)/100;
            
            for (int i = 0; i < emptyPoint.Count; i++)
            {
                if (Random.value < fillPercentage)
                {
                    GameObject instantiate =
                        _instanceFactory.InstantiateObject(_staticDataService.ForCommonMeteorites().CubeMeteoritePrefab, emptyPoint[i].transform.position);
                    
                    instantiate.transform.parent = meteorite.transform;
                    cubes.Add(instantiate);
                }
            }
        }

        private Vector3 CalculateSpawnPosition()
        {
            _levelData = _staticDataService.ForLevel();
            float randomSpawnXPosition = Random.Range(-_cameraProvider.WorldScreenWidth/2, _cameraProvider.WorldScreenHeight/2);
            
            return new Vector3(randomSpawnXPosition, _levelData.CenterPoitnEnemyInitialize.y,
                _levelData.CenterPoitnEnemyInitialize.z);
        }
        
    }
}