using System;
using System.Collections.Generic;
using CodeBase.Infrastraction.Factory;
using CodeBase.Infrastraction.Service;
using CodeBase.Logic;
using Zenject;


namespace CodeBase.Infrastraction
{
    public class GameStateMachine : IGameStateMachine
    {
        private IState _activeState;
        private Dictionary<Type, IState> _states;
        private IObjectPool _objectPool;
        private IStaticDataService _staticDataService;
        private readonly IPlayerFactory _playerFactory;
        private readonly IMeteoriteFactory _meteoriteFactory;
        private readonly IWindowsService _windowsService;
        private readonly IUIFactory _uiFactory;

        [Inject]
        public GameStateMachine(IObjectPool objectPool, IStaticDataService staticDataService, IPlayerFactory playerFactory,
            IMeteoriteFactory meteoriteFactory, IWindowsService windowsService, IUIFactory uiFactory)
        {
            _objectPool = objectPool;
            _staticDataService = staticDataService;
            _playerFactory = playerFactory;
            _meteoriteFactory = meteoriteFactory;
            _windowsService = windowsService;
            _uiFactory = uiFactory;
        }
        
        public void CreateAllState(SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, _windowsService, _staticDataService, sceneLoader, _uiFactory, loadingCurtain),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadingCurtain, _objectPool, _staticDataService, 
                    _playerFactory, _meteoriteFactory, _windowsService, _uiFactory),
                [typeof(GameLoopState)] = new GameLoopState(this)
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
            
        }
    }
}