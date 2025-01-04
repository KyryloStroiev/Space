using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Logic;
using CodeBase.Infrastraction.Service;
using CodeBase.Service.InputsService;
using CodeBase.UI;
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

        public PlayerFactory(IStaticDataService staticDataService, IInstanceFactory instanceFactory, 
            IObjectPool objectPool, IWindowsService windowsService, IInputService inputService )  
        {
            _staticDataService = staticDataService;
            _instanceFactory = instanceFactory;
            _objectPool = objectPool;
            _windowsService = windowsService;
            _inputService = inputService;
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
            PlayerShot[] playerShots = playerPrefab.GetComponentsInChildren<PlayerShot>();

            foreach (PlayerShot playerShot in playerShots)
            {
                playerShot.SpeedBullet = config.SpeedBullet;
                playerShot.Construct(_objectPool, _staticDataService, _inputService);
            }

            PlayerMove playerMove = playerPrefab.GetComponent<PlayerMove>();
            playerMove.Construct(_inputService);
            playerMove.Speed = config.Speed;
            playerMove.MaxXPosition = config.MaxXPosition;
        }
    }
}