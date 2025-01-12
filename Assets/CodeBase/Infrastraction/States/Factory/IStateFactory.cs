using CodeBase.Infrastraction.States.StateInfrastructure;

namespace CodeBase.Infrastraction.States.Factory
{
    public interface IStateFactory
    {
        T GetState<T>() where T: class, IExitableState;
    }
}