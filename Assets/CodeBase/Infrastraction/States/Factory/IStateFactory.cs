using CodeBase.Infrastraction.StateInfrastructure;

namespace CodeBase.Infrastraction.States.Factory
{
    public interface IStateFactory
    {
        T GetState<T>() where T: class, IExitableState;
    }
}