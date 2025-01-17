using CodeBase.Gameplay.Cameras;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Levels;
using CodeBase.Infrastraction.Service;
using UnityEngine;

namespace CodeBase.Gameplay.Obstacle.Factory
{
    public class ObstacleFactory : IObstacleFactory
    {
        private readonly IStaticDataService _staticData;
        private readonly IInstanceFactory _instanceFactory;
        private readonly ICameraProvider _cameraProvider;
        private LevelData _levelData;

        public ObstacleFactory(IStaticDataService staticData, IInstanceFactory instanceFactory, ICameraProvider cameraProvider )
        {
            _staticData = staticData;
            _instanceFactory = instanceFactory;
            _cameraProvider = cameraProvider;
        }
        
        public GameObject CreateUndestroyableBlock(ObstacleTypeId typeId )
        {
            ObstacleConfig config = _staticData.GetObstacleConfig(typeId);
            
            GameObject obstaclePrefab = _instanceFactory.InstantiateObject(config.Prefab, CalculateSpawnPosition());
            ObstacleMove obstacleMove = obstaclePrefab.GetComponent<ObstacleMove>();
            obstacleMove.Speed = config.Speed;
            return obstaclePrefab;
        }
        
        
        private Vector3 CalculateSpawnPosition()
        {
            _levelData = _staticData.ForLevel();
            float randomSpawnXPosition = Random.Range(-_cameraProvider.WorldScreenWidth/2, _cameraProvider.WorldScreenHeight/2);
            
            return new Vector3(randomSpawnXPosition, _levelData.CenterPoitnEnemyInitialize.y,
                _levelData.CenterPoitnEnemyInitialize.z);
        }
    }
}