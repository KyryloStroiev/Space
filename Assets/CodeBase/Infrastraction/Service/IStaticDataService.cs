using CodeBase.StateData;

namespace CodeBase.Infrastraction.Service
{
    public interface IStaticDataService
    {
        void Load();
        PlayerData ForPlayer();
        LevelData ForLevel();

        MeteoriteData ForMeteorite(MeteoriteTypeId meteoriteTypeId);

        WindowsConfig ForWindows(WindowsTypeId windowsTypeId);
    }
}