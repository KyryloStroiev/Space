using CodeBase.Gameplay.Enemy;
using CodeBase.Infrastraction;
using CodeBase.Infrastraction.Service;
using CodeBase.Infrastraction.States;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Gameplay.Factory
{
    public class UIFactory:  IUIFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IInstanceFactory _instanceFactory;
        private IUIFactory _iuiFactoryImplementation;
        private IGameStateMachine _gameStateMachine;


        public UIFactory(IStaticDataService staticDataService, IInstanceFactory instanceFactory)
        {
            _staticDataService = staticDataService;
            _instanceFactory = instanceFactory;
        }

        public void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        public GameObject CreateHud(SpawnMeteorite spawnMeteorite, IWindowsService windowsService)
        {
            GameObject UI = _instanceFactory.InstantiateObject(_staticDataService.ForLevel().Hud);
            UI.GetComponent<Hud>().Construct(windowsService, spawnMeteorite);
            return UI;
        }

       

        public void CreateMenu(WindowsTypeId windowsTypeId)
        {
            WindowsConfig windowsConfig = _staticDataService.ForWindows(windowsTypeId);
            GameObject Menu = _instanceFactory.InstantiateObject(windowsConfig.Prefab);
            Menu.GetComponent<Menu>().Construct(_gameStateMachine);
        }
        
    }
}