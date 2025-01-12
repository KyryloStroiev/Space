using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Levels;
using CodeBase.Gameplay.Logic;
using CodeBase.Gameplay.Player.Factory;
using CodeBase.Infrastraction.Loading;
using CodeBase.Infrastraction.Service;
using CodeBase.Infrastraction.States.StateInfrastructure;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastraction.States.GameStates
{
    public class LoadLevelState: IState
    {
        private const string NameScene = "MainLevel";
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IObjectPool _objectPool;
        private readonly IStaticDataService _staticDataService;
        private readonly IPlayerFactory _playerFactory;
        private readonly IMeteoriteFactory _meteoriteFactory;
        private readonly IWindowsService _windowsService;
        private readonly IInstanceFactory _instanceFactory;


        public LoadLevelState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader,
            IObjectPool objectPool, IStaticDataService staticDataService, IPlayerFactory playerFactory, IMeteoriteFactory meteoriteFactory,
            IWindowsService windowsService, IInstanceFactory instanceFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _objectPool = objectPool;
            _staticDataService = staticDataService;
            _playerFactory = playerFactory;
            _meteoriteFactory = meteoriteFactory;
            _windowsService = windowsService;
            _instanceFactory = instanceFactory;
        }

        public void Enter()
        {
            _instanceFactory.CleanUp();
            _sceneLoader.Load(NameScene, OnLoader);
        }

        private void OnLoader()
        {
            InitGameWorld();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            _objectPool.Instantiate();
            GameObject spawn = _meteoriteFactory.CreateSpawn();

            _windowsService.CreateHud(spawn.GetComponent<SpawnMeteorite>());
            
            LevelData levelData = _staticDataService.ForLevel();

            InitialPlayer(levelData);
        }

        private void InitialPlayer(LevelData levelData) => 
            _playerFactory.CreatePlayer(levelData.PointPlayerInitialize);

        public void Exit()
        {
        }
    }
}