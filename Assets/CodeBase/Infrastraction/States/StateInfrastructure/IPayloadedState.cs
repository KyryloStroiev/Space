namespace CodeBase.Infrastraction.States.StateInfrastructure
{
    public interface IPayloadedState<TPayload>: IExitableState
    {
        void Enter(TPayload payload);
    }
}