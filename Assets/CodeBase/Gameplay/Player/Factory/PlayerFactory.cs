using CodeBase.Common.PhysicsService;
using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Cameras;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Logic;
using CodeBase.Infrastraction.Service;
using CodeBase.Service.InputsService;
using CodeBase.UI;
using CodeBase.UI.Service;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Factory
{
    public class PlayerFactory :  IPlayerFactory
    {
        private IStaticDataService _staticDataService;
        private readonly IInstanceFactory _instanceFactory;
        private readonly IObjectPool _objectPool;
        private readonly IWindowsService _windowsService;
        private readonly IInputService _inputService;
        private readonly ICameraProvider _cameraProvider;
        private readonly IPhysicsService _physicsService;
        private readonly IHudService _hudService;

        public PlayerFactory(IStaticDataService staticDataService, IInstanceFactory instanceFactory, 
            IObjectPool objectPool, IWindowsService windowsService, IInputService inputService, 
            ICameraProvider cameraProvider, IPhysicsService physicsService, IHudService hudService )  
        {
            _staticDataService = staticDataService;
            _instanceFactory = instanceFactory;
            _objectPool = objectPool;
            _windowsService = windowsService;
            _inputService = inputService;
            _cameraProvider = cameraProvider;
            _physicsService = physicsService;
            _hudService = hudService;
        }

        public GameObject CreatePlayer(Vector3 at)
        {
            PlayerConfig config = _staticDataService.ForPlayer();
            GameObject playerPrefab = _instanceFactory.InstantiateObject(config.PlayerPrefab, at);

            ConfigurePlayer(playerPrefab, config);

            return playerPrefab;
        }

        private void ConfigurePlayer(GameObject playerPrefab, PlayerConfig config)
        {
            playerPrefab.GetComponent<PlayerDeath>().Construct(_windowsService);
            PlayerBulletShot[] playerShots = playerPrefab.GetComponentsInChildren<PlayerBulletShot>();

            foreach (PlayerBulletShot playerShot in playerShots)
            {
                playerShot.Construct(_objectPool);
            }

            playerPrefab.GetComponent<ShipBox>().Construct(_objectPool, _physicsService);
            
            PlayerSetBomb playerSetBomb = playerPrefab.GetComponent<PlayerSetBomb>();
            playerSetBomb.MaxSpawnCountBombs =
                _staticDataService.GetArmamentData(ArmamentsTypeId.Bomb, 1).MaxSpawnCount;
            playerSetBomb.Construct(_objectPool, _inputService, _hudService);

            PlayerMove playerMove = playerPrefab.GetComponent<PlayerMove>();
            playerMove.Construct(_inputService);
            playerMove.Speed = config.Speed;
            playerMove.MaxXPosition = _cameraProvider.WorldScreenWidth/2;
        }
    }
}