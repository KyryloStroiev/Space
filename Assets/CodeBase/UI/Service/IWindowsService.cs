using CodeBase.Gameplay.Enemy;
using CodeBase.UI.Config;

namespace CodeBase.UI.Service
{
    public interface IWindowsService
    {
        void CreateHud(SpawnMeteorite spawnMeteorite);
        void Open(WindowsTypeId windowsTypeId);
        void CleanUp();
    }
}