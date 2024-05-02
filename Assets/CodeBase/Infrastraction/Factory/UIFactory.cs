using CodeBase.Infrastraction.Service;
using CodeBase.StateData;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.Infrastraction.Factory
{
    public class UIFactory: GameFactory, IUIFactory
    {
        private readonly IStaticDataService _staticDataService;
        private IUIFactory _iuiFactoryImplementation;
        private IGameStateMachine _gameStateMachine;


        public UIFactory(IStaticDataService staticDataService) : base(staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        public GameObject CreateHud(SpawnMeteorite spawnMeteorite, IWindowsService windowsService)
        {
            GameObject UI = InstantiateObject(AssetAdress.UIAdress);
            UI.GetComponent<Hud>().Construct(windowsService, spawnMeteorite);
            return UI;
        }

       

        public void CreateMenu(WindowsTypeId windowsTypeId)
        {
            WindowsConfig windowsConfig = _staticDataService.ForWindows(windowsTypeId);
            GameObject Menu = InstantiateObject(windowsConfig.Prefab);
            Menu.GetComponent<Menu>().Construct(_gameStateMachine);
        }
        
    }
}