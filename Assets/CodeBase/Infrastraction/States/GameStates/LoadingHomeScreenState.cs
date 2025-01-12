using CodeBase.Infrastraction.Loading;
using CodeBase.Infrastraction.States.StateInfrastructure;

namespace CodeBase.Infrastraction.States.GameStates
{
    public class LoadingHomeScreenState: IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private const string HomeScreenStateName = "HomeScreen";

        public LoadingHomeScreenState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        public void Enter()
        {
           _sceneLoader.Load(HomeScreenStateName, EnterHomeScreenState);
        }

        private void EnterHomeScreenState()
        {
            _stateMachine.Enter<HomeScreenState>();
        }

        public void Exit()
        {
            
        }
    }
}