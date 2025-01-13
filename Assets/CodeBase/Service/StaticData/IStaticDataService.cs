using CodeBase.Gameplay.Armaments;
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

        WindowsConfig GetWindowsConfig(WindowsTypeId windowsTypeId);
        CommonMeteoritesData ForCommonMeteorites();
        ArmamentData GetArmamentData(ArmamentsTypeId armamentsTypeId, int level);
    }
}