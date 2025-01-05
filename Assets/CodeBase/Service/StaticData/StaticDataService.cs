using System.Collections.Generic;
using System.Linq;
using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Levels;
using CodeBase.Gameplay.Player;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastraction.Service
{
    public class StaticDataService : IStaticDataService
    {
        private const string PlayerData = "StaticData/Player/Player";
        private const string LevelData = "StaticData/Level/Level";
        private const string MeteoriteData = "StaticData/Meteorite";
        private const string WindowsData = "StaticData/UI/Windows";
        private const string MeteoritesData = "StaticData/Meteorite/Common/commonMeteoritesConfig";

        private PlayerConfig _player;
        private LevelData _level;
        private CommonMeteoritesData _meteorites;
        private Dictionary<MeteoriteTypeId, MeteoriteData> _meteorite;
        private Dictionary<WindowsTypeId, WindowsConfig> _windows;

        public void Load()
        {
            LoadPlayerConfig();
            LoadLevel();
            LoadMeteoriteConfig();
            LoadWindows();
            LoadMeteoritesConfig();
        }
        
        public LevelData ForLevel() => _level;

        public PlayerConfig ForPlayer() => _player;

        public CommonMeteoritesData ForCommonMeteorites() => _meteorites;
        public MeteoriteData ForMeteorite(MeteoriteTypeId meteoriteTypeId) => 
            _meteorite.TryGetValue(meteoriteTypeId, out MeteoriteData staticData) ? staticData : null;

        public WindowsConfig ForWindows(WindowsTypeId windowsTypeId) => 
            _windows.TryGetValue(windowsTypeId, out WindowsConfig windowsConfig) ? windowsConfig : null;


        private void LoadLevel() => 
            _level = Resources.Load<LevelData>(LevelData);
        
        private void LoadMeteoritesConfig() =>
        _meteorites = Resources.Load<CommonMeteoritesData>(MeteoritesData);
        

        private void LoadPlayerConfig() => 
            _player = Resources.Load<PlayerConfig>(PlayerData);


        private void LoadMeteoriteConfig() =>
            _meteorite = Resources.LoadAll<MeteoriteData>(MeteoriteData)
                .ToDictionary(x => x.MeteoriteTypeId, x => x);

        private void LoadWindows() =>
            _windows = Resources.Load<WindowsData>(WindowsData)
                .Configs
                .ToDictionary(x => x.WindowsId, x => x);
    }
}