using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Levels;
using CodeBase.Gameplay.Obstacle;
using CodeBase.Gameplay.Player;
using CodeBase.UI;
using CodeBase.UI.Config;

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
        ObstacleConfig GetObstacleConfig(ObstacleTypeId obstacleTypeId);
    }
}