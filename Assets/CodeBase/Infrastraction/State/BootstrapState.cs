using System;
using CodeBase.Infrastraction.Factory;
using CodeBase.Infrastraction.Service;
using CodeBase.StateData;
using UnityEngine;

namespace CodeBase.Infrastraction
{
    public class BootstrapState: IState
    {
        private const string NameScene = "Initial";
        private readonly SpawnMeteorite _spawnMeteorite;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IWindowsService _windowsService;
        private readonly IStaticDataService _staticDataService;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IMeteoriteFactory _meteoriteFactory;

        public BootstrapState( IGameStateMachine gameStateMachine, IWindowsService windowsService, 
            IStaticDataService staticDataService, SceneLoader sceneLoader, IUIFactory uiFactory, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _windowsService = windowsService;
            _staticDataService = staticDataService;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _loadingCurtain = loadingCurtain;
        }
        public void Enter()
        {
            _loadingCurtain.Hide();
            _staticDataService.Load();
            _sceneLoader.Load(NameScene);
            _uiFactory.Construct(_gameStateMachine);
            _windowsService.Open(WindowsTypeId.StartMenu);
            
        }

   

        public void Exit() => 
            _windowsService.CleanUp();
    }
}