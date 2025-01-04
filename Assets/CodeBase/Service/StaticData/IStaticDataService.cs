using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Levels;
using CodeBase.Gameplay.Player;
using CodeBase.UI;

namespace CodeBase.Infrastraction.Service
{
    public interface IStaticDataService
    {
        void Load();
        PlayerConfig ForPlayer();
        LevelData ForLevel();

        MeteoriteData ForMeteorite(MeteoriteTypeId meteoriteTypeId);

        WindowsConfig ForWindows(WindowsTypeId windowsTypeId);
    }
}