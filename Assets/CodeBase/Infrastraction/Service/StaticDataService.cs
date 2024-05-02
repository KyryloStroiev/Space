using System.Collections.Generic;
using System.Linq;
using CodeBase.StateData;
using UnityEngine;

namespace CodeBase.Infrastraction.Service
{
    public class StaticDataService : IStaticDataService
    {
        private const string PlayerData = "StaticData/Player/Player";
        private const string LevelData = "StaticData/Level/Level";
        private const string MeteoriteData = "StaticData/Meteorite";
        private const string WindowsData = "StaticData/UI/Windows";

        private PlayerData _player;
        private LevelData _level;
        private Dictionary<MeteoriteTypeId, MeteoriteData> _meteorite;
        private Dictionary<WindowsTypeId, WindowsConfig> _windows;

        public void Load()
        {
            _player = Resources.Load<PlayerData>(PlayerData);
            _level = Resources.Load<LevelData>(LevelData);

            _meteorite = Resources.LoadAll<MeteoriteData>(MeteoriteData)
                .ToDictionary(x => x.MeteoriteTypeId, x => x);

            _windows = Resources.Load<WindowsData>(WindowsData)
                .Configs
                .ToDictionary(x => x.WindowsId, x => x);
        }

        public PlayerData ForPlayer() => _player;

        public LevelData ForLevel() => _level;

        public MeteoriteData ForMeteorite(MeteoriteTypeId meteoriteTypeId) => 
            _meteorite.TryGetValue(meteoriteTypeId, out MeteoriteData staticData) ? staticData : null;
        
        public WindowsConfig ForWindows(WindowsTypeId windowsTypeId) => 
            _windows.TryGetValue(windowsTypeId, out WindowsConfig windowsConfig) ? windowsConfig : null;
    }
}