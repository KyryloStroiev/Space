using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Levels;
using CodeBase.Gameplay.Obstacle;
using CodeBase.Gameplay.Player;
using CodeBase.UI;
using CodeBase.UI.Config;
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
        private const string ArmamentsData = "StaticData/Armaments/";
        private const string ObstacleData = "StaticData/Obstacle/";

        private PlayerConfig _player;
        private LevelData _level;
        private CommonMeteoritesData _meteorites;
        private Dictionary<ObstacleTypeId, ObstacleConfig> _obstacles;
        private Dictionary<MeteoriteTypeId, MeteoriteData> _meteorite;
        private Dictionary<WindowsTypeId, WindowsConfig> _windows;
        private Dictionary<ArmamentsTypeId, ArmamentsConfig> _armaments;

        public void Load()
        {
            LoadPlayerConfig();
            LoadLevel();
            LoadMeteoriteConfig();
            LoadWindows();
            LoadMeteoritesConfig();
            LoadArmamentsConfig();
            LoadObstacles();
        }
        
        public LevelData ForLevel() => _level;

        public PlayerConfig ForPlayer() => _player;

        public CommonMeteoritesData ForCommonMeteorites() => _meteorites;
        
        public MeteoriteData ForMeteorite(MeteoriteTypeId meteoriteTypeId) => 
            _meteorite.TryGetValue(meteoriteTypeId, out MeteoriteData staticData) ? staticData : null;

        public WindowsConfig GetWindowsConfig(WindowsTypeId windowsTypeId) => 
            _windows.TryGetValue(windowsTypeId, out WindowsConfig windowsConfig) ? windowsConfig : null;

        public ObstacleConfig GetObstacleConfig(ObstacleTypeId obstacleTypeId) => 
            _obstacles.TryGetValue(obstacleTypeId, out ObstacleConfig obstacleConfig) ? obstacleConfig : null;


        public ArmamentData GetArmamentData(ArmamentsTypeId armamentsTypeId, int level)
        {
            ArmamentsConfig config = GetArmamentsConfig(armamentsTypeId);

            return config.Datas[level-1];
        }
        
        private ArmamentsConfig GetArmamentsConfig(ArmamentsTypeId armamentsTypeId)
        {
            if (_armaments.TryGetValue(armamentsTypeId, out ArmamentsConfig config))
                return config;

            throw new Exception($"Ability config for {armamentsTypeId} was not found");
        }

        private void LoadLevel() => 
            _level = Resources.Load<LevelData>(LevelData);
        
        private void LoadObstacles() =>
        _obstacles = Resources.LoadAll<ObstacleConfig>(ObstacleData)
            .ToDictionary(o => o.TypeId, o => o);
        
        private void LoadMeteoritesConfig() =>
        _meteorites = Resources.Load<CommonMeteoritesData>(MeteoritesData);
        

        private void LoadPlayerConfig() => 
            _player = Resources.Load<PlayerConfig>(PlayerData);

        private void LoadArmamentsConfig() =>
            _armaments = Resources.LoadAll<ArmamentsConfig>(ArmamentsData)
                .ToDictionary(x => x.TypeId, x => x);


        private void LoadMeteoriteConfig() =>
            _meteorite = Resources.LoadAll<MeteoriteData>(MeteoriteData)
                .ToDictionary(x => x.MeteoriteTypeId, x => x);

        private void LoadWindows() =>
            _windows = Resources.Load<WindowsData>(WindowsData)
                .Configs
                .ToDictionary(x => x.WindowsId, x => x);
    }
}