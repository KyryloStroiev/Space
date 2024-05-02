using CodeBase.Infrastraction.Service;
using CodeBase.Logic;
using CodeBase.Player;
using CodeBase.StateData;
using UnityEngine;
using Zenject;
using PlayerShot = CodeBase.Player.PlayerShot;

namespace CodeBase.Infrastraction.Factory
{
    public class PlayerFactory : GameFactory, IPlayerFactory
    {
        private IStaticDataService _staticDataService;
        
        public PlayerFactory(IStaticDataService staticDataService) : base(staticDataService) => 
            _staticDataService = staticDataService;

        public GameObject CreatePlayer(Vector3 at, IObjectPool objectPool, IWindowsService windowsService)
        {
            PlayerData playerData = _staticDataService.ForPlayer();
            GameObject playerPrefab = InstantiateObject(at, AssetAdress.PlayerAdress);

            playerPrefab.GetComponent<PlayerDeath>().Construct(windowsService);
            PlayerShot[] playerShots = playerPrefab.GetComponentsInChildren<PlayerShot>();

            foreach (PlayerShot playerShot in playerShots)
            {
                playerShot.SpeedBullet = playerData.SpeedBullet;
                playerShot.Construct(objectPool);
            }

            PlayerMove playerMove = playerPrefab.GetComponent<PlayerMove>();
            playerMove.Speed = playerData.Speed;
            playerMove.MaxXPosition = playerData.MaxXPosition;
            
            return playerPrefab;
        }
        

       
        
       
    }
}