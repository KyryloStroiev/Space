using CodeBase.Infrastraction.States.StateInfrastructure;

namespace CodeBase.Infrastraction.States.GameStates
{
    public class GameLoopState: IState, IUpdateable
    {
        private readonly GameStateMachine _gameStateMachine;

        public GameLoopState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
           
        }
    }
}