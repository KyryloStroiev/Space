namespace CodeBase.Service.InputsService
{
    public interface IInputService
    {
        bool GetLaserShooting { get; }
        float Axis();
    }
}