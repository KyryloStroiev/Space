namespace CodeBase.Infrastraction
{
    public interface IGameStateMachine
    {
        void CreateAllState(SceneLoader sceneLoader, LoadingCurtain loadingCurtain);
        void Enter<TState>() where TState : IState;
    }
}