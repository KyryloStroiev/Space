using CodeBase.Infrastraction.States.StateInfrastructure;

namespace CodeBase.Infrastraction.States
{
    public interface IGameStateMachine
    {
       
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
    }
}