using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Factory;
using CodeBase.Infrastraction;
using CodeBase.Infrastraction.Service;
using CodeBase.Infrastraction.States;
using CodeBase.UI.Service;
using UnityEngine;

namespace CodeBase.UI.Factory
{
    public class UIFactory:  IUIFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IInstanceFactory _instanceFactory;
        private readonly IHudService _hudService;
        private IUIFactory _iuiFactoryImplementation;
        private IGameStateMachine _gameStateMachine;


        public UIFactory(IStaticDataService staticDataService, IInstanceFactory instanceFactory, IHudService hudService)
        {
            _staticDataService = staticDataService;
            _instanceFactory = instanceFactory;
            _hudService = hudService;
        }

        public void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        public GameObject CreateHud(SpawnMeteorite spawnMeteorite, IWindowsService windowsService)
        {
            GameObject uiPrefab = _instanceFactory.InstantiateObject(_staticDataService.ForLevel().Hud);
            Hud hud = uiPrefab.GetComponent<Hud>();
            hud.Construct(windowsService, _hudService);
            hud.MaxSpawnCountBomb = _staticDataService.GetArmamentData(ArmamentsTypeId.Bomb, 1).MaxSpawnCount;
            
            return uiPrefab;
        }

       

        public void CreateMenu(WindowsTypeId windowsTypeId)
        {
            WindowsConfig windowsConfig = _staticDataService.GetWindowsConfig(windowsTypeId);
            GameObject Menu = _instanceFactory.InstantiateObject(windowsConfig.Prefab);
            Menu.GetComponent<Menu>().Construct(_gameStateMachine);
        }
        
    }
}