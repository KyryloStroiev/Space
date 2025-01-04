using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Levels;
using CodeBase.Gameplay.Logic;
using CodeBase.Gameplay.Player.Factory;
using CodeBase.Infrastraction.Service;
using CodeBase.Infrastraction.StateInfrastructure;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastraction
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
        private readonly IUIFactory _uiFactory;
        private readonly IInstanceFactory _instanceFactory;


        public LoadLevelState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader,
            IObjectPool objectPool, IStaticDataService staticDataService, IPlayerFactory playerFactory, IMeteoriteFactory meteoriteFactory,
            IWindowsService windowsService, IUIFactory uiFactory, IInstanceFactory instanceFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _objectPool = objectPool;
            _staticDataService = staticDataService;
            _playerFactory = playerFactory;
            _meteoriteFactory = meteoriteFactory;
            _windowsService = windowsService;
            _uiFactory = uiFactory;
            _instanceFactory = instanceFactory;
        }

        public void Enter()
        {
            _uiFactory.Construct(_gameStateMachine);
            _staticDataService.Load();
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