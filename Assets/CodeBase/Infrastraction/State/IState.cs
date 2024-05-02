namespace CodeBase.Infrastraction
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}