using CodeBase.Gameplay.Factory;
using CodeBase.Infrastraction.States.StateInfrastructure;
using CodeBase.UI;
using CodeBase.UI.Factory;
using CodeBase.UI.Service;

namespace CodeBase.Infrastraction.States.GameStates
{
    public class HomeScreenState: IState, IUpdateable
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IWindowsService _windowsService;
        private readonly IUIFactory _uiFactory;

        public HomeScreenState(IGameStateMachine gameStateMachine, IWindowsService windowsService, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _windowsService = windowsService;
            _uiFactory = uiFactory;
        }
        
        public void Enter()
        {
            _uiFactory.Construct(_gameStateMachine);
            _windowsService.Open(WindowsTypeId.StartMenu);
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            _windowsService.CleanUp();
        }
    }
}