using System;
using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Factory;
using CodeBase.Infrastraction.Service;
using CodeBase.Infrastraction.States;
using CodeBase.UI;
using UnityEngine;
using IState = CodeBase.Infrastraction.StateInfrastructure.IState;

namespace CodeBase.Infrastraction
{
    public class BootstrapState: IState
    {
        private const string NameScene = "Initial";
        private readonly SpawnMeteorite _spawnMeteorite;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IWindowsService _windowsService;
        private readonly IStaticDataService _staticDataService;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IMeteoriteFactory _meteoriteFactory;

        public BootstrapState( IGameStateMachine gameStateMachine, IWindowsService windowsService, 
            IStaticDataService staticDataService, ISceneLoader sceneLoader, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _windowsService = windowsService;
            _staticDataService = staticDataService;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }
        public void Enter()
        {
            _staticDataService.Load();
            _sceneLoader.Load(NameScene);
            _uiFactory.Construct(_gameStateMachine);
            _windowsService.Open(WindowsTypeId.StartMenu);
            
        }

   

        public void Exit() => 
            _windowsService.CleanUp();
    }
}