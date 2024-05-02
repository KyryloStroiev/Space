using CodeBase.Infrastraction.Factory;
using CodeBase.Infrastraction.Service;
using CodeBase.Logic;
using CodeBase.StateData;
using UnityEngine;

namespace CodeBase.Infrastraction
{
    public class LoadLevelState: IState
    {
        private const string NameScene = "MainLevel";
        private readonly IGameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IObjectPool _objectPool;
        private readonly IStaticDataService _staticDataService;
        private readonly IPlayerFactory _playerFactory;
        private readonly IMeteoriteFactory _meteoriteFactory;
        private readonly IWindowsService _windowsService;
        private readonly IUIFactory _uiFactory;


        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain,
            IObjectPool objectPool, IStaticDataService staticDataService, IPlayerFactory playerFactory, IMeteoriteFactory meteoriteFactory, IWindowsService windowsService, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _objectPool = objectPool;
            _staticDataService = staticDataService;
            _playerFactory = playerFactory;
            _meteoriteFactory = meteoriteFactory;
            _windowsService = windowsService;
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            _loadingCurtain.Show();
            _uiFactory.Construct(_gameStateMachine);
            _staticDataService.Load();
            _playerFactory.CleanUp();
            _meteoriteFactory.CleanUp();
            _windowsService.CleanUp();
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
            _playerFactory.CreatePlayer(levelData.PointPlayerInitialize, _objectPool, _windowsService);

        public void Exit()
        {
            _loadingCurtain.Hide();
        }
    }
}