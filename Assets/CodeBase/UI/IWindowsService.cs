using CodeBase.Gameplay.Enemy;

namespace CodeBase.UI
{
    public interface IWindowsService
    {
        void CreateHud(SpawnMeteorite spawnMeteorite);
        void Open(WindowsTypeId windowsTypeId);
        void CleanUp();
    }
}