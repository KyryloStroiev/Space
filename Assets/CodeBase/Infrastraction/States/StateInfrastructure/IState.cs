namespace CodeBase.Infrastraction.StateInfrastructure
{
    public interface IState: IExitableState
    {
        void Enter();
    }
}