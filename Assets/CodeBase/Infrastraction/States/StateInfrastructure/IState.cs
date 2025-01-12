namespace CodeBase.Infrastraction.States.StateInfrastructure
{
    public interface IState: IExitableState
    {
        void Enter();
    }
}