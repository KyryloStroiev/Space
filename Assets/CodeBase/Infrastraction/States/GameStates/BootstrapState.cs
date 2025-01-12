using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Factory;
using CodeBase.Infrastraction.Loading;
using CodeBase.Infrastraction.Service;
using StateInfrastructure_IState = CodeBase.Infrastraction.States.StateInfrastructure.IState;

namespace CodeBase.Infrastraction.States.GameStates
{
    public class BootstrapState: StateInfrastructure_IState
    {
        private const string NameScene = "Initial";
        private readonly SpawnMeteorite _spawnMeteorite;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly ISceneLoader _sceneLoader;
        private readonly IMeteoriteFactory _meteoriteFactory;

        public BootstrapState( IGameStateMachine gameStateMachine,
            IStaticDataService staticDataService, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
            _sceneLoader = sceneLoader;
        }
        public void Enter()
        {
            _staticDataService.Load();
            _sceneLoader.Load(NameScene, EnterLoadingHomeScreenState);
            
        }

        private void EnterLoadingHomeScreenState() => 
            _gameStateMachine.Enter<LoadingHomeScreenState>();
        


        public void Exit()
        {
           
        }
            
    }
}