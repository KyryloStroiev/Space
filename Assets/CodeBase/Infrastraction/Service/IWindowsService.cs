using CodeBase.Infrastraction.Factory;
using CodeBase.StateData;

namespace CodeBase.Infrastraction.Service
{
    public interface IWindowsService
    {
        void Open(WindowsTypeId windowsTypeId);
        void CleanUp();
        void CreateHud(SpawnMeteorite spawnMeteorite);
    }
}